using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Clientes.Tabelas
{
    public class DependenteClienteTabela : ITabela
    {
        public string NameInDataBase => "cl_dependentesclientes";

        public Type ModelType => typeof(DependenteCliente);
    }
}
