using TaniaDecoracoesSystem.Entities.Models.Itens;

namespace TaniaDecoracoesSystem.Entities.Models.TabelasGerais
{
    public class Tamanho
    {
        public required int Id { get; set; }
        public required string Valor { get; set; }

        public ICollection<Item>? Itens { get; set; }
    }
}
