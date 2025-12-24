using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.EntitiesLibrary;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.Utils.FormUtils;
using TaniaDecoracoes.WPFLibrary.ViewModel.Implementacoes;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoFormField;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class CommonFormViewModel<T> : ViewModelBase, IFormViewModel where T: class, IEntityModel
    {
        private readonly IEntityBase<T> _entityBase;

        public ICommand SaveCommand { get; set; }

        #region PROPRIEDADES

        private string _titulo;
        public string Titulo 
        {
            get => _titulo;
            set
            {
                _titulo = string.Empty;
                if (value != null)
                    _titulo = value;
            } 
        }

        private FormMode _mode;
        public FormMode Mode
        {
            get => _mode;
            set
            {
                SetProperty(ref _mode, value);
            }
        }

        private T _sourceObject;
        public T SourceObject
        {
            get => _sourceObject;
            set
            {
                SetProperty(ref _sourceObject, value);
            }
        }

        private Type? TypeObject => (SourceObject.GetType().BaseType != null && SourceObject.GetType().BaseType != typeof(object))
                                    ? SourceObject.GetType().BaseType
                                    : SourceObject.GetType();

        private IEnumerable<IFormFieldViewModel> _fields;
        public IEnumerable<IFormFieldViewModel> Fields
        {
            get => _fields;
            private set => SetProperty(ref _fields, value);
        }

        private IEnumerable<CustomFormButton> _formComands;
        public IEnumerable<CustomFormButton> FormCommands
        {
            get => _formComands;
            private set => SetProperty(ref _formComands, value);
        }

        #endregion 

        #region GERAÇÃO CAMPOS

        private void GenerateFields()
        {
            var properties = TypeObject.GetProperties();

            var fields = new List<IFormFieldViewModel>();

            foreach (var prop in properties)
            {
                if (prop.GetCustomAttribute<IgnoreOnFormAttribute>() != null)
                    continue;

                fields.Add(CreateFormFieldViewModel(prop));
            }

            Fields = fields;
        }

        private IFormFieldViewModel CreateFormFieldViewModel(PropertyInfo prop)
        {
            IFormFieldViewModel field;
            if (this.Mode == FormMode.View)
            {
                var sourceWithNoTracking = _entityBase.FirstWithNoTracking(e => e.Id == SourceObject.Id);
                field = FormFieldViewModelSolver.Resolve(prop, sourceWithNoTracking);
            }
            else
            {
                field = FormFieldViewModelSolver.Resolve(prop, SourceObject);
            }


            field.Label = FormatPropertyLabelHelper.GetPropertyLabel(prop);
            field.IsReadOnly = Mode == FormMode.View;

            return field;
        }

        

        private IEnumerable<ValidationRule> GetValidationRules(PropertyInfo prop)
        {
            var rules = new List<ValidationRule>();

            if (prop.GetCustomAttribute<RequiredAttribute>() != null)
            {
                rules.Add(new RequiredValidationRule());
            }

            return rules;
        }

        #endregion

        #region CONSTRUTORES

        public CommonFormViewModel(string titulo, FormMode estado, int objetoId, bool autoGenerateFields)
        {
            if (estado == FormMode.Create)
                throw new ArgumentException("O estado 'Create' não deve ser usado com um objeto fonte.");

            Titulo = titulo;
            Mode = estado;
            var context = new TaniaDecoracoesDbContext();
            _entityBase = new EntityBase<T>(context);

            if (estado == FormMode.Edit)
            {
                // Primeiro, limpar qualquer entidade duplicada
                var existingEntry = context
                                        .ChangeTracker
                                        .Entries<T>()
                                        .FirstOrDefault(e => 
                                            ((IEntityModel)e.Entity).Id == objetoId);

                if (existingEntry != null)
                    existingEntry.State = EntityState.Detached;

                // Agora buscar a entidade com tracking
                SourceObject = _entityBase.First(e => e.Id == objetoId);
            }
            else
            {
                SourceObject = _entityBase.FirstWithNoTracking(e => e.Id == objetoId);
            }
                

            if (autoGenerateFields) GenerateFields();

            if (estado == FormMode.Edit) CreateFormCommands();
        }

        public CommonFormViewModel(string titulo, bool autoGenerateFields, DbContext context)
        {
            Titulo = titulo;
            Mode = FormMode.Create;
            
            SourceObject = Activator.CreateInstance<T>();
            _entityBase = new EntityBase<T>(context);

            if (autoGenerateFields) GenerateFields();

            CreateFormCommands();
        }

        #endregion

        private void CreateFormCommands()
        {
            if (Mode == FormMode.Create)
            {
                SaveCommand = new RelayCommand(() =>
                {
                    SalvarEntidade();
                });
            }
            else
            {
                SaveCommand = new RelayCommand(() =>
                {
                    AtualizarEntidade();
                });
            }

            var SaveButton = new CustomFormButton()
            {
                Conteudo = "Salvar",
                Icone = "\uf0c7",
                Foreground = Brushes.White,
                Background = Brushes.Green,
                Comando = SaveCommand
            };

            FormCommands = new List<CustomFormButton> { SaveButton };
        }

        private void SalvarEntidade()
        {
            try
            {
                // Para criação, é mais simples - criar novo contexto
                using (var context = new TaniaDecoracoesDbContext())
                {
                    var entityBase = new EntityBase<T>(context);

                    // Anexar entidades relacionadas ao contexto
                    AnexarEntidadesRelacionadas(context, SourceObject);

                    entityBase.Save(SourceObject);

                    // Mensagem de sucesso
                    MessageBox.Show("Registro salvo com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}");
            }
        }

        private void AtualizarEntidade()
        {
            try
            {
                using (var context = new TaniaDecoracoesDbContext())
                {
                    context.Attach(SourceObject);

                    // 3. Marcar como modificado
                    context.Entry(SourceObject).State = EntityState.Modified;

                    // 4. Para navegações: precisamos anexar entidades relacionadas também
                    AttachRelatedEntities(context, SourceObject);

                    context.SaveChanges();
                    context.Entry(SourceObject).State = EntityState.Detached;
                    context.Dispose();
                    MessageBox.Show("Registro atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar: {ex.Message}");
            }
        }

        private void AttachRelatedEntities(DbContext context, T entity)
        {
            var navigationProperties = typeof(T).GetProperties()
                .Where(p => typeof(IEntityModel).IsAssignableFrom(p.PropertyType));

            foreach (var navProp in navigationProperties)
            {
                var relatedEntity = navProp.GetValue(entity) as IEntityModel;
                if (relatedEntity != null && relatedEntity.Id > 0)
                {
                    // Verificar se já está no contexto
                    var existingEntry = context.ChangeTracker.Entries()
                        .FirstOrDefault(e => e.Entity is IEntityModel trackedEntity &&
                                           trackedEntity.GetType() == relatedEntity.GetType() &&
                                           trackedEntity.Id == relatedEntity.Id);

                    if (existingEntry != null)
                    {
                        // Usar a já existente
                        navProp.SetValue(entity, existingEntry.Entity);
                    }
                    else
                    {
                        // Anexar a nova
                        context.Attach(relatedEntity);
                    }
                }
            }
        }

        private IEntityModel? ObterEntidadeRastreada(DbContext context, IEntityModel entity)
        {
            if (entity == null || entity.Id == 0) return null;

            var trackedEntry = context.ChangeTracker.Entries()
                .FirstOrDefault(e => e.Entity is IEntityModel trackedEntity &&
                                   trackedEntity.GetType() == entity.GetType() &&
                                   trackedEntity.Id == entity.Id);

            return trackedEntry?.Entity as IEntityModel;
        }

        private void GerenciarEntidadesRelacionadas(DbContext context, T existingEntity, T newEntity)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => typeof(IEntityModel).IsAssignableFrom(p.PropertyType));

            foreach (var prop in properties)
            {
                var newRelatedEntity = prop.GetValue(newEntity) as IEntityModel;

                if (newRelatedEntity != null && newRelatedEntity.Id > 0)
                {
                    var trackedEntity = ObterEntidadeRastreada(context, newRelatedEntity);
                    prop.SetValue(existingEntity, trackedEntity ?? newRelatedEntity);

                    if (trackedEntity == null)
                    {
                        context.Attach(newRelatedEntity);
                    }
                }
                else
                {
                    prop.SetValue(existingEntity, null);
                }
            }
        }

        private void AnexarEntidadesRelacionadas(DbContext context, T entity)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => typeof(IEntityModel).IsAssignableFrom(p.PropertyType));

            foreach (var prop in properties)
            {
                var relatedEntity = prop.GetValue(entity) as IEntityModel;
                if (relatedEntity != null && relatedEntity.Id > 0)
                {
                    var trackedEntity = ObterEntidadeRastreada(context, relatedEntity);

                    if (trackedEntity != null)
                    {
                        prop.SetValue(entity, trackedEntity);
                    }
                    else
                    {
                        context.Attach(relatedEntity);
                    }
                }
            }
        }
    }

    public enum FormMode
    {
        View,
        Edit,
        Create
    }
}
