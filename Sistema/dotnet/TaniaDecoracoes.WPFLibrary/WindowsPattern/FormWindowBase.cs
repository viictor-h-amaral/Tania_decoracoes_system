using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;
using TaniaDecoracoes.WPFLibrary.Utils;

namespace TaniaDecoracoes.WPFLibrary.WindowsPattern
{
    public class FormWindowBase : Window
    {
        private static readonly ResourceDictionary _resourceWindowStyleDictionary = new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/TaniaDecoracoes.WPFLibrary;component/Styles/Windows/FormWindow.xaml", UriKind.Absolute)
        };

        public FormWindowBase()
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Height = 700;
            this.Width = 500;

            this.Style = (Style)_resourceWindowStyleDictionary["FormWindow"];

            var chrome = new WindowChrome
            {
                CornerRadius = new CornerRadius(20),
                GlassFrameThickness = new Thickness(-1),
                ResizeBorderThickness = new Thickness(0),
                CaptionHeight = 0
            };

            WindowChrome.SetWindowChrome(this, chrome);
        }
    }
}
