namespace TaniaDecoracoes.Entities.Models.Decoracoes
{
    /// <summary>
    /// Classe referente aos tipos de eventos
    /// </summary>
    public partial class TipoEvento
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome do tipo de evento
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }


        /// <summary>
        /// Decorações com este tipo de evento
        /// </summary>
        public virtual ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
