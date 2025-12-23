using System.Windows;
using System.Windows.Media;
using System.Windows.Shell;

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
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.AllowsTransparency = true;
            this.Background = Brushes.Transparent;

            this.Style = (Style)_resourceWindowStyleDictionary["FormWindow"];

            var chrome = new WindowChrome
            {
                CornerRadius = new CornerRadius(20),
                GlassFrameThickness = new Thickness(0),
                ResizeBorderThickness = new Thickness(0),
                CaptionHeight = 0
            };

            WindowChrome.SetWindowChrome(this, chrome);
        }
    }
}
