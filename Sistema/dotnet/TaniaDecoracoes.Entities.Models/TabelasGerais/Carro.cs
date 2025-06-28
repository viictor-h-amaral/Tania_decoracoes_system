using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    /// <summary>
    /// Classe referente aos carros do sistema
    /// </summary>
    public class Carro
    {
        /// <summary>
        /// Retorna o Id do registro do carro no banco de dados
        /// </summary>
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
        public int TipoCombustivelId { get; set; }

        /// <summary>
        /// Instância do tipo de combustível do carro
        /// </summary>
        public required TipoCombustivel TipoCombustivelInstance { get; set; }

        /// <summary>
        /// Retorna se o carro está, ou não, ativo
        /// <para>Optional</para>
        /// </summary>
        public bool? EstaAtivo { get; set; }

        /// <summary>
        /// Coleção de decorações associadas a esse carro
        /// </summary>
        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
