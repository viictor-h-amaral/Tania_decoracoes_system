using System.Windows.Controls;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;

namespace TaniaDecoracoes.WPFLibrary.UserControls
{
    /// <summary>
    /// Interação lógica para MenuModulos.xam
    /// </summary>
    public partial class MenuModulos : UserControl
    {
        public MenuModulos()
        {
            InitializeComponent();
            var vm = new MenuModulosViewModel();
            this.DataContext = vm;
        }

        private void TrocaModulo(object sender, System.Windows.RoutedEventArgs e)
        {
            var botao = (Button)sender;
            var novaPagina = botao.Tag as Page;
            var stackpanel = botao.Parent;
        }
    }
}
