using TaniaDecoracoes.Entities.Models.Attributes;

namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos tipos de endereço de evento
    /// </summary>
    public class TipoEnderecoEvento : IEntityModel
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o tipo de endereço do evento
        /// <para>Required</para>
        /// </summary>
        [TitleAttribute(title: "Tipo de endereço")]
        public required string TipoEndereco { get; set; }

        /// <summary>
        /// Coleção de endereços de eventos deste tipo de endereço
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
