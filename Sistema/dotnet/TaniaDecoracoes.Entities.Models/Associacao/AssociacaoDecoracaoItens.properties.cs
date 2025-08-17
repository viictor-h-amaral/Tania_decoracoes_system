using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Models.Associacao
{
    public partial class AssociacaoDecoracaoItens
    {
        public class Fields
        {
            public const string Id = "ID";
            public const string DecoracaoId = "DECORACAO";
            public const string DecoracaoInstance = null;
            public const string ItemId = "FLOR";
            public const string ItemInstance = null;
        }

        public readonly IDictionary<string, string> PropertyNameFieldName = new Dictionary<string, string>()
        {
            [nameof(Id)] = Fields.Id,
            [nameof(DecoracaoId)] = Fields.DecoracaoId,
            [nameof(ItemId)] = Fields.ItemId,
        };
    }
}
