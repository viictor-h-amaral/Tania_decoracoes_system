using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    /// <summary>
    /// Classe referente aos carros do sistema
    /// </summary>
    public class Carro : IEntityModel
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o apelido do carro
        /// <para>Required</para>
        /// </summary>
        public required string Apelido { get; set; }

        /// <summary>
        /// Retorna a quantidade de litros que o carro faz em 1km
        /// <para>Required</para>
        /// </summary>
        public float LitrosPorKm { get; set; }

        /// <summary>
        /// Retorna o Id do tipo de combustível do carro
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int TipoCombustivelId { get; set; }

        /// <summary>
        /// Instância do tipo de combustível do carro
        /// </summary>
        [BindingAttribute(fieldName: "NomeCombustivel")]
        [TitleAttribute(title: "Tipo de combustível")]
        public virtual required TipoCombustivel TipoCombustivelInstance { get; set; }

        /// <summary>
        /// Retorna se o carro está, ou não, ativo
        /// <para>Optional</para>
        /// </summary>
        [TitleAttribute(title: "Ativo")]
        public bool? EstaAtivo { get; set; }

        /// <summary>
        /// Coleção de decorações associadas a esse carro
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
