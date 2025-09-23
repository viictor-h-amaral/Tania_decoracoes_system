using System.ComponentModel.DataAnnotations;
using System.Reflection;
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
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;

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
            Type? tipoField = null;
            if (prop.PropertyType == typeof(string))
                tipoField = typeof(FormFieldViewModel<>);
            else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
                tipoField = typeof(FormFieldViewModel<>);
            else if (prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(decimal?))
                tipoField = typeof(FormFieldViewModel<>);
            else if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
                tipoField = typeof(FormFieldViewModel<>);
            else if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                tipoField = typeof(FormFieldViewModel<>);
            else if (typeof(IEntityModel).IsAssignableFrom(prop.PropertyType) ||
                     (prop.PropertyType.IsGenericType &&
                      prop.PropertyType.GetGenericArguments().Length == 1 &&
                      typeof(IEntityModel).IsAssignableFrom(prop.PropertyType.GetGenericArguments()[0])))
                tipoField = typeof(InstanceFormFieldViewModel<>);
            else
                tipoField = typeof(FormFieldViewModel<>);

            object? value = prop.GetValue(SourceObject);

            object? idValue = null;
            if (value is IEntityModel entityModel)
            {
                idValue = entityModel.Id;
            }

            object? objForm = Activator.CreateInstance(
                    tipoField.MakeGenericType(prop.PropertyType),
                    prop,
                    SourceObject,
                    idValue
                );

            IFormFieldViewModel? field =
                objForm as IFormFieldViewModel
                ?? throw new InvalidOperationException($"Não foi possível criar a instância de IFormFieldViewModel para a propriedade {prop} de tipo {prop.PropertyType}.");

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
            if(Mode == FormMode.Create)
            {
                SaveCommand = new RelayCommand(() =>
                {
                    _entityBase.Save(SourceObject);
                });
            }
            else
            {
                SaveCommand = new RelayCommand(() =>
                {
                    _entityBase.Update(SourceObject);
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

            FormCommands = new List<CustomFormButton>
            {
                SaveButton
            };
        }   
    }

    public enum FormMode
    {
        View,
        Edit,
        Create
    }
}
