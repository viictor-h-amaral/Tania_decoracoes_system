using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Models.Associacao
{
    /// <summary>
    /// Classe referente à associação entre decorações e flores
    /// </summary>
    public class AssociacaoDecoracaoFlores
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id do registro da decoração da associação
        /// <para>Required</para>
        /// </summary>
        public int DecoracaoId { get; set; }

        /// <summary>
        /// Instância da decoração associada
        /// </summary>
        public required Decoracao DecoracaoInstance { get; set; }

        /// <summary>
        /// Reotorna o Id do registro da flor associada
        /// <para>Required</para>
        /// </summary>
        public int FlorId { get; set; }

        /// <summary>
        /// Instância da flor associada
        /// </summary>
        public required Flor FlorInstance { get; set; }
    }
}
