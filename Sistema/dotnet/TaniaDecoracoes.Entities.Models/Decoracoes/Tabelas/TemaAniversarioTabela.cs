using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Decoracoes.Tabelas
{
    public class TemaAniversarioTabela : ITabela
    {
        public string NameInDataBase => "dec_temasaniversarios";

        public Type ModelType => typeof(TemaAniversario);
    }
}
