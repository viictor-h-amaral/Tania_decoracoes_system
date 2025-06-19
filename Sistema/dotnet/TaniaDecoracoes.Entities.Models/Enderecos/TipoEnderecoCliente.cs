namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    public class TipoEnderecoCliente
    {
        public int Id { get; set; }
        public required string TipoEndereco { get; set; }

        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }
    }
}
