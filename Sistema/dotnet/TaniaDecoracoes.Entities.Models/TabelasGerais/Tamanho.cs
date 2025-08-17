using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    /// <summary>
    /// Classe referente aos tamanhos
    /// </summary>
    public partial class Tamanho
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome do tamanho
        /// <para>Required</para>
        /// </summary>
        public required string Valor { get; set; }

        /// <summary>
        /// Coleção de itens associados a esse tamanho
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Item>? Itens { get; set; }
    }
}
