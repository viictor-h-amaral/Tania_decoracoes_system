using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models.Attributes;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class FormFieldViewModel : ViewModelBase
    {
        private object _entityBase;
        private object _sourceObject;

        private PropertyInfo _property;

        public string PropertyName => _property.Name;

        public Type PropertyType => _property.PropertyType;
        public bool ehInstance => _property.GetCustomAttribute<BindingAttribute>() != null;
        private object GetPropValue()
        {
            var bindingAttr = _property.GetCustomAttribute<BindingAttribute>();
            //bool ehInstancia = bindingAttr != null;

            var result = bindingAttr != null //ehInstancia
                ? _property.GetValue(_sourceObject)?.GetType().GetProperty(
                    bindingAttr.FieldToBringFromInstance)?.GetValue(
                        _property.GetValue(_sourceObject))
                : _property.GetValue(_sourceObject);
            return result ?? "";
        }

        private void SetPropValue(object value)
        {
            _property.SetValue(_sourceObject, value);
        }

        public object Value
        {
            get => GetPropValue();
            set
            {
                SetPropValue(value);
                OnPropertyChanged();
                Validate();
            }
        }

        //private string _instanceObjectsDisplayProperty;
        public string InstanceObjectsDisplayProperty
        {
            get
            {
                var bindingAttr = _property.GetCustomAttribute<BindingAttribute>();
                if (bindingAttr == null)
                    return "";
                return bindingAttr.FieldToBringFromInstance;
            }/*
            set
            {
                var bindingAttr = _property.GetCustomAttribute<BindingAttribute>();
                if (bindingAttr != null)
                    _instanceObjectsDisplayProperty = bindingAttr.FieldToBringFromInstance;
            }*/
        }

        private ObservableCollection<object>? _instanceValues = new ObservableCollection<object>();

        public ObservableCollection<object>? InstanceValues
        {
            get => _instanceValues;
            set
            {
                SetProperty(ref _instanceValues, value);
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
            _property = prop;
            _sourceObject = sourceObject;

            var bindingAttr = _property.GetCustomAttribute<BindingAttribute>();
            if (bindingAttr != null)
            {
                //InstanceObjectsDisplayProperty = bindingAttr.FieldToBringFromInstance;
                Type instanceType = _property.PropertyType;
                var context = new TaniaDecoracoesDbContext();
                // Corrigido: Use o método Set com o tipo explicitamente especificado
                var setMethod = typeof(TaniaDecoracoesDbContext).GetMethod("Set", Type.EmptyTypes);
                var genericSetMethod = setMethod.MakeGenericMethod(instanceType);
                var objs = ((IEnumerable<object>)genericSetMethod.Invoke(context, null)).ToList();
                // Se quiser usar os valores, atribua a InstanceValues:
                InstanceValues = new ObservableCollection<object>(objs);
            }

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
