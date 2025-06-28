namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos municípios
    /// </summary>
    public class Municipio
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id do estado do município
        /// <para>Required</para>
        /// </summary>
        public int EstadoId { get; set; }

        /// <summary>
        /// Instância do estado do município
        /// </summary>
        public required Estado EstadoInstance { get; set; }

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
        public ICollection<Bairro>? Bairros { get; set; }

        /// <summary>
        /// Coleção de endereços de clientes do município
        /// </summary>
        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }

        /// <summary>
        /// Coleção de endereços de eventos do município
        /// </summary>
        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
