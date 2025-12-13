using System.Reflection;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoFormField;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.Implementacoes
{
    public class InstanceFormFieldCreator<T> : FormFieldCreator where T : class, IEntityModel
    {
        public InstanceFormFieldCreator()
        {
        }

        public override IFormFieldViewModel CreateFormField(IFormFieldCreatorParams param)
        {
            if (param is InstanceFormFieldParams instanceFormFieldParam)
            {
                return new InstanceFormFieldViewModel<T>(instanceFormFieldParam.Property, instanceFormFieldParam.SourceObject, instanceFormFieldParam.IdValue);
            }

            throw new Exception("Parâmetro para criação de campo do formulário deve ser InstanceFormFieldParams.");
        }
    }
}
