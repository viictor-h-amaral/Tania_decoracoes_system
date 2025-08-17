using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Itens.Tabelas
{
    public class TipoItemTabela : ITabela
    {
        public string NameInDataBase => "it_tipositens";

        public Type ModelType => typeof(TipoItem);
    }
}
