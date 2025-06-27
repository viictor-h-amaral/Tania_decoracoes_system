using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Enderecos;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Clientes
{
    /// <summary>
    /// Classe referente aos clientes 
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// <para>Required</para>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna a data de cadastro do cliente
        /// <para>Required</para>
        /// </summary>
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
        public DateOnly? DataNascimento { get; set; }

        /// <summary>
        /// Retorna o Id do registro do gênero do cliente
        /// <para>Optional</para>
        /// </summary>
        public int? GeneroId { get; set; }

        /// <summary>
        /// Instncia do gênero do cliente
        /// </summary>
        public Genero? GeneroInstance { get; set; }

        /// <summary>
        /// Retorna o Id do registro do endereço do cliente
        /// <para>Required</para>
        /// </summary>
        public int EnderecoClienteId { get; set; }

        /// <summary>
        /// Instâia do endereço do cliente
        /// </summary>
        public required EnderecoCliente EnderecoClienteInstance {  get; set; }

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
        public ICollection<DependenteCliente>? DependentesClientes { get; set; }

        /// <summary>
        /// Retorna as decorações feitas para o cliente
        /// </summary>
        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
