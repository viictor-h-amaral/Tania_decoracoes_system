using System.Windows.Input;
using System.Windows.Media;

namespace TaniaDecoracoes.WPFLibrary.Utils.GridUtils
{
    public class CustomGridButton
    {
        public string Conteudo = string.Empty;
        public string? Icone;

        public Color Foreground;
        public Color MouseOverForeground;
        public Color PressedForeground;

        public Color Background;
        public Color MouseOverBackground;
        public Color PressedBackground;

        public ICommand Comando;
        public int Ordem; 
    }
}