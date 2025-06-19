namespace TaniaDecoracoes.Entities.Models.Itens
{
    public class TipoItem
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Item>? Itens { get; set; }
    }
}
