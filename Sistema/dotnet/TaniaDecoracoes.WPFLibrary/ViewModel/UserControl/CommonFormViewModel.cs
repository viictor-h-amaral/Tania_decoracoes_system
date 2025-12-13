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
            IFormFieldViewModel field = FormFieldViewModelSolver.Resolve(prop, SourceObject); 

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

        public CommonFormViewModel(string titulo, FormMode estado, T objeto, DbContext context, bool autoGenerateFields)
        {
            if (estado == FormMode.Create)
                throw new ArgumentException("O estado 'Create' não deve ser usado com um objeto fonte.");

            Titulo = titulo;
            Mode = estado;
            _entityBase = new EntityBase<T>(context);
            SourceObject = objeto;

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
                    var entityBase = new EntityBase<T>(context);

                    // Buscar a entidade existente no banco
                    var existingEntity = context.Set<T>().Find(SourceObject.Id);
                    if (existingEntity == null)
                    {
                        MessageBox.Show("Registro não encontrado!");
                        return;
                    }

                    // Copiar propriedades escalares
                    context.Entry(existingEntity).CurrentValues.SetValues(SourceObject);

                    // Gerenciar entidades relacionadas
                    GerenciarEntidadesRelacionadas(context, existingEntity, SourceObject);

                    entityBase.Update(existingEntity);

                    MessageBox.Show("Registro atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar: {ex.Message}");
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
