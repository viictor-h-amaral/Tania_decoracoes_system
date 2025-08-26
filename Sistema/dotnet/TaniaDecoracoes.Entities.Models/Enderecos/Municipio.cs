using TaniaDecoracoes.Entities.Models.Attributes;

namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos municípios
    /// </summary>
    public class Municipio
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id do estado do município
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int EstadoId { get; set; }

        /// <summary>
        /// Instância do estado do município
        /// </summary>
        public virtual required Estado EstadoInstance { get; set; }

        /// <summary>
        /// Retorna o nome do município
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Retorna o código IBGE do município
        /// <para>Optional</para>
        /// </summary>
        public int? CodigoIBGE { get; set; }

        /// <summary>
        /// Coleção de bairros do município
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Bairro>? Bairros { get; set; }

        /// <summary>
        /// Coleção de endereços de clientes do município
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<EnderecoCliente>? EnderecosClientes { get; set; }

        /// <summary>
        /// Coleção de endereços de eventos do município
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
