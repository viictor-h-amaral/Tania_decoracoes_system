namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    public class TipoLogradouro
    {
        public int Id { get; set; }
        public required string Nome { get; set; }

        public ICollection<Logradouro>? Logradouros { get; set; }
    }
}
