using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.EntitiesLibrary;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.Utils.FormUtils;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class CommonFormViewModel<T> : ViewModelBase, IFormViewModel where T: class
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

        private IEnumerable<FormFieldViewModel> _fields;
        public IEnumerable<FormFieldViewModel> Fields
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

            var fields = new List<FormFieldViewModel>();

            foreach (var prop in properties)
            {
                if (prop.GetCustomAttribute<IgnoreOnFormAttribute>() != null)
                    continue;

                fields.Add(CreateFormFieldViewModel(prop));
            }

            Fields = fields;
        }

        private FormFieldViewModel CreateFormFieldViewModel(PropertyInfo prop)
        {
            var field = new FormFieldViewModel(prop, SourceObject)
            {
                Label = FormatPropertyLabelHelper.GetPropertyLabel(prop),
                ValidationRules = GetValidationRules(prop),
                IsReadOnly = Mode == FormMode.View, 
            };

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

        public CommonFormViewModel(string titulo, FormMode estado, T objeto, DbContext contexto, bool autoGenerateFields)
        {
            if (estado == FormMode.Create)
                throw new ArgumentException("O estado 'Create' não deve ser usado com um objeto fonte.");

            Titulo = titulo;
            Mode = estado;
            SourceObject = objeto;
            _entityBase = new EntityBase<T>(contexto);

            if (autoGenerateFields) GenerateFields();

            if (estado == FormMode.Edit) CreateFormCommands();
        }

        public CommonFormViewModel(string titulo, bool autoGenerateFields)
        {
            Titulo = titulo;
            Mode = FormMode.Create;
            
            SourceObject = Activator.CreateInstance<T>();
            _entityBase = new EntityBase<T>(new TaniaDecoracoesDbContext());

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

    public interface IFormViewModel { }
}
