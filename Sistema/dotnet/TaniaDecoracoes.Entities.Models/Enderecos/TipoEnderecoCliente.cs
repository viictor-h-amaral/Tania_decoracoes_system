namespace TaniaDecoracoesSystem.Entities.Models.Enderecos
{
    public class TipoEnderecoCliente
    {
        public required int Id { get; set; }
        public required string TipoEndereco { get; set; }

        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }
    }
}
