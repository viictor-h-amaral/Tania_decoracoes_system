using TaniaDecoracoesSystem.Entities.Models.Itens;

namespace TaniaDecoracoesSystem.Entities.Models.TabelasGerais
{
    public class Cor
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required string CodigoHex { get; set; }

        public ICollection<Flor>? Flores { get; set; }
        public ICollection<Item>? Itens { get; set; }
    }
}
