using System.Windows;
using System.Windows.Input;
using System.Linq;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoMenu
{
    public class ItemViewModel : ViewModelBase
    {
        public int Camada { get; set; }
        public Thickness Margin => new Thickness(5 * Camada);

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
            set 
            {
                foreach (var item in value ?? [])
                {
                    item.Camada = Camada + 1;
                }
                _subItens = value;
            } 
        }

        private ICommand? _comando;
        public ICommand? Comando
        {
            get => _comando;
            set => _comando = value;
        }
    }
}
