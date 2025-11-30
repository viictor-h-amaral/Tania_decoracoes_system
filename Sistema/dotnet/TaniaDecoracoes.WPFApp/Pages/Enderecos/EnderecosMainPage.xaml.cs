using System.Windows;
using System.Windows.Controls;
using TaniaDecoracoes.WPFApp.ViewModel.Pages.Enderecos;

namespace TaniaDecoracoes.WPFApp.Pages.Enderecos
{
    /// <summary>
    /// Interação lógica para EnderecosMainPage.xam
    /// </summary>
    public partial class EnderecosMainPage : Page
    {
        public EnderecosMainPage()
        {
            InitializeComponent();

            var vm = new EnderecosMainPageViewModel();
            this.DataContext = vm;

            vm.OnNavegarParaLogradouros += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.LogradourosPage);
            };

            vm.OnNavegarParaTiposLogradouros += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.TiposLogradourosPage);
            };

            vm.OnNavegarParaBairros += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.BairrosPage);
            };

            vm.OnNavegarParaMunicipios += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.MunicipiosPage);
            };

            vm.OnNavegarParaEstados += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.EstadosPage);
            };

            vm.OnNavegarParaEnderecosEventos += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.EnderecosEventosPage);
            };

            vm.OnNavegarParaTiposEnderecosEventos += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.TiposEnderecosEventosPage);
            };

            vm.OnNavegarParaEnderecosClientes += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.EnderecosClientesPage);
            };

            vm.OnNavegarParaTiposEnderecosClientes += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.TiposEnderecosClientesPage);
            };
        }
    }
}
