using TaniaDecoracoes.Entities.Models.Attributes;

namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos tipos de endereço de cliente
    /// </summary>
    public class TipoEnderecoCliente
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o tipo de endereço do cliente
        /// <para>Required</para>
        /// </summary>
        [TitleAttribute(title: "Tipo de endereço")]
        public required string TipoEndereco { get; set; }

        /// <summary>
        /// Coleção de endereços de clientes deste tipo de endereço
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<EnderecoCliente>? EnderecosClientes { get; set; }
    }
}
