namespace TaniaDecoracoes.Entities.Models.Decoracoes
{
    /// <summary>
    /// Classe referente aos temas de aniversário
    /// </summary>
    public class TemaAniversario
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// 
        /// Required
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Retorna o nome do tema de aniversário
        /// 
        /// Required
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Decorações com este tema de aniversário
        /// </summary>
        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
