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
using TaniaDecoracoes.WPFApp.ViewModel.Pages.Clientes;
using TaniaDecoracoes.WPFApp.ViewModel.Pages.Enderecos;

namespace TaniaDecoracoes.WPFApp.Pages.Enderecos
{
    /// <summary>
    /// Interação lógica para EnderecosClientesPage.xam
    /// </summary>
    public partial class EnderecosClientesPage : Page
    {
        public EnderecosClientesPage()
        {
            InitializeComponent();

            var vm = new EnderecosClientesPageViewModel();
            this.DataContext = vm;
        }
    }
}
