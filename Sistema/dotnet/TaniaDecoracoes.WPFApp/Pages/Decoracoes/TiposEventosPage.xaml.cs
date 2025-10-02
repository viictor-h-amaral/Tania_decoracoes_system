using System.Windows.Controls;
using TaniaDecoracoes.WPFApp.ViewModel.Pages.Decoracoes;

namespace TaniaDecoracoes.WPFApp.Pages.Decoracoes
{
    /// <summary>
    /// Interação lógica para TiposEventosPage.xam
    /// </summary>
    public partial class TiposEventosPage : Page
    {
        public TiposEventosPage()
        {
            InitializeComponent();

            var vm = new TiposEventosPageViewModel();
            this.DataContext = vm;
        }
    }
}
