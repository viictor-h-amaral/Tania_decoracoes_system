using TaniaDecoracoesSystem.Entities.Models.TabelasGerais;

namespace TaniaDecoracoesSystem.Entities.Models.Itens
{
    public class Flor
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public decimal? PrecoTemporada { get; set; }
        public required decimal PrecoPadrao { get; set; }
        public string? EnderecoImagem { get; set; }

        public int? CorId {  get; set; }
        public Cor? CorInstance { get; set; }

    }
}
