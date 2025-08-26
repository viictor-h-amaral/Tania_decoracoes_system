using TaniaDecoracoes.Entities.Models.Attributes;

namespace TaniaDecoracoes.Entities.Models.Decoracoes
{
    /// <summary>
    /// Classe referente aos tipos de eventos
    /// </summary>
    public partial class TipoEvento
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome do tipo de evento
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }


        /// <summary>
        /// Decorações com este tipo de evento
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
