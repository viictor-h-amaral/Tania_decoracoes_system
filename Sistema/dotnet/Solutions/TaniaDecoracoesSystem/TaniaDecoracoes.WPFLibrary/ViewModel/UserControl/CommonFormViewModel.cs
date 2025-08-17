using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.DirectoryServices;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.WPFLibrary.Utils;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class CommonFormViewModel : ViewModelBase
    {
        #region Propriedades

        private FormMode _mode;
        public FormMode Mode
        {
            get => _mode;
            set
            {
                SetProperty(ref _mode, value);
                //GenerateFields();
            }
        }

        private object? _sourceObject;
        public object? SourceObject
        {
            get => _sourceObject;
            set
            {
                SetProperty(ref _sourceObject, value);
                GenerateFieldsWithObject();
            }
        }

        private Type? _typeObject;
        public Type? TypeObject
        {
            get => _typeObject;
            set
            {
                SetProperty(ref _typeObject, value);
                GenerateFieldsWithType();
            }
        }

        private IEnumerable<FormFieldViewModel> _fields;
        public IEnumerable<FormFieldViewModel> Fields
        {
            get => _fields;
            private set => SetProperty(ref _fields, value);
        }

        #endregion Propriedades

        private void GenerateFieldsWithObject()
        {
            if (SourceObject is null)
            {
                Fields = Enumerable.Empty<FormFieldViewModel>();
                return;
            }

            var properties = SourceObject.GetType().GetProperties();

            Fields = GenerateFieldsWithProperties(properties);

        }

        private void GenerateFieldsWithType()
        {
            if (TypeObject is null)
            {
                Fields = Enumerable.Empty<FormFieldViewModel>();
                return;
            }

            var fields = new List<FormFieldViewModel>();
            var properties = TypeObject.GetProperties();

            Fields = GenerateFieldsWithProperties(properties);
        }

        private List<FormFieldViewModel> GenerateFieldsWithProperties(params PropertyInfo[] properties)
        {
            var fields = new List<FormFieldViewModel>();

            foreach (var prop in properties)
            {
                if (prop.GetCustomAttribute<IgnoreOnFormAttribute>() != null)
                    continue;

                fields.Add(CreateFormFieldViewModel(prop));
            }

            return fields;
        }

        private FormFieldViewModel CreateFormFieldViewModel(PropertyInfo prop)
        {
            return new FormFieldViewModel
            {
                Label = FormatPropertyLabelHelper.GetPropertyLabel(prop),
                PropertyName = prop.Name,
                //Value = prop.GetValue(SourceObject),
                PropertyType = prop.PropertyType,
                IsReadOnly = Mode == FormMode.View,
                ValidationRules = GetValidationRules(prop)
            };
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
    }

    public enum FormMode
    {
        View,
        Edit,
        Create
    }
}
