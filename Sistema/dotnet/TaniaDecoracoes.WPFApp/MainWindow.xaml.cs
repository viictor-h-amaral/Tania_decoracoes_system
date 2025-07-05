using System.Windows;
using TaniaDecoracoes.WPFApp.ViewModel;
using TaniaDecoracoes.WPFLibrary.ViewModel.Windows;
using TaniaDecoracoes.WPFLibrary.WindowsPattern;

namespace TaniaDecoracoes.WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainWindowViewModel();
            viewModel.RequestClose += (s, e) => Close();
            viewModel.RequestWindowStateChange += (s, state) => this.WindowState = state;

            this.DataContext = viewModel;

            viewModel.WindowState = this.WindowState;
            this.StateChanged += (s, e) => viewModel.WindowState = this.WindowState;
        }

    }
}