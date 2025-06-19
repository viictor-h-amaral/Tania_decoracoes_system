namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    public class TipoEnderecoEvento
    {
        public int Id { get; set; }
        public required string TipoEndereco { get; set; }

        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
