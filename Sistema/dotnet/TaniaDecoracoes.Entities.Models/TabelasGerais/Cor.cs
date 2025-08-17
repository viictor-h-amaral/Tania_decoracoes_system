using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    /// <summary>
    /// Classe referente às cores do sistema
    /// </summary>
    public class Cor
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome da cor
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Retorna o código hexadecimal da cor
        /// <para>Required</para>
        /// </summary>
        public required string CodigoHex { get; set; }

        /// <summary>
        /// Coleção de flores associados à essa cor
        /// </summary>
        public virtual ICollection<Flor>? Flores { get; set; }
        /// <summary>
        /// Coleção de itens relacionados à essa cor
        /// </summary>
        public virtual ICollection<Item>? Itens { get; set; }
    }
}
