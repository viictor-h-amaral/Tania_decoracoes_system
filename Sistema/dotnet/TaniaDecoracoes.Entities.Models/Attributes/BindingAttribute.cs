using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class BindingAttribute : Attribute
    {
        public string FieldToBringFromInstance { get; }
        public BindingAttribute(string fieldName)
        {
            FieldToBringFromInstance = fieldName;
        }
    }
}
