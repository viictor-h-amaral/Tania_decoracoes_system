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
using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.TabelasGerais;
using TaniaDecoracoes.EntitiesLibrary.Entities.Associacao;
using TaniaDecoracoes.EntitiesLibrary.Entities.TabelasGerais;
using TaniaDecoracoes.WPFApp.ViewModel.Pages.Decoracoes;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;

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

            this.DataContext = new DecoracoesMainPageViewModel();

        }
    }
}
