using TaniaDecoracoes.Entities.Models.Attributes;

namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos bairros
    /// </summary>
    public class Bairro
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }
        /// <summary>
        /// Retorna o Id do registro do município do bairro
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int MunicipioId { get; set; }

        /// <summary>
        /// Instância do município do bairro
        /// </summary>
        public virtual required Municipio MunicipioInstance { get; set; }

        /// <summary>
        /// Retorna o Nome do bairro
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Logradouros associados a este bairro
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Logradouro>? Logradouros { get; set; }

        /// <summary>
        /// Endereços de clientes associados a este bairro
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<EnderecoCliente>? EnderecosClientes { get; set; }
        /// <summary>
        /// Endereços de eventos associados a este bairros
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
