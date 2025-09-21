using TaniaDecoracoes.Entities.Models.Attributes;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    /// <summary>
    /// Classe referente aos tipos de combustíveis
    /// </summary>
    public class TipoCombustivel : IEntityModel
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome do combustível
        /// <para>Required</para>
        /// </summary>
        [Title("Nome")]
        public required string NomeCombustivel { get; set; }

        /// <summary>
        /// Coleção de carros associados a esse tipo de combustível
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Carro>? Carros { get; set; }

        /// <summary>
        /// Coleção de custos de combustível associados a esse tipo de combustível
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<CustoCombustivel>? CustosCombustiveis { get; set; }
    }
}
