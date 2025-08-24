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
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.EntitiesLibrary;
using TaniaDecoracoes.WPFLibrary.Utils;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class CommonFormViewModel : ViewModelBase
    {
        private object _entityBase;

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
                //GenerateFields();
            }
        }

        private object _sourceObject;
        public object SourceObject
        {
            get => _sourceObject;
            set
            {
                SetProperty(ref _sourceObject, value);
                TypeObject = value?.GetType() ?? typeof(object);
            }
        }

        private Type _typeObject;
        public Type TypeObject
        {
            get => _typeObject;
            set
            {
                SetProperty(ref _typeObject, value);
                GenerateFields();
            }
        }

        private IEnumerable<FormFieldViewModel> _fields;
        public IEnumerable<FormFieldViewModel> Fields
        {
            get => _fields;
            private set => SetProperty(ref _fields, value);
        }

        #endregion PROPRIEDADES

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
            var field = new FormFieldViewModel()
            {
                Label = FormatPropertyLabelHelper.GetPropertyLabel(prop),
                PropertyName = prop.Name,
                PropertyType = prop.PropertyType,
                ValidationRules = GetValidationRules(prop),

                IsReadOnly = false, //Mode == FormMode.View, //chamar helper (a criar) que define, com base no modo do form e atributos, se o campo será readonly
                Value = prop.GetValue(SourceObject)
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

        #endregion GERAÇÃO CAMPOS

        #region CONSTRUTORES

        public CommonFormViewModel(string titulo, FormMode estado, object objeto, DbContext contexto, bool autoGenerateFields)
        {
            if (estado == FormMode.Create)
                throw new ArgumentException("O estado 'Create' não deve ser usado com um objeto fonte.");

            Titulo = titulo;
            Mode = estado;
            SourceObject = objeto;
            CreateEntityBase(contexto);

            if (autoGenerateFields) GenerateFields();
            //if (estado == FormMode.Edit) CreateSaveButton();
        }

        public CommonFormViewModel(string titulo, ITabela tabelaReferencia, bool autoGenerateFields)
        {
            Titulo = titulo;
            Mode = FormMode.Create;

            SourceObject = Activator.CreateInstance(tabelaReferencia.ModelType) ?? 
                            throw new InvalidOperationException($"Não foi possível criar uma instância de {tabelaReferencia.ModelType.FullName}.");

            CreateEntityBase(new TaniaDecoracoesDbContext());

            if (autoGenerateFields) GenerateFields();
            SaveCommand = new RelayCommand(() =>
            {
                var saveMethod = _entityBase.GetType().GetMethod("Save");
                saveMethod?.Invoke(_entityBase, [SourceObject]);
            });
            //CreateSaveButton();
        }

        private void CreateEntityBase(DbContext context)
        {
            var entityBaseType = typeof(EntityBase<>).MakeGenericType(TypeObject);
            var entity = Activator.CreateInstance(entityBaseType, context);

            if (entity == null)
                throw new InvalidOperationException($"Não foi possível criar uma instância de EntityBase para o tipo {entityBaseType} do EntityBase do Grid.");

            _entityBase = entity;
        }

        #endregion CONSTRUTORES
    }

    public enum FormMode
    {
        View,
        Edit,
        Create
    }
}
