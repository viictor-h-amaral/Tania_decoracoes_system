using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Data;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.EntitiesLibrary;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
// Para EF Core, use: entity.GetType().BaseType

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class InstanceFormFieldViewModel<T> : ViewModelBase, IFormFieldViewModel where T : class, IEntityModel
    {
        private  IEntityBase<T> _entityBase;
        public object SourceObject { get; set; }

        public PropertyInfo Property { get; set; }

        private T? GetPropValue()
        {
            return Property.GetValue(SourceObject) as T;
            /*var bindingAttr = Property.GetCustomAttribute<BindingAttribute>();

            var result = bindingAttr != null
                ? Property.GetValue(SourceObject)?.GetType().GetProperty(
                    bindingAttr.FieldToBringFromInstance)?.GetValue(
                        Property.GetValue(SourceObject))
                : Property.GetValue(SourceObject);
            return result;*/
        }

        private void SetPropValue(DataTransfer? value)
        {
            int valueId = 0;
            if (value != null) valueId = value.Id;
            var newObj = _entityBase.FirstOrDefault(x => x.Id == valueId);
            Property.SetValue(SourceObject, newObj);
        }

        public DataTransfer? Value
        {
            get
            {
                var propValue = GetPropValue();
                if (propValue is null) return null;
                var result = new DataTransfer()
                {
                    Id = propValue.Id,
                    Identificacao = propValue.GetType().GetProperty(InstanceObjectsDisplayProperty)?.GetValue(propValue) ?? ""
                };
                return result;
            }
            set
            {
                SetPropValue(value);
                OnPropertyChanged();
            }
        }

        public string InstanceObjectsDisplayProperty
        {
            get
            {
                var bindingAttr = Property.GetCustomAttribute<BindingAttribute>();
                if (bindingAttr == null)
                    return "";
                return bindingAttr.FieldToBringFromInstance;
            }
        }

        private ObservableCollection<DataTransfer>? _instanceValues = new ObservableCollection<DataTransfer>();

        public ObservableCollection<DataTransfer>? InstanceValues
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

        object? IFormFieldViewModel.Value { get => Value; set => throw new Exception("a_a"); }

        public InstanceFormFieldViewModel(PropertyInfo prop, IEntityModel sourceObject, int? valueId)
        {
            Property = prop;
            SourceObject = sourceObject;
            var context = new TaniaDecoracoesDbContext();
            _entityBase = new EntityBase<T>(context);

            var objs = _entityBase.GetMany();

            InstanceValues = new ObservableCollection<DataTransfer>(
                    objs?.Select(x => 
                        new DataTransfer() { 
                            Id = x.Id, 
                            Identificacao = x.GetType().GetProperty(InstanceObjectsDisplayProperty)?.GetValue(x) ?? "" }).ToList()
                    ?? [new DataTransfer() { Id=0, Identificacao = "Nenhum item"}]);

            //Value = InstanceValues?.FirstOrDefault(x => x.Id == valueId);

            /*var x = objs?.FirstOrDefault(x => x.Id == valueId);
            if (x != null)
            {
                var Value = new DataTransfer() { Id = x.Id, Identificacao = x.GetType().GetProperty(InstanceObjectsDisplayProperty)?.GetValue(x) ?? "" };
            }*/


        }

        #endregion CONSTRUTORES

        public class DataTransfer : IEntityModel
        {
            public DataTransfer(int id, object identificacao)
            {
                Id = id;
                Identificacao = identificacao;
            }

            public DataTransfer() { }

            public int Id { get; set; }
            public required object Identificacao { get; set; }
        }
    }
}
