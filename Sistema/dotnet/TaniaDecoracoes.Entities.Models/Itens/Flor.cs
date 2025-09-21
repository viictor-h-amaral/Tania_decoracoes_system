using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Itens
{
    /// <summary>
    /// Classe referente às flores do sistema
    /// </summary>
    public class Flor : IEntityModel
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome da flor
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Retorna o preço da flor em época de temporada
        /// <para>Optional</para>
        /// </summary>
        [TitleAttribute(title: "Preço durante temporada")]
        public decimal? PrecoTemporada { get; set; }

        /// <summary>
        /// Retorna o preço padrão da flor
        /// <para>Required</para>
        /// </summary>
        [TitleAttribute(title: "Preço padrão")]
        public decimal PrecoPadrao { get; set; }

        /// <summary>
        /// Retorna o endereço da imagem da flor
        /// <para>Optional</para>
        /// </summary>
        [TitleAttribute(title: "Endereço da imagem")]
        public string? EnderecoImagem { get; set; }

        /// <summary>
        /// Retorna o Id da cor da flor
        /// <para>Optional</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int? CorId {  get; set; }

        /// <summary>
        /// Instância da cor da flor
        /// </summary>
        [BindingAttribute(fieldName: "Nome")]
        public virtual Cor? CorInstance { get; set; }

        /// <summary>
        /// Coleção de associações entre decorações e esta flor
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<AssociacaoDecoracaoFlores>? AssociacaoDecoracaoFlores { get; set; }
    }
}
