using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Decoracoes.Tabelas
{
    public class DecoracaoTabela : ITabela
    {
        public string NameInDataBase => "dec_decoracoes";

        public Type ModelType => typeof(Decoracao);
    }
}
