using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Clientes.Tabelas
{
    public class ClienteTabela : ITabela
    {
        public string NameInDataBase => "cl_clientes";

        public Type ModelType => typeof(Cliente);
    }
}
