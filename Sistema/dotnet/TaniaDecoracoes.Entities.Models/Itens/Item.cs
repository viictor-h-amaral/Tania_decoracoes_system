using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Itens
{
    /// <summary>
    /// Classe referente aos itens de decorações
    /// </summary>
    public class Item
    {
        [IgnoreOnGrid]
        [IgnoreOnForm]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o apelido do item
        /// <para>Optional</para>
        /// </summary>
        public string? Apelido { get; set; }

        /// <summary>
        /// Retorna o Id do tipo do item
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int TipoItemId { get; set; }

        /// <summary>
        /// Instância do tipo do item
        /// </summary>
        [BindingAttribute(fieldName: "Nome")]
        [TitleAttribute(title: "Tipo do item")]
        public virtual required TipoItem TipoItemInstance { get; set; }

        /// <summary>
        /// Retorna a quantidade em estoque do item
        /// <para>Required</para>
        /// </summary>
        [TitleAttribute(title: "Quantidade em estoque")]
        public int QuantidadeEstoque { get; set; }

        /// <summary>
        /// Retorna o preço do item
        /// <para>Optional</para>
        /// </summary>
        [IgnoreOnGrid]
        [TitleAttribute(title: "Preço")]
        public decimal? Preco { get; set; }

        /// <summary>
        /// Retorna o Id da cor do item
        /// <para>Optional</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int? CorId { get; set; }

        /// <summary>
        /// Instância da cor do item
        /// </summary>
        [BindingAttribute(fieldName: "Nome")]
        public virtual Cor? CorInstance { get; set; }

        /// <summary>
        /// Retorna o Id do tamanho do item
        /// <para>Optional</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int? TamanhoId { get; set; }

        /// <summary>
        /// Instância do tamanho do item
        /// </summary>
        [BindingAttribute(fieldName: "Valor")]
        public virtual Tamanho? TamanhoInstance { get; set; }

        /// <summary>
        /// Retorna a altura do item (em cm)
        /// <para>Optional</para>
        /// </summary>
        [IgnoreOnGrid]
        public float? Altura { get; set; }

        /// <summary>
        /// Retorna o comprimento do item (em cm)
        /// <para>Optional</para>
        /// </summary>
        [IgnoreOnGrid]
        public float? Comprimento { get; set; }

        /// <summary>
        /// Retorna a largura do item (em cm)
        /// <para>Optional</para>
        /// </summary>
        [IgnoreOnGrid]
        public float? Largura { get; set; }

        /// <summary>
        /// Retorna o endereço da imagem do item
        /// <para>Optional</para>
        /// </summary>
        [IgnoreOnGrid]
        public string? EnderecoImagem { get; set; }

        /// <summary>
        /// Coleção de associações entre decoração e este item
        /// </summary>

        /// <summary>
        /// Retorna uma string com as dimensões do item
        /// </summary>
        [TitleAttribute(title: "Dimensões")]
        public string Dimensoes => TamanhoInstance is null ?
                                    $@" L{(Largura.HasValue     ? Largura.Value     : string.Empty)}"+
                                     $" C{(Comprimento.HasValue ? Comprimento.Value : string.Empty)}"+
                                     $" A{(Altura.HasValue      ? Altura.Value      : string.Empty)}"
                                    : TamanhoInstance.Valor;

        [IgnoreOnForm]
        [IgnoreOnGrid]
        public string Identificacao => $"{TipoItemInstance.Nome}{(CorInstance is null ? string.Empty : $" - {CorInstance.Nome}")} {Dimensoes}";

        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<AssociacaoDecoracaoItens>? AssociacaoDecoracaoItens { get; set; }
    }
}