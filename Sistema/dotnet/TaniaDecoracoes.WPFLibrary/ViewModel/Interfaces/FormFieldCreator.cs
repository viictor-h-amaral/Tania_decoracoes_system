using System.Reflection;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoFormField;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces
{
    public abstract class FormFieldCreator
    {
        public FormFieldCreator() { }

        public abstract IFormFieldViewModel CreateFormField(IFormFieldCreatorParams parametros);
    }
}
