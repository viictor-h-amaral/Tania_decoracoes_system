using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Associacao
{
    public partial class AssociacaoDecoracaoFlores
    {
        public class Fields
        {
            public const string Id = "ID";
            public const string DecoracaoId = "DECORACAO";
            public const string DecoracaoInstance = null;
            public const string FlorId = "FLOR";
            public const string FlorInstance = null;
        }

        public readonly IDictionary<string, string> PropertyNameFieldName = new Dictionary<string, string>()
        {
            [nameof(Id)] = Fields.Id,
            [nameof(DecoracaoId)] = Fields.DecoracaoId,
            [nameof(FlorId)] = Fields.FlorId,
        };
    }
}
