using TaniaDecoracoes.Entities.Models.Clientes;

namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos endereços dos clientes
    /// </summary>
    public class EnderecoCliente
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id do estado do endereço
        /// <para>Required</para>
        /// </summary>
        public int EstadoId { get; set; }

        /// <summary>
        /// Instância do estado do endereço
        /// </summary>
        public required Estado EstadoInstance { get; set; }

        /// <summary>
        /// Retorna o Id do município do endereço
        /// <para>Required</para>
        /// </summary>
        public int MunicipioId { get; set; }

        /// <summary>
        /// Instância do município do endereço
        /// </summary>
        public required Municipio MunicipioInstance { get; set; }

        /// <summary>
        /// Retorna o Id do bairro do endereço
        /// <para>Required</para>
        /// </summary>
        public int BairroId { get; set; }

        /// <summary>
        /// Instância do bairro do endereço
        /// </summary>
        public required Bairro BairroInstance { get; set; }

        /// <summary>
        /// Retorna o Id do logradouro do endereço
        /// <para>Required</para>
        /// </summary>
        public int LogradouroId { get; set; }

        /// <summary>
        /// Instância do logradouro do endereço
        /// </summary>
        public required Logradouro LogradouroInstance { get; set; }

        /// <summary>
        /// Retorna o Id do tipo de endereço do cliente
        /// <para>Required</para>
        /// </summary>
        public int TipoEnderecoClienteId { get; set; }

        /// <summary>
        /// Instância do tipo de endereço do cliente
        /// </summary>
        public required TipoEnderecoCliente TipoEnderecoClienteInstance { get; set; }

        /// <summary>
        /// Retorna o número do endereço
        /// <para>Required</para>
        /// </summary>
        public int NumeroEndereco { get; set; }

        /// <summary>
        /// Observações adicionais do endereço
        /// <para>Optional</para>
        /// </summary>
        public string? Observacoes { get; set; }

        /// <summary>
        /// Retorna o andar do apartamento
        /// <para>Optional</para>
        /// </summary>
        public int? AndarApartamento { get; set; }

        /// <summary>
        /// Retorna o número do apartamento
        /// <para>Optional</para>
        /// </summary>
        public int? NumeroApartamento { get; set; }

        /// <summary>
        /// Coleção de clientes associados a este endereço
        /// </summary>
        public ICollection<Cliente>? Clientes { get; set; }
    }
}
