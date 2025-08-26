using TaniaDecoracoes.Entities.Models.Attributes;

namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos estados
    /// </summary>
    public class Estado
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome do estado
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Retorna a sigla do estado
        /// <para>Required</para>
        /// </summary>
        public required string Sigla { get; set; }

        /// <summary>
        /// Coleção de municípios do estado
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Municipio>? Municipios { get; set; }

        /// <summary>
        /// Coleção de endereços de clientes do estado
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<EnderecoCliente>? EnderecosClientes { get; set; }

        /// <summary>
        /// Coleção de endereços de eventos do estado
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
