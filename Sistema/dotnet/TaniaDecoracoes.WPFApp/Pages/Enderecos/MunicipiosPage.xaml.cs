using System.Windows.Controls;
using TaniaDecoracoes.WPFApp.ViewModel.Pages.Enderecos;

namespace TaniaDecoracoes.WPFApp.Pages.Enderecos
{
    /// <summary>
    /// Interação lógica para MunicipiosPage.xam
    /// </summary>
    public partial class MunicipiosPage : Page
    {
        public MunicipiosPage()
        {
            InitializeComponent();

            var vm = new MunicipiosPageViewModel();
            this.DataContext = vm;
        }
    }
}
