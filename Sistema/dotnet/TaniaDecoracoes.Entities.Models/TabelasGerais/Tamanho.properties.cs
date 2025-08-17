using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    public partial class Tamanho
    {
        public class Fields
        {
            public const string Id = "ID";
            public const string Valor = "VALOR";
            public const string Itens = null;
        }

        public readonly IDictionary<string, string> PropertyNameFieldName = new Dictionary<string, string>()
        {
            [nameof(Id)] = Fields.Id,
            [nameof(Valor)] = Fields.Valor
        };
    }
}
