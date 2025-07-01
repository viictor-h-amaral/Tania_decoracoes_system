using System.Windows;
using TaniaDecoracoes.WPFLibrary.WindowsPattern;

namespace TaniaDecoracoes.WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TrocarModulo()
        {

        }

        public void ModuloButton_Click(object sender, RoutedEventArgs e)
        {
            TrocarModulo();
        }
    }
}