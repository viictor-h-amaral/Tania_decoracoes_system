using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Attributes;

namespace TaniaDecoracoes.WPFLibrary.Utils
{
    public class FormatPropertyLabelHelper
    {
        public static string GetPropertyLabel(PropertyInfo prop)
        {
            var displayAttr = prop.GetCustomAttribute<TitleAttribute>();

            if (displayAttr is null || displayAttr.Title is null)
                return FormatPropertyName(prop.Name);

            return displayAttr.Title;
        }

        private static string FormatPropertyName(string propertyName)
        {
            propertyName = propertyName.Replace("Instance", "");
            var formatted = System.Text.RegularExpressions.Regex.Replace(propertyName, "([a-z])([A-Z])", "$1 $2");

            formatted = formatted.ToLower();
            formatted = char.ToUpper(formatted[0]) + formatted.Substring(1);

            return formatted;
        }

    }
}
