using TaniaDecoracoesSystem.Entities.Models.Decoracoes;

namespace TaniaDecoracoesSystem.Entities.Models.TabelasGerais
{
    public class Carro
    {
        public required int Id { get; set; }
        public required string Apelido { get; set; }
        public required float LitrosPorKm { get; set; }

        public required int TipoCombustivelId { get; set; }
        public required TipoCombustivel TipoCombustivelInstance { get; set; }

        public bool? EstaAtivo {  get; set; }

        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
