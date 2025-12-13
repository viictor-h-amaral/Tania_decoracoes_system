using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoFormField;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.Implementacoes
{
    public class PrimitiveFormFieldCreator<T> : FormFieldCreator
    {
        public override IFormFieldViewModel CreateFormField(IFormFieldCreatorParams param)
        {
            if (param is PrimitiveFormFieldParams primitiveFormFieldParam)
            {
                return new FormFieldViewModel<T>(primitiveFormFieldParam.Property, primitiveFormFieldParam.SourceObject);
            }

            throw new Exception("Parâmetro para criação de campo do formulário deve ser PrimitiveFormFieldParams.");
        }
    }
}
