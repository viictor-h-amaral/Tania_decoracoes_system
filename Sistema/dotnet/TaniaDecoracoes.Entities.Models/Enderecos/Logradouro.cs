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
        /// Retorna o Id do registro do bairro do logradouro
        /// </summary>
        public int BairroId { get; set; }
        /// <summary>
        /// Instância do bairro do logradouro
        /// </summary>
        public required Bairro BairroInstance { get; set; }
        /// <summary>
        /// Retorna o Nome do logradouro
        /// </summary>
        public required string Nome { get; set; }
        /// <summary>
        /// Retorna o Id do registro do tipo de logradouro do logradouro
        /// </summary>
        public int? TipoLogradouroId { get; set; }
        /// <summary>
        /// Instância do tipo de logradouro do logradouro
        /// </summary>
        public TipoLogradouro? TipoLogradouroInstance { get; set; }

        /// <summary>
        /// Reotorna a lista de CEPs associados a este logradouro
        /// </summary>
        public ICollection<Cep>? Ceps { get; set; }
        /// <summary>
        /// Retorna a lista de endereços de clientes associados a este logradouro
        /// </summary>
        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }
        /// <summary>
        /// Retorna a lista de endereços de eventos associados a este logradouro
        /// </summary>
        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }

    }
}
