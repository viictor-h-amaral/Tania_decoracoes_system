namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos tipos de endereço de cliente
    /// </summary>
    public class TipoEnderecoCliente
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o tipo de endereço do cliente
        /// <para>Required</para>
        /// </summary>
        public required string TipoEndereco { get; set; }

        /// <summary>
        /// Coleção de endereços de clientes deste tipo de endereço
        /// </summary>
        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }
    }
}
