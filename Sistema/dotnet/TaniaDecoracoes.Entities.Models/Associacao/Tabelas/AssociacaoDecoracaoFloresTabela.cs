using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Associacao.Tabelas
{
    public class AssociacaoDecoracaoFloresTabela : ITabela
    {
        public string NameInDataBase => "assoc_decoracoes_flores";

        public Type ModelType => typeof(AssociacaoDecoracaoFlores);
    }
}
