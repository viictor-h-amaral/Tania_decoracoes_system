using System.Windows.Input;
using System.Windows.Media;

namespace TaniaDecoracoes.WPFLibrary.Utils.GridUtils
{
    public class CustomGridButton
    {
        public string Conteudo { get; set; }
        public string? Icone { get; set; }

        public Brush Foreground { get; set; }
        public Brush Background { get; set; }

        public ICommand Comando { get; set; }
        public int Ordem; 
    }
}