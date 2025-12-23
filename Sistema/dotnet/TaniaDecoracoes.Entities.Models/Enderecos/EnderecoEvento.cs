using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos endereços dos eventos
    /// </summary>
    public class EnderecoEvento : IEntityModel
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id do estado do endereço
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int EstadoId { get; set; }

        /// <summary>
        /// Instância do estado do endereço
        /// </summary>
        [BindingAttribute(fieldName: "Identificacao")]
        public virtual required Estado EstadoInstance { get; set; }

        /// <summary>
        /// Retorna o Id do município do endereço
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int MunicipioId { get; set; }

        /// <summary>
        /// Instância do município do endereço
        /// </summary>
        [BindingAttribute(fieldName: "Nome")]
        [TitleAttribute(title: "Município")]
        public virtual required Municipio MunicipioInstance { get; set; }

        /// <summary>
        /// Retorna o Id do bairro do endereço
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int BairroId { get; set; }

        /// <summary>
        /// Instância do bairro do endereço
        /// </summary>
        [BindingAttribute(fieldName: "Nome")]
        public virtual required Bairro BairroInstance { get; set; }

        /// <summary>
        /// Retorna o Id do logradouro do endereço
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int LogradouroId { get; set; }

        /// <summary>
        /// Instância do logradouro do endereço
        /// </summary>
        [BindingAttribute(fieldName: "Identificacao")]
        public virtual required Logradouro LogradouroInstance { get; set; }

        /// <summary>
        /// Retorna o Id do tipo de endereço do evento
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int TipoEnderecoEventoId { get; set; }

        /// <summary>
        /// Instância do tipo de endereço do evento
        /// </summary>
        [BindingAttribute(fieldName: "TipoEndereco")]
        [TitleAttribute(title: "Tipo de endereço")]
        public virtual required TipoEnderecoEvento TipoEnderecoEventoInstance { get; set; }

        /// <summary>
        /// Retorna o número do endereço
        /// <para>Required</para>
        /// </summary>
        [TitleAttribute(title: "Número do endereço")]
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
        [TitleAttribute(title: "Observações")]
        public string? Observacoes { get; set; }

        /// <summary>
        /// Retorna o andar do apartamento
        /// <para>Optional</para>
        /// </summary>
        [TitleAttribute(title: "Andar do apartamento")]
        public int? AndarApartamento { get; set; }

        /// <summary>
        /// Retorna o número do apartamento
        /// <para>Optional</para>
        /// </summary>
        [TitleAttribute(title: "Número do apartamento")]
        public int? NumeroApartamento { get; set; }

        [IgnoreOnForm]
        [IgnoreOnGrid]
        public string Identificacao => $"{LogradouroInstance.Nome} - N{NumeroEndereco}, {BairroInstance.Nome}, {MunicipioInstance.Nome}-{EstadoInstance.Sigla}";

        /// <summary>
        /// Coleção de decorações associadas a este endereço de evento
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Decoracao>? Decoracoes { get; set; }
    }
}