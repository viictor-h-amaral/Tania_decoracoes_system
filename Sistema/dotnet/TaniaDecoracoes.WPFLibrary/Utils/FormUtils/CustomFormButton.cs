using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace TaniaDecoracoes.WPFLibrary.Utils.FormUtils
{
    public class CustomFormButton
    {
        public string Conteudo { get; set; }
        public string? Icone { get; set; }

        public Brush Foreground { get; set; }
        public Brush Background { get; set; }

        public ICommand Comando { get; set; }
        public int Ordem;
    }
}
