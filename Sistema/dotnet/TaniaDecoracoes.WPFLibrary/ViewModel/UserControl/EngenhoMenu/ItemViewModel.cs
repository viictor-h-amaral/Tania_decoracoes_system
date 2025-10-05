using System.Windows.Input;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoMenu
{
    public class ItemViewModel : ViewModelBase
    {
        private string titulo = "título";
        public string Titulo
        {
            get => titulo;
            set => titulo = value;
        }

        private IEnumerable<ItemViewModel>? _subItens;
        public IEnumerable<ItemViewModel>? SubItens
        {
            get => _subItens;
            set => _subItens = value;
        }

        private ICommand? _comando;
        public ICommand? Comando
        {
            get => _comando;
            set => _comando = value;
        }
    }
}
