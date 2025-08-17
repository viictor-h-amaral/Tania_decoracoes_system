using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Clientes;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.Entities.Models.Decoracoes
{
    public partial class TemaAniversario
    {
        public class Fields
        {
            public const string Id = "ID";
            public const string Nome = "NOME";
            public const string Decoracoes = null;
        }

        public readonly IDictionary<string, string> PropertyNameFieldName = new Dictionary<string, string>()
        {
            [nameof(Id)] = Fields.Id,
            [nameof(Nome)] = Fields.Nome
        };
    }
}
