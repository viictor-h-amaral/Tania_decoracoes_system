using TaniaDecoracoes.Entities.Models.Attributes;

namespace TaniaDecoracoes.Entities.Models.Decoracoes
{
    /// <summary>
    /// Classe referente aos temas de aniversário
    /// </summary>
    public partial class TemaAniversario
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome do tema de aniversário
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Decorações com este tema de aniversário
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
