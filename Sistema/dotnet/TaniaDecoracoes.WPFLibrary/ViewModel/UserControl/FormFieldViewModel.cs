using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class FormFieldViewModel : ViewModelBase
    {

        private readonly Func<object> Getter;
        private Action<object> Setter;

        //private object? _value;
        public object Value
        {
            get => Getter();
            set
            {
                Setter(value);
                OnPropertyChanged();
                Validate();
            }
        }

        public string Label { get; set; }
        public string PropertyName { get; set; }
        public Type PropertyType { get; set; }

        private bool _isReadOnly;
        public bool IsReadOnly { 
            get => _isReadOnly;
            set
            {
                SetProperty(ref _isReadOnly, value);
                Console.WriteLine($"IsReadOnly set to {value} for {PropertyName}");
            }
        }

        public IEnumerable<ValidationRule> ValidationRules { get; set; }
        public string ErrorMessage { get; private set; }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

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

        public FormFieldViewModel(Func<object> getter, Action<object> setter)
        {
            Getter = getter;
            Setter = setter;
            ValidationRules = new List<ValidationRule>();
        }

    }

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
}
