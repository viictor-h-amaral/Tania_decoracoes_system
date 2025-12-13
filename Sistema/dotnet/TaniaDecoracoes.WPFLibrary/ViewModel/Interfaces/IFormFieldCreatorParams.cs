using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces
{
    public interface IFormFieldCreatorParams
    {
        public PropertyInfo Property { get; set; }
        public IEntityModel SourceObject { get; set; }
    }
}
