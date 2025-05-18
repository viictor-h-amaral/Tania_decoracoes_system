namespace TaniaDecoracoesSystem.Entities.Models.Itens
{
    public class TipoItem
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }

        public ICollection<Item>? Itens { get; set; }
    }
}
