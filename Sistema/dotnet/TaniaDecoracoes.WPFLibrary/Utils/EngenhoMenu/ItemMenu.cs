using System.Windows.Input;

namespace TaniaDecoracoes.WPFLibrary.Utils.EngenhoMenu
{
    public class ItemMenu
    {
        private string titulo = "título";
        public string Titulo 
        { 
            get => titulo;
            set => titulo = value;
        }

        private IEnumerable<ItemMenu>? _subItens;
        public IEnumerable<ItemMenu>? SubItens 
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
