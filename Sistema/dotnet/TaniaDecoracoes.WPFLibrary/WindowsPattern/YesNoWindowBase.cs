using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.WindowsPattern;

namespace TaniaDecoracoes.WPFLibrary.WindowsPattern
{
    public class YesNoWindowBase : Window
    {
        private static readonly ResourceDictionary _resourceWindowStyleDictionary = new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/TaniaDecoracoes.WPFLibrary;component/Styles/Windows/YesNoWindowStyle.xaml", UriKind.Absolute)
        };

        public ICommand YesCommand { get; }
        public ICommand NoCommand { get; }

        public YesNoWindowBase()
        {
            YesCommand = new RelayCommand(() => DialogResult = true);
            NoCommand = new RelayCommand(() => DialogResult = false);

            // Configurações padrão
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            Height = 300;
            Width = 400;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Style = (Style)_resourceWindowStyleDictionary["YesNoWindow"];

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
