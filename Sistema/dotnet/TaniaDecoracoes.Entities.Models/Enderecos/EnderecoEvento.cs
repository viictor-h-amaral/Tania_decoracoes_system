using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos endereços dos eventos
    /// </summary>
    public class EnderecoEvento
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
        public virtual required Estado EstadoInstance { get; set; }

        /// <summary>
        /// Retorna o Id do município do endereço
        /// <para>Required</para>
        /// </summary>
        public int MunicipioId { get; set; }

        /// <summary>
        /// Instância do município do endereço
        /// </summary>
        public virtual required Municipio MunicipioInstance { get; set; }

        /// <summary>
        /// Retorna o Id do bairro do endereço
        /// <para>Required</para>
        /// </summary>
        public int BairroId { get; set; }

        /// <summary>
        /// Instância do bairro do endereço
        /// </summary>
        public virtual required Bairro BairroInstance { get; set; }

        /// <summary>
        /// Retorna o Id do logradouro do endereço
        /// <para>Required</para>
        /// </summary>
        public int LogradouroId { get; set; }

        /// <summary>
        /// Instância do logradouro do endereço
        /// </summary>
        public virtual required Logradouro LogradouroInstance { get; set; }

        /// <summary>
        /// Retorna o Id do tipo de endereço do evento
        /// <para>Required</para>
        /// </summary>
        public int TipoEnderecoEventoId { get; set; }

        /// <summary>
        /// Instância do tipo de endereço do evento
        /// </summary>
        public virtual required TipoEnderecoEvento TipoEnderecoEventoInstance { get; set; }

        /// <summary>
        /// Retorna o número do endereço
        /// <para>Required</para>
        /// </summary>
        public int NumeroEndereco { get; set; }

        /// <summary>
        /// Retorna o apelido do endereço
        /// <para>Required</para>
        /// </summary>
        public required string Apelido { get; set; }

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
        /// Coleção de decorações associadas a este endereço de evento
        /// </summary>
        public virtual ICollection<Decoracao>? Decoracoes { get; set; }
    }
}