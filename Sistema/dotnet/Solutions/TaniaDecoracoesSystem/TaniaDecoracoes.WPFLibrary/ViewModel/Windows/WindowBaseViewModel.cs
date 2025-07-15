using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.Windows;
using TaniaDecoracoes.WPFLibrary.WindowsPattern;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.Windows
{
    public class WindowBaseViewModel : ViewModelBase
    {
        public WindowBaseViewModel()
        {
            CloseWindowCommand = new RelayCommand(Fechar);
            MinimizeWindowCommand = new RelayCommand(() => RequestWindowStateChange?.Invoke(this, WindowState.Minimized));
            MaximizeNormalizeWindowCommand = new RelayCommand(MaximizarNormalizar);
        }

        private string _maximizeNormalizeContent = "☐";
        public string MaximizeNormalizeContent
        {
            get => _maximizeNormalizeContent;
            set => SetProperty(ref _maximizeNormalizeContent, value);
        }

        private WindowState _windowState;
        public WindowState WindowState
        {
            get => _windowState;
            set
            {
                if (SetProperty(ref _windowState, value))
                {
                    MaximizeNormalizeContent = ( value == WindowState.Maximized ) ? "❐" : "☐";
                }
            }
        }

        public event EventHandler RequestClose;
        public event EventHandler<WindowState> RequestWindowStateChange;

        #region ControlesJanela

        public ICommand CloseWindowCommand { get; }
        public ICommand MinimizeWindowCommand { get; }
        public ICommand MaximizeNormalizeWindowCommand { get; }

        protected void Fechar()
        {
            var dialogService = new DialogService();
            bool? dialogResult = dialogService.ShowYesNoDialog(
                questionText: "Fechar a aplicação?",
                yesButtonText: "Fechar",
                noButtonText: "Cancelar",
                useAlternativeNoButtonStyle: true
            );

            if (dialogResult ?? false)
                RequestClose?.Invoke(this, EventArgs.Empty);
        }

        protected void MaximizarNormalizar()
        {
            WindowState newWindowState = this.WindowState == WindowState.Maximized ?
                WindowState.Normal : WindowState.Maximized;

            RequestWindowStateChange?.Invoke(this, newWindowState);
        }

        #endregion ControlesJanela
    }
}