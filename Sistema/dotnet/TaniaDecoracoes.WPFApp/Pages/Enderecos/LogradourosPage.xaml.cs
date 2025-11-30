using System.Windows.Controls;
using TaniaDecoracoes.WPFApp.ViewModel.Pages.Enderecos;

namespace TaniaDecoracoes.WPFApp.Pages.Enderecos
{
    /// <summary>
    /// Interação lógica para LogradourosPage.xam
    /// </summary>
    public partial class LogradourosPage : Page
    {
        public LogradourosPage()
        {
            InitializeComponent();

            var vm = new LogradourosPageViewModel();
            this.DataContext = vm;
        }
    }
}
