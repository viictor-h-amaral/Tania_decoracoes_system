namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos tipos de logradouros
    /// </summary>
    public class TipoLogradouro
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Retorna o Nome do tipo de logradouro
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Coleção de logradouros tipo de logradouro
        /// </summary>
        public ICollection<Logradouro>? Logradouros { get; set; }
    }
}
