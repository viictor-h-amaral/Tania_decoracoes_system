using System.Windows;
using System.Windows.Controls;

namespace TaniaDecoracoes.WPFLibrary.UserControls
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
