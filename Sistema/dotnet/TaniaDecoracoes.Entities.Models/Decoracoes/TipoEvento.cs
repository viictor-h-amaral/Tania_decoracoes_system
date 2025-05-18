namespace TaniaDecoracoesSystem.Entities.Models.Decoracoes
{
    public class TipoEvento
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }

        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
