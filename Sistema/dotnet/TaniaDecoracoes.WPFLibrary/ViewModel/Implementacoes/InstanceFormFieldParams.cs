using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.Implementacoes
{
    public class InstanceFormFieldParams : IFormFieldCreatorParams
    {
        public PropertyInfo Property { get; set; }
        public IEntityModel SourceObject { get; set; }
        public int? IdValue { get; set; }

        public InstanceFormFieldParams(PropertyInfo prop, IEntityModel model, int? idValue) 
        { 
            Property = prop;
            SourceObject = model;
            IdValue = idValue;
        }
    }
}
