using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.WindowsPattern;

namespace TaniaDecoracoes.WPFLibrary.WindowsPattern
{
    public class YesNoWindowBase : Window
    {

        #region Conteudos

        public static readonly DependencyProperty QuestionTextProperty =
        DependencyProperty.Register("QuestionText", typeof(string), typeof(YesNoWindowBase));

        public static readonly DependencyProperty YesButtonTextProperty =
            DependencyProperty.Register("YesButtonText", typeof(string), typeof(YesNoWindowBase),
            new PropertyMetadata("Sim"));

        public static readonly DependencyProperty NoButtonTextProperty =
            DependencyProperty.Register("NoButtonText", typeof(string), typeof(YesNoWindowBase),
            new PropertyMetadata("Não"));

        public string QuestionText
        {
            get => (string)GetValue(QuestionTextProperty);
            set => SetValue(QuestionTextProperty, value);
        }

        public string YesButtonText
        {
            get => (string)GetValue(YesButtonTextProperty);
            set => SetValue(YesButtonTextProperty, value);
        }

        public string NoButtonText
        {
            get => (string)GetValue(NoButtonTextProperty);
            set => SetValue(NoButtonTextProperty, value);
        }

        #endregion Conteudos

        #region Style

        private static readonly ResourceDictionary _resourceDictionary = new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/TaniaDecoracoes.WPFLibrary;component/Styles/ConfirmationButtonStyle.xaml", UriKind.Absolute)
        };

        private static readonly ResourceDictionary _resourceWindowStyleDictionary = new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/TaniaDecoracoes.WPFLibrary;component/Styles/Windows/YesNoWindowStyle.xaml", UriKind.Absolute)
        };

        public static readonly DependencyProperty NoButtonStyleProperty =
            DependencyProperty.Register("NoButtonStyle", typeof(Style), typeof(YesNoWindowBase),
            new PropertyMetadata((Style)_resourceDictionary["btnStyleNegative"]));

        // Propriedade para alternar entre estilos
        public static readonly DependencyProperty UseAlternativeNoButtonStyleProperty =
            DependencyProperty.Register("UseAlternativeNoButtonStyle", typeof(bool), typeof(YesNoWindowBase),
            new PropertyMetadata(false, OnUseAlternativeStyleChanged));

        private static void OnUseAlternativeStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = (YesNoWindowBase)d;
            window.NoButtonStyle = (bool)e.NewValue ?
                (Style)_resourceDictionary["btnStyleNeutral"]
                : (Style)_resourceDictionary["btnStyleNegative"];
        }

        public bool UseAlternativeNoButtonStyle
        {
            get => (bool)GetValue(UseAlternativeNoButtonStyleProperty);
            set => SetValue(UseAlternativeNoButtonStyleProperty, value);
        }

        public Style NoButtonStyle
        {
            get => (Style)GetValue(NoButtonStyleProperty);
            set => SetValue(NoButtonStyleProperty, value);
        }

        #endregion Style

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
