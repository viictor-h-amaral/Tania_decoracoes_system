using TaniaDecoracoes.Entities.Models.Clientes;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    /// <summary>
    /// Classe referente aos gêneros do sistema
    /// </summary>
    public class Genero
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome do gênero
        /// <para>Required</para>
        /// </summary>
        public required string Sexo { get; set; }

        /// <summary>
        /// Retorna a abreviatura do gênero
        /// <para>Optional</para>
        /// </summary>
        public char? Letra { get; set; }

        /// <summary>
        /// Coleção de clientes associados a esse gênero
        /// </summary>
        public ICollection<Cliente>? Clientes { get; set; }

        /// <summary>
        /// Coleção de dependentes de clientes
        /// </summary>
        public ICollection<DependenteCliente>? DependentesClientes { get; set; }
    }
}
