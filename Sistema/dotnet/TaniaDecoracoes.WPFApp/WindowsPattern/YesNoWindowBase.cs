using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;
using TaniaDecoracoes.WPFApp.Utils;

namespace TaniaDecoracoes.WPFApp.WindowsPattern
{
    internal class YesNoWindowBase : Window
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

        private readonly ResourceDictionary _resourceDictionary;

        public static readonly DependencyProperty NoButtonStyleProperty =
            DependencyProperty.Register("NoButtonStyle", typeof(Style), typeof(YesNoWindowBase),
            new PropertyMetadata((Style)Application.Current.Resources["btnStyleNegative"]));

        // Propriedade para alternar entre estilos
        public static readonly DependencyProperty UseAlternativeNoButtonStyleProperty =
            DependencyProperty.Register("UseAlternativeNoButtonStyle", typeof(bool), typeof(YesNoWindowBase),
            new PropertyMetadata(false, OnUseAlternativeStyleChanged));

        private static void OnUseAlternativeStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = (YesNoWindowBase)d;
            window.NoButtonStyle = (bool)e.NewValue ?
                (Style)window._resourceDictionary["btnStyleNeutral"]
                : (Style)window._resourceDictionary["btnStyleNegative"];
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
            SizeToContent = SizeToContent.WidthAndHeight;

            var chrome = new WindowChrome
            {
                CornerRadius = new CornerRadius(20),
                GlassFrameThickness = new Thickness(-1),
                ResizeBorderThickness = new Thickness(0),
                CaptionHeight = 0
            };

            WindowChrome.SetWindowChrome(this, chrome);

            _resourceDictionary = new ResourceDictionary
            {
                Source = new Uri("/TaniaDecoracoes.WPFApp;component/Styles/ConfirmationButtonStyle.xaml", UriKind.Relative)
            };

        }
    }
}
