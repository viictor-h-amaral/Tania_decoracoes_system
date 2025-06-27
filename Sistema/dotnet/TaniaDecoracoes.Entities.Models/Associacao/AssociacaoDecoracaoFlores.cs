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
        /// 
        /// Required
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Retorna o Id do registro da decoração da associação
        /// 
        /// Required
        /// </summary>
        public int DecoracaoId { get; set; }
        /// <summary>
        /// Instância da decoração associada
        /// </summary>
        public required Decoracao DecoracaoInstance { get; set; }
        /// <summary>
        /// Reotorna o Id do registro da flor associada
        /// 
        /// Required
        /// </summary>
        public int FlorId { get; set; }
        /// <summary>
        /// Instância da flor associada
        /// </summary>
        public required Flor FlorInstance { get; set; }
    }
}
