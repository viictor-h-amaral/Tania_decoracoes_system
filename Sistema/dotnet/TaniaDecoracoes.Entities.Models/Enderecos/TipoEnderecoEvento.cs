namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos tipos de endereço de evento
    /// </summary>
    public class TipoEnderecoEvento
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o tipo de endereço do evento
        /// <para>Required</para>
        /// </summary>
        public required string TipoEndereco { get; set; }

        /// <summary>
        /// Coleção de endereços de eventos deste tipo de endereço
        /// </summary>
        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
