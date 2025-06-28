using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    /// <summary>
    /// Classe referente aos tamanhos
    /// </summary>
    public class Tamanho
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome do tamanho
        /// </summary>
        public required string Valor { get; set; }

        /// <summary>
        /// Coleção de itens associados a esse tamanho
        /// </summary>
        public ICollection<Item>? Itens { get; set; }
    }
}
