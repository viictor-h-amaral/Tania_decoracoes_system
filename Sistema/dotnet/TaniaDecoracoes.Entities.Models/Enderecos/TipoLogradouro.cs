namespace TaniaDecoracoesSystem.Entities.Models.Enderecos
{
    public class TipoLogradouro
    {
        public required long Id { get; set; }
        public required string Nome { get; set; }

        public ICollection<Logradouro>? Logradouros { get; set; }
    }
}
