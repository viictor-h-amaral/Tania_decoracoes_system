using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TaniaDecoracoes.WPFLibrary.Utils
{
    public class DataGridColumnsUnits
    {
        public static readonly DataGridLength GridLengthAuto = new DataGridLength(1, DataGridLengthUnitType.Auto);

        public static Func<int, DataGridLength> GridLengthStars => 
            (int stars) => new DataGridLength(stars, DataGridLengthUnitType.Star);
    }
}
