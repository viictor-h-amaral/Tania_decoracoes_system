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

        private object GetPropValue()
        {
            var bindingAttr = Property.GetCustomAttribute<BindingAttribute>();

            var result = bindingAttr != null
                ? Property.GetValue(SourceObject)?.GetType().GetProperty(
                    bindingAttr.FieldToBringFromInstance)?.GetValue(
                        Property.GetValue(SourceObject))
                : Property.GetValue(SourceObject);
            return result;
        }

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

        public InstanceFormFieldViewModel(PropertyInfo prop, object sourceObject)
        {
            Property = prop;
            SourceObject = sourceObject;

            Type instanceType = Property.PropertyType;
            var context = new TaniaDecoracoesDbContext();
            _entityBase = new EntityBase<T>(context);

            // Corrigido: Use o método Set com o tipo explicitamente especificado
            /*var setMethod = typeof(TaniaDecoracoesDbContext).GetMethod("Set", Type.EmptyTypes);
            var genericSetMethod = setMethod.MakeGenericMethod(instanceType);
            var objs = ((IEnumerable<object>)genericSetMethod.Invoke(context, null)).ToList();
            objs.Insert(0, Activator.CreateInstance(instanceType)); // Adiciona uma opção vazia no início
            objs.Add(Value);*/
            // Se quiser usar os valores, atribua a InstanceValues:
            Value = prop.GetValue(sourceObject);
            // Substitua esta linha:
            // value_id = Value?.Id ?? 0;

            // Por esta linha:
            var valueId = (Value as IEntityModel)?.Id ?? 0;
            InstanceValues = new ObservableCollection<object>(_entityBase.GetMany(x => x.Id != valueId));
            if (Value is not null) InstanceValues.Add(Value);

            //var itens = _entityBase.GetMany(x => x.Id != Value.Id);
            //InstanceValues = new ObservableCollection<T>(itens ?? []);
            //InstanceValues.Add(Value);
        }

        #endregion CONSTRUTORES

    }
}
