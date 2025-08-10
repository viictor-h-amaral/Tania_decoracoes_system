using System.Windows;
using System.Windows.Input;
using TaniaDecoracoes.WPFLibrary.Utils;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.Windows
{
    public class YesNoWindowViewModel : ViewModelBase
    {
        public event Action<bool?> RequestClose;

        public string QuestionText { get; set; }
        public string YesButtonText { get; set; } = "Sim";
        public string NoButtonText { get; set; } = "Não";

        private bool _useAlternativeStyle;
        public bool UseAlternativeNoButtonStyle {
            get => _useAlternativeStyle;
            set 
            { 
                SetProperty(ref _useAlternativeStyle, value);
                NoButtonStyle = _useAlternativeStyle ?
                    (Style)_resourceDictionary["btnStyleNeutral"] :
                    (Style)_resourceDictionary["btnStyleNegative"];
            }
        }

        private Style _noButtonStyle = (Style)_resourceDictionary["btnStyleNegative"];
        public Style NoButtonStyle
        {
            get => _noButtonStyle;
            set
            {
                SetProperty(ref _noButtonStyle, value);
                OnPropertyChanged();
            }
        }

        private static readonly ResourceDictionary _resourceDictionary = new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/TaniaDecoracoes.WPFLibrary;component/Styles/Buttons/ConfirmationButtonStyle.xaml", UriKind.Absolute)
        };

        public ICommand YesCommand { get; }
        public ICommand NoCommand { get; }

        public YesNoWindowViewModel()
        {
            YesCommand = new RelayCommand(() => RequestClose?.Invoke(true));
            NoCommand = new RelayCommand(() => RequestClose?.Invoke(false));
        }
    }
}