using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Models.Associacao
{
    public class AssociacaoDecoracaoFlores
    {
        public int Id { get; set; }

        public int DecoracaoId { get; set; }
        public required Decoracao DecoracaoInstance { get; set; }

        public int FlorId { get; set; }
        public required Flor FlorInstance { get; set; }
    }
}
