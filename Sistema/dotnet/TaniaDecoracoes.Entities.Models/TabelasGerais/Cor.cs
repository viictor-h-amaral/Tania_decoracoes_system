using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    public class Cor
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string CodigoHex { get; set; }

        public ICollection<Flor>? Flores { get; set; }
        public ICollection<Item>? Itens { get; set; }
    }
}
