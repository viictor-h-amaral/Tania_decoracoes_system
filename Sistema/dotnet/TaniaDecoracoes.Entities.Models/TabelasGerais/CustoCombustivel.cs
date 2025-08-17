namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    /// <summary>
    /// Classe referente aos custos de combustíveis do sistema
    /// </summary>
    public class CustoCombustivel
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id do combustivel que possui esse custo
        /// <para>Required</para>
        /// </summary>
        public int CombustivelId { get; set; }

        /// <summary>
        /// Instância do combustível que possui esse custo
        /// </summary>
        public virtual required TipoCombustivel CombustivelInstance { get; set; }

        /// <summary>
        /// Retorna o valor pago por litro do combustível
        /// <para>Required</para>
        /// </summary>
        public decimal ReaisPorLitro { get; set; }

        /// <summary>
        /// Retorna a data inicial da vigência desse custo
        /// <para>Required</para>
        /// </summary>
        public DateOnly DataInicial { get; set; }

        /// <summary>
        /// Retorna a data final da vigência desse custo
        /// <para>Optional</para>
        /// </summary>
        public DateOnly? DataFinal { get; set; }
    }
}
