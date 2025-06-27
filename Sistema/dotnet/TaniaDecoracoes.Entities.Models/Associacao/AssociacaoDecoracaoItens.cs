using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Models.Associacao
{
    /// <summary>
    /// Classe referente à associação entre decorações e itens
    /// </summary>
    public class AssociacaoDecoracaoItens
    {
        /// <summary>
        /// Retotorna o Id do registro no banco de dados
        /// <para>Required</para>
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
        /// Retorna o Id do registro do item associado
        /// <para>Required</para>
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Instância do item associado
        /// </summary>
        public required Item ItemInstance { get; set; }
    }
}
