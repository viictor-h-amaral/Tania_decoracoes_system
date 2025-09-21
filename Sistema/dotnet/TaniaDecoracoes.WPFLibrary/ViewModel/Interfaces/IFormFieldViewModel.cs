using System.Reflection;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces
{
    public interface IFormFieldViewModel
    {
        PropertyInfo Property { get; set; }
        object SourceObject { get; set; }
        object? Value { get; set; }
        string Label { get; set; }
        bool IsReadOnly { get; set; }
    }
}
