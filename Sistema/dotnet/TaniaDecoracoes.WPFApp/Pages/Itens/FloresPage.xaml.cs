using System.Windows.Controls;
using TaniaDecoracoes.WPFApp.ViewModel.Pages.Itens;

namespace TaniaDecoracoes.WPFApp.Pages.Itens
{
    /// <summary>
    /// Interação lógica para FloresPage.xam
    /// </summary>
    public partial class FloresPage : Page
    {
        public FloresPage()
        {
            InitializeComponent();

            var vm = new FloresPageViewModel();
            this.DataContext = vm;
        }
    }
}
