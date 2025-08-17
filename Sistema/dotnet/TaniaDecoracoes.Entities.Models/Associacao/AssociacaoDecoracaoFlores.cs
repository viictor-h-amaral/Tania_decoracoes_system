using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Models.Associacao
{
    /// <summary>
    /// Classe referente à associação entre decorações e flores
    /// </summary>
    public partial class AssociacaoDecoracaoFlores
    {
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id do registro da decoração da associação
        /// <para>Required</para>
        /// </summary>
        public int DecoracaoId { get; set; }

        /// <summary>
        /// Instância da decoração associada
        /// </summary>
        public virtual required Decoracao DecoracaoInstance { get; set; }

        /// <summary>
        /// Reotorna o Id do registro da flor associada
        /// <para>Required</para>
        /// </summary>
        public int FlorId { get; set; }

        /// <summary>
        /// Instância da flor associada
        /// </summary>
        public virtual required Flor FlorInstance { get; set; }
    }
}
