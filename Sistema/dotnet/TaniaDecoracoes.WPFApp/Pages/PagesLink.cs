using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TaniaDecoracoes.WPFApp.Pages.Decoracoes;

namespace TaniaDecoracoes.WPFApp.Pages
{
    public abstract class PagesLink
    {
        public static Page HomePage => new HomePage();
        public static Page DecoracoesMainPage => new DecoracoesMainPage();
        public static Page TiposEventosPage => new TiposEventosPage();
    }
}
