using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Associacao.Tabelas
{
    public class AssociacaoDecoracaoItensTabela : ITabela
    {
        public string NameInDataBase => "assoc_decoracoes_itens";

        public Type ModelType => typeof(AssociacaoDecoracaoItens);
    }
}
