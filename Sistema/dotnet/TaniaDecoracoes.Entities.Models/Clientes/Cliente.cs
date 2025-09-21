using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Enderecos;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Clientes
{
    /// <summary>
    /// Classe referente aos clientes 
    /// </summary>
    public partial class Cliente : IEntityModel
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna a data de cadastro do cliente
        /// <para>Required</para>
        /// </summary>
        [TitleAttribute("Data de cadastro")]
        public DateOnly DataCadastro { get; set; }

        /// <summary>
        /// Retorna o nome do cliente
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Retorna o apelido do cliente
        /// <para>Optional</para>
        /// </summary>
        public string? Apelido { get; set; }

        /// <summary>
        /// Retorna a data de nascimento do cliente
        /// <para>Optional</para>
        /// </summary>
        [TitleAttribute("Data de nascimento")]
        public DateOnly? DataNascimento { get; set; }

        /// <summary>
        /// Retorna o Id do registro do gênero do cliente
        /// <para>Optional</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int? GeneroId { get; set; }

        /// <summary>
        /// Instncia do gênero do cliente
        /// </summary>
        [BindingAttribute(fieldName: "Identificacao")]
        [TitleAttribute(title: "Gênero")]
        public virtual Genero? GeneroInstance { get; set; }

        /// <summary>
        /// Retorna o Id do registro do endereço do cliente
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int EnderecoClienteId { get; set; }

        /// <summary>
        /// Instância do endereço do cliente
        /// </summary>
        [BindingAttribute(fieldName: "Identificacao")]
        [TitleAttribute(title: "Endereco do cliente")]
        public virtual required EnderecoCliente EnderecoClienteInstance {  get; set; }

        /// <summary>
        /// Retorna o telefone celular do cliente
        /// <para>Required</para>
        /// </summary>
        public required string TelefoneCelular { get; set; }

        /// <summary>
        /// Retorna o Cpf do cliente
        /// <para>Optional</para>
        /// </summary>
        public string? Cpf { get; set; }

        /// <summary>
        /// Retorna os dependentes do cliente
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<DependenteCliente>? DependentesClientes { get; set; }

        /// <summary>
        /// Retorna as decorações feitas para o cliente
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
