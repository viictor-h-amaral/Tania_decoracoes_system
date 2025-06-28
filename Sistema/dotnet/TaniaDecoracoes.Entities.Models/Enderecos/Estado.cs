namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos estados
    /// </summary>
    public class Estado
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
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
        public ICollection<Municipio>? Municipios { get; set; }

        /// <summary>
        /// Coleção de endereços de clientes do estado
        /// </summary>
        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }

        /// <summary>
        /// Coleção de endereços de eventos do estado
        /// </summary>
        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
