using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public MainWindow()
        {
            InitializeComponent();
        }

        private List<Estado> _listaItens;

        public List<Estado> ListaItens
        {
            get { return _listaItens; }
            set { _listaItens = value; }
        }


        private void btnCarregar_Click(object sender, RoutedEventArgs e)
        {
            _listaItens = new List<Estado>();

            using (var cxt = new TaniaDecoracoesDbContext())
            {
                DataGrid.ItemsSource = cxt.Estados.ToList();
            }
        }
    }
}