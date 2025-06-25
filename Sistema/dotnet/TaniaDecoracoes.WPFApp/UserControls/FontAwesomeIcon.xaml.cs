using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaniaDecoracoes.WPFApp.UserControls
{
    /// <summary>
    /// Interação lógica para FontAwesomeIcon.xam
    /// </summary>
    public partial class FontAwesomeIcon : UserControl
    {
        public FontAwesomeIcon()
        {
            InitializeComponent();
        }
        
        public static readonly DependencyProperty IconCodeProperty =
            DependencyProperty.Register("IconCode", typeof(string), typeof(FontAwesomeIcon), new PropertyMetadata(""));

        public string IconCode
        {
            get { return (string)GetValue(IconCodeProperty); }
            set { SetValue(IconCodeProperty, value); }
        }
    }
}
