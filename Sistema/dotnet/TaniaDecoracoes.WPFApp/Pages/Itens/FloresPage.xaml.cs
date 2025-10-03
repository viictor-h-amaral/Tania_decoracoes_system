using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
