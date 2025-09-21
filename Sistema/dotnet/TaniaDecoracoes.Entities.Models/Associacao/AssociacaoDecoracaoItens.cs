using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Models.Associacao
{
    /// <summary>
    /// Classe referente à associação entre decorações e itens
    /// </summary>
    public partial class AssociacaoDecoracaoItens : IEntityModel
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id do registro da decoração da associação
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int DecoracaoId { get; set; }

        /// <summary>
        /// Instância da decoração associada
        /// </summary>
        [BindingAttribute(fieldName: "Identificacao")]
        [TitleAttribute(title: "Decoração")]
        public virtual required Decoracao DecoracaoInstance { get; set; }

        /// <summary>
        /// Retorna o Id do registro do item associado
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int ItemId { get; set; }

        /// <summary>
        /// Instância do item associado
        /// </summary>
        [BindingAttribute(fieldName: "Identificacao")]
        [TitleAttribute]
        public virtual required Item ItemInstance { get; set; }
    }
}
