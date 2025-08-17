using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Itens.Tabelas
{
    public class ItemTabela : ITabela
    {
        public string NameInDataBase => "it_itens";

        public Type ModelType => typeof(Item);
    }
}
