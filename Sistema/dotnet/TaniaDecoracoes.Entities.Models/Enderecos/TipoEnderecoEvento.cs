namespace TaniaDecoracoesSystem.Entities.Models.Enderecos
{
    public class TipoEnderecoEvento
    {
        public required int Id { get; set; }
        public required string TipoEndereco { get; set; }

        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
