using System.Windows.Input;
using System.Windows.Media;

namespace TaniaDecoracoes.WPFLibrary.Utils.GridUtils
{
    public class CustomGridButton
    {
        public string Conteudo { get; set; }
        public string? Icone { get; set; }

        public Color Foreground { get; set; }
        public Color MouseOverForeground { get; set; }
        public Color PressedForeground { get; set; }

        public Color Background { get; set; }
        public Color MouseOverBackground { get; set; }
        public Color PressedBackground { get; set; }

        public ICommand Comando { get; set; }
        public int Ordem; 
    }
}