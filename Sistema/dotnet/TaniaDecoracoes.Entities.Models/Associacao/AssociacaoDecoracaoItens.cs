using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Models.Associacao
{
    public class AssociacaoDecoracaoItens
    {
        public int Id { get; set; }

        public int DecoracaoId { get; set; }
        public required Decoracao DecoracaoInstance { get; set; }

        public int ItemId { get; set; }
        public required Item ItemInstance { get; set; }
    }
}
