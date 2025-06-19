using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    public class Tamanho
    {
        public int Id { get; set; }
        public required string Valor { get; set; }

        public ICollection<Item>? Itens { get; set; }
    }
}
