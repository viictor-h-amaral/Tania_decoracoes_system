using TaniaDecoracoes.Entities.Models.Attributes;

namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos CEPs
    /// </summary>
    public class Cep : IEntityModel
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id do registro do logradouro associado ao CEP
        /// <para>Required</para>>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int LogradouroId { get; set; }

        /// <summary>
        /// Instância do logradouro associado ao CEP
        /// </summary>
        [BindingAttribute(fieldName: "Nome")]
        public virtual required Logradouro LogradouroInstance { get; set; }

        /// <summary>
        /// Retorna o número do CEP
        /// <para>Required</para>
        /// </summary>
        [TitleAttribute(title: "Cep")]
        public required string CepValor { get; set; }
    }
}
