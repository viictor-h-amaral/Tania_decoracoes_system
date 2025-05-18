namespace TaniaDecoracoesSystem.Entities.Models.Enderecos
{
    public class Logradouro
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public required int Id { get; set; }
        /// <summary>
        /// Retorna o Id do registro do bairro do logradouro
        /// </summary>
        public required int BairroId { get; set; }
        /// <summary>
        /// Instância do bairro do logradouro
        /// </summary>
        public required Bairro BairroInstance { get; set; }
        /// <summary>
        /// Nome do logradouro
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

        public ICollection<Cep>? Ceps { get; set; }
        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }
        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }

    }
}
