using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.Entities.Models.Pagamentos
{
    /// <summary>
    /// Classe referente aos Custos das decorações
    /// </summary>
    public class DecoracaoCustos
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id da decoração
        /// </summary>
        public int  DecoracaoId { get; set; }

        /// <summary>
        /// Instância da decoração
        /// </summary>
        public required Decoracao  DecoracaoInstance { get; set; }

        /// <summary>
        /// Retorna o custo calculado da decoração
        /// <para>Optional</para>
        /// </summary>
        public decimal? CustoCalculado { get; set; }

        /// <summary>
        /// Retorna o custo das flores da decoração
        /// <para>Optional</para>
        /// </summary>
        public decimal? CustoFlores { get; set; }

        /// <summary>
        /// Retorna o custo dos balões da decoração
        /// <para>Optional</para>
        /// </summary>
        public decimal? CustoBaloes { get; set; }

        /// <summary>
        /// Retorna o custo dos móveis da decoração
        /// <para>Optional</para>
        /// </summary>
        public decimal? CustoMoveis { get; set; }

        /// <summary>
        /// Retorna custos extras da decoração
        /// <para>Optional</para>
        /// </summary>
        public decimal? CustosExtras { get; set; }

        /// <summary>
        /// Retorna o custo do combustível da decoração
        /// <para>Required</para>
        /// </summary>
        public decimal CustosCombustivel { get; set; }

        /// <summary>
        /// Retorna o custo do total da decoração
        /// <para>Required</para>
        /// </summary>
        public decimal CustoTotal { get; set; }
    }
}
