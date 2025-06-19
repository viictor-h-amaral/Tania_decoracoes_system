namespace TaniaDecoracoes.Entities.Models.Decoracoes
{
    public class TipoEvento
    {
        public int Id { get; set; }
        public required string Nome { get; set; }

        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
