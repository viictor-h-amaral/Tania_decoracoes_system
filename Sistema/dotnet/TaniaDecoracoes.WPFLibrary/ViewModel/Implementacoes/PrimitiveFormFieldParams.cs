using System.Reflection;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.Implementacoes
{
    public class PrimitiveFormFieldParams : IFormFieldCreatorParams
    {
        public PropertyInfo Property { get; set; }
        public IEntityModel SourceObject { get; set; }

        public PrimitiveFormFieldParams(PropertyInfo property, IEntityModel sourceObject)
        {
            Property = property;
            SourceObject = sourceObject;
        }
    }
}
