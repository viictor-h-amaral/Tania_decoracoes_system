using System.Windows;

namespace TaniaDecoracoes.WPFApp.WindowsPattern.DialogWindows
{
    /// <summary>
    /// Lógica interna para FecharAplicacao.xaml
    /// </summary>
    public partial class FecharAplicacao : Window
    {
        public FecharAplicacao(Window parent)
        {
            this.Owner = parent;
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
