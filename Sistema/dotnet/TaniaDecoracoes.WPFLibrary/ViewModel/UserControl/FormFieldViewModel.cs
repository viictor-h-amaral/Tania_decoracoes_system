using System.Reflection;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class FormFieldViewModel<T> : ViewModelBase, IFormFieldViewModel
    {
        public object SourceObject { get; set; }

        public PropertyInfo Property { get; set; }

        public string PropertyName => Property.Name;

        public Type PropertyType => Property.PropertyType;

        private object GetPropValue() => Property.GetValue(SourceObject);

        private void SetPropValue(object? value)
        {
            Property.SetValue(SourceObject, value);
        }

        public object? Value
        {
            get => GetPropValue();
            set
            {
                SetPropValue(value);
                OnPropertyChanged();
                Validate();
            }
        }

        public string Label { get; set; }

        #region ESTADO_CAMPO

        private bool _isReadOnly;
        public bool IsReadOnly {
            get => _isReadOnly;
            set
            {
                SetProperty(ref _isReadOnly, value);
            }
        }

        public IEnumerable<ValidationRule> ValidationRules { get; set; }
        public string ErrorMessage { get; private set; }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        public FormFieldViewModel(PropertyInfo prop, object sourceObject)
        {
            Property = prop;
            SourceObject = sourceObject;

            ValidationRules = new List<ValidationRule>();
        }

        #endregion CONSTRUTORES

        #region VALIDACAO

        private void Validate()
        {
            if (ValidationRules == null) return;

            foreach (var rule in ValidationRules)
            {
                if (!rule.Validate(Value))
                {
                    ErrorMessage = rule.ErrorMessage;
                    OnPropertyChanged(nameof(ErrorMessage));
                    OnPropertyChanged(nameof(HasError));
                    return;
                }
            }

            ErrorMessage = null;
            OnPropertyChanged(nameof(ErrorMessage));
            OnPropertyChanged(nameof(HasError));
        }

        #endregion VALIDACAO

    }

    #region VALIDATION RULES

    public abstract class ValidationRule
    {
        public abstract bool Validate(object value);
        public string ErrorMessage { get; protected set; }
    }

    public class RequiredValidationRule : ValidationRule
    {
        public RequiredValidationRule()
        {
            ErrorMessage = "Este campo é obrigatório";
        }

        public override bool Validate(object value)
        {
            return value != null && !string.IsNullOrWhiteSpace(value.ToString());
        }
    }

    #endregion
}
