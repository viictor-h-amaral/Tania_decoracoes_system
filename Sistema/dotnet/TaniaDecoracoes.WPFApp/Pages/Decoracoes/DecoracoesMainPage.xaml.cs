using System.Windows;
using System.Windows.Controls;
using TaniaDecoracoes.WPFApp.ViewModel.Pages.Decoracoes;

namespace TaniaDecoracoes.WPFApp.Pages.Decoracoes
{
    /// <summary>
    /// Interação lógica para DecoracoesMainPage.xam
    /// </summary>
    public partial class DecoracoesMainPage : Page
    {
        public DecoracoesMainPage()
        {
            InitializeComponent();

            var vm = new DecoracoesMainPageViewModel();
            this.DataContext = vm;

            vm.OnNavegarParaTiposEventos += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.TiposEventosPage);
            };

            vm.OnNavegarParaTemasAniversarios += () =>
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.NavegarPara(PagesLink.TemasAniversariosPage);
            };
        }
    }
}
