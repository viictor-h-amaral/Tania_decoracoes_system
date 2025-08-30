using TaniaDecoracoes.Entities.Models.Attributes;

namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos logradouros
    /// </summary>
    public class Logradouro
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id do bairro associado ao logradouro
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int BairroId { get; set; }

        /// <summary>
        /// Instância do bairro associado ao logradouro
        /// </summary>
        [BindingAttribute(fieldName: "Nome")]
        public virtual required Bairro BairroInstance { get; set; }

        /// <summary>
        /// Retorna o nome do logradouro
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Retorna o Id do tipo de logradouro
        /// <para>Optional</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int? TipoLogradouroId { get; set; }

        /// <summary>
        /// Instância do tipo de logradouro
        /// </summary>
        [BindingAttribute(fieldName: "Nome")]
        [TitleAttribute(title: "Tipo de logradouro")]
        public virtual TipoLogradouro? TipoLogradouroInstance { get; set; }

        [IgnoreOnForm]
        [IgnoreOnGrid]
        public string Identificacao => $"{(TipoLogradouroInstance?.Nome+" ") ?? string.Empty}{Nome}";

        /// <summary>
        /// Coleção de CEPs associados a este logradouro
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Cep>? Ceps { get; set; }

        /// <summary>
        /// Coleção de endereços de clientes associados a este logradouro
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<EnderecoCliente>? EnderecosClientes { get; set; }

        /// <summary>
        /// Coleção de endereços de eventos associados a este logradouro
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
