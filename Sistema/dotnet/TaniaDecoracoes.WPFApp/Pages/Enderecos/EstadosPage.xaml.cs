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
using TaniaDecoracoes.WPFApp.ViewModel.Pages.Enderecos;

namespace TaniaDecoracoes.WPFApp.Pages.Enderecos
{
    /// <summary>
    /// Interação lógica para EstadosPage.xam
    /// </summary>
    public partial class EstadosPage : Page
    {
        public EstadosPage()
        {
            InitializeComponent();

            var vm = new EstadosPageViewModel();
            this.DataContext = vm;
        }
    }
}
