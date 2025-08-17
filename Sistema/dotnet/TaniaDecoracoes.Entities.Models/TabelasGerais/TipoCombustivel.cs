namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    /// <summary>
    /// Classe referente aos tipos de combustíveis
    /// </summary>
    public class TipoCombustivel
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome do combustível
        /// <para>Required</para>
        /// </summary>
        public required string NomeCombustivel { get; set; }

        /// <summary>
        /// Coleção de carros associados a esse tipo de combustível
        /// </summary>
        public virtual ICollection<Carro>? Carros { get; set; }

        /// <summary>
        /// Coleção de custos de combustível associados a esse tipo de combustível
        /// </summary>
        public virtual ICollection<CustoCombustivel>? CustosCombustiveis { get; set; }
    }
}
