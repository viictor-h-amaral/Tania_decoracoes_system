namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos logradouros
    /// </summary>
    public class Logradouro
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id do bairro associado ao logradouro
        /// <para>Required</para>
        /// </summary>
        public int BairroId { get; set; }

        /// <summary>
        /// Instância do bairro associado ao logradouro
        /// </summary>
        public required Bairro BairroInstance { get; set; }

        /// <summary>
        /// Retorna o nome do logradouro
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Retorna o Id do tipo de logradouro
        /// <para>Optional</para>
        /// </summary>
        public int? TipoLogradouroId { get; set; }

        /// <summary>
        /// Instância do tipo de logradouro
        /// </summary>
        public TipoLogradouro? TipoLogradouroInstance { get; set; }

        /// <summary>
        /// Coleção de CEPs associados a este logradouro
        /// </summary>
        public ICollection<Cep>? Ceps { get; set; }

        /// <summary>
        /// Coleção de endereços de clientes associados a este logradouro
        /// </summary>
        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }

        /// <summary>
        /// Coleção de endereços de eventos associados a este logradouro
        /// </summary>
        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
