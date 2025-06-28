namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos bairros
    /// </summary>
    public class Bairro
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Retorna o Id do registro do município do bairro
        /// <para>Required</para>
        /// </summary>
        public int MunicipioId { get; set; }
        /// <summary>
        /// Instância do município do bairro
        /// </summary>
        public required Municipio MunicipioInstance { get; set; }
        /// <summary>
        /// Retorna o Nome do bairro
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Logradouros associados a este bairro
        /// </summary>
        public ICollection<Logradouro>? Logradouros { get; set; }
        /// <summary>
        /// Endereços de clientes associados a este bairro
        /// </summary>
        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }
        /// <summary>
        /// Endereços de eventos associados a este bairros
        /// </summary>
        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
