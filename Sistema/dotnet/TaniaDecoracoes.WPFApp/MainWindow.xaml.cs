using System.Windows;
using System.Windows.Controls;
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
            var viewModel = new MainWindowViewModel();
            this.DataContext = viewModel;

            viewModel.RequestClose += (s, e) => Close();
            viewModel.RequestWindowStateChange += (s, state) => this.WindowState = state;
            viewModel.WindowState = this.WindowState;

            this.StateChanged += (s, e) => viewModel.WindowState = this.WindowState;
            InitializeComponent();
        }

        public void NavegarPara(Page page)
        {
            frmModulos.Navigate(page);
        }

    }
}