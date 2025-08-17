using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TaniaDecoracoes.Entities.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class TitleAttribute : Attribute
    {   
        public string? Title { get; set; }
        public bool AutoRename { get; set; }
        public TitleAttribute(string title)
        {
            AutoRename = false;
            Title = title;
        }
        public TitleAttribute()
        {
            AutoRename = true;
        }
    }
}
