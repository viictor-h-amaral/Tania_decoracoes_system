using System.Windows;

namespace TaniaDecoracoes.WPFApp.WindowsPattern.DialogWindows
{
    /// <summary>
    /// Lógica interna para FecharAplicacao.xaml
    /// </summary>
    public partial class FecharAplicacao : Window
    {
        private bool _fechar = false;
        public bool Fechar
        {
            get { return _fechar; }
            set { _fechar = value; }
        }

        public FecharAplicacao(Window parent)
        {
            this.Owner = parent;
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            Fechar = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Fechar = false;
            this.Close();
        }
    }
}
