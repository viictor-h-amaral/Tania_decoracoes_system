using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Decoracoes.Tabelas
{
    public class TipoEventoTabela : ITabela
    {
        public string NameInDataBase => "dec_tiposeventos";

        public Type ModelType => typeof(TipoEvento);
    }
}
