using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Decoracoes
{
    public partial class TipoEvento
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
