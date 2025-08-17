using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Itens.Tabelas
{
    public class FlorTabela : ITabela
    {
        public string NameInDataBase => "it_flores";

        public Type ModelType => typeof(Flor);
    }
}
