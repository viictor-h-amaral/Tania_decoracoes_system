namespace TaniaDecoracoes.Entities.Models.Itens
{
    /// <summary>
    /// Classe referente aos tipos de itens
    /// </summary>
    public class TipoItem
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome do tipo de item
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Coleção de itens deste tipo de item
        /// </summary>
        public virtual ICollection<Item>? Itens { get; set; }
    }
}
