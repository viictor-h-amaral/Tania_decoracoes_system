using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TaniaDecoracoes.WPFApp.Pages.Clientes;
using TaniaDecoracoes.WPFApp.Pages.Decoracoes;
using TaniaDecoracoes.WPFApp.Pages.Enderecos;

namespace TaniaDecoracoes.WPFApp.Pages
{
    public abstract class PagesLink
    {
        public static Page HomePage => new HomePage();
        public static Page DecoracoesMainPage => new DecoracoesMainPage();
        public static Page TiposEventosPage => new TiposEventosPage();
        public static Page ClientesMainPage => new ClientesMainPage();
        public static Page DependentesClientesPage => new DependentesClientesPage();
        public static Page EnderecosClientesPage => new EnderecosClientesPage();
        public static Page TiposEnderecosClientesPage => new TiposEnderecosClientesPage();
        public static Page TemasAniversariosPage => new TemasAniversariosPage();
        public static Page LogradourosPage => new LogradourosPage();
        public static Page TiposLogradourosPage => new TiposLogradourosPage();
        public static Page BairrosPage => new BairrosPage();
        public static Page MunicipiosPage => new MunicipiosPage();
        public static Page EstadosPage => new EstadosPage();
        public static Page EnderecosEventosPage => new EnderecosEventosPage();
        public static Page TiposEnderecosEventosPage => new TiposEnderecosEventosPage();
    }
}
