using System.Windows;
using System.Windows.Controls;
using TaniaDecoracoes.WPFApp.ViewModel.Pages.Clientes;

namespace TaniaDecoracoes.WPFApp.Pages.Clientes
{
    /// <summary>
    /// Interação lógica para ClientesMainPage.xam
    /// </summary>
    public partial class ClientesMainPage : Page
    {
        public ClientesMainPage()
        {
            InitializeComponent();

            var vm = new ClientesMainPageViewModel();
            this.DataContext = vm;

            vm.OnNavegarParaDependentes += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.DependentesClientesPage);
            };

            vm.OnNavegarParaEnderecos += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.EnderecosClientesPage);
            };
        }
    }
}
