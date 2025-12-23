using System.Collections.ObjectModel;
using System.Reflection;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.EntitiesLibrary;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoFormField;

public class InstanceFormFieldViewModel<T> : ViewModelBase, IFormFieldViewModel where T : class, IEntityModel
{
    private IEntityBase<T> _entityBase;
    public object SourceObject { get; set; }
    public PropertyInfo Property { get; set; }

    private int? GetPropId()
    {
        var fkPropertyName = Property.Name.EndsWith("Instance")
                ? Property.Name.Replace("Instance", "Id")
                : Property.Name + "Id";

        var fkProperty = SourceObject.GetType().GetProperty(fkPropertyName);
        if (fkProperty == null) return null;

        var id = fkProperty.GetValue(SourceObject) as int?;
        if (!id.HasValue || id.Value <= 0) return null;

        return id.Value;
    }

    private T? GetPropValue()
    {
        return Property.GetValue(SourceObject) as T;
    }

    private void SetPropValue(DataTransfer? value)
    {
        if (value == null)
        {
            Property.SetValue(SourceObject, null);
            return;
        }

        var selectedObj_a = InstanceValues?
            .FirstOrDefault(x => x.Id == value.Id);
        var selectedObj = selectedObj_a?.OriginalObject;

        if (selectedObj != null)
        {
            Property.SetValue(SourceObject, selectedObj);
        }
    }

    public DataTransfer? Value
    {
        get
        {
            if (GetPropId() is int id)
            {
                return InstanceValues?
                    .FirstOrDefault(x => x.Id == id);
            }
            else
                return null;
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
            return bindingAttr?.FieldToBringFromInstance ?? "Nome"; // Valor padrão
        }
    }

    private ObservableCollection<DataTransfer>? _instanceValues = new ObservableCollection<DataTransfer>();

    public ObservableCollection<DataTransfer>? InstanceValues
    {
        get => _instanceValues;
        set
        {
            SetProperty(ref _instanceValues, value);
            // Atualizar a seleção quando a lista for carregada
            OnPropertyChanged(nameof(Value));
        }
    }

    public string Label { get; set; }

    private bool _isReadOnly;
    public bool IsReadOnly
    {
        get => _isReadOnly;
        set => SetProperty(ref _isReadOnly, value);
    }

    public bool IsEnabled
    {
        get => !_isReadOnly;
        set => SetProperty(ref _isReadOnly, !value);
    }

    object? IFormFieldViewModel.Value
    {
        get => Value;
        set
        {
            if (value is DataTransfer dataTransfer)
                Value = dataTransfer;
        }
    }

    public InstanceFormFieldViewModel(PropertyInfo prop, IEntityModel sourceObject, int? valueId)
    {
        Property = prop;
        var context = new TaniaDecoracoesDbContext();
        _entityBase = new EntityBase<T>(context);
        SourceObject = sourceObject;

        CarregarInstancias(valueId);
    }

    private void CarregarInstancias(int? valueId)
    {
        var objs = _entityBase.GetManyWithNoTracking();

        // Criar lista de DataTransfer mantendo referência aos objetos originais
        var dataTransfers = objs?.Select(x =>
            new DataTransfer(x) // Passar o objeto original
            {
                Id = x.Id,
                Identificacao = x.GetType().GetProperty(InstanceObjectsDisplayProperty)?.GetValue(x)?.ToString() ?? "Sem nome"
            }).ToList() ?? new List<DataTransfer>();

        InstanceValues = new ObservableCollection<DataTransfer>(dataTransfers);

        // Configurar o valor selecionado após carregar a lista
        if (valueId.HasValue && valueId.Value > 0)
        {
            if (GetPropId() is int id)
            {
                // Encontrar o DataTransfer correspondente ao objeto atual
                var selectedDataTransfer = InstanceValues
                    .FirstOrDefault(x => x.Id == id);

                if (selectedDataTransfer != null)
                {
                    Value = selectedDataTransfer;
                }
            }
        }
    }

    public class DataTransfer : IEntityModel
    {
        public T? OriginalObject { get; set; } // Manter referência ao objeto original

        public DataTransfer(T originalObject)
        {
            OriginalObject = originalObject;
            //Id = originalObject.Id;
        }

        public DataTransfer() { }

        public int Id { get; set; }
        public required object Identificacao { get; set; }

        // Conversão implícita para o tipo T
        public static implicit operator T?(DataTransfer dataTransfer) => dataTransfer.OriginalObject;
    }
}