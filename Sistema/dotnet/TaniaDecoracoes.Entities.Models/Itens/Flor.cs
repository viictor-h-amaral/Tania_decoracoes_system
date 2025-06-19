using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Itens
{
    public class Flor
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public decimal? PrecoTemporada { get; set; }
        public decimal PrecoPadrao { get; set; }
        public string? EnderecoImagem { get; set; }

        public int? CorId {  get; set; }
        public Cor? CorInstance { get; set; }

        public ICollection<AssociacaoDecoracaoFlores>? AssociacaoDecoracaoFlores { get; set; }
    }
}
