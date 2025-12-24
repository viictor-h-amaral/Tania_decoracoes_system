using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TaniaDecoracoes.WPFLibrary.Utils.Converters
{
    public class DateTimeToDateOnlyConverter : IValueConverter
    {
        //para datetime
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateOnly dateOnly)
            {
                return new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);
            }

            return DateTime.Now;
        }

        //para dateonly
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return DateOnly.FromDateTime(dateTime);
            }

            return DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
