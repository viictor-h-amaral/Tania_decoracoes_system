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
            /*var vm = new MenuModulosViewModel();
            this.DataContext = vm;
            trecho definindo DataContext não é aqui, mas sim ao criar esse user control no mainwindow */
        }
    }
}
