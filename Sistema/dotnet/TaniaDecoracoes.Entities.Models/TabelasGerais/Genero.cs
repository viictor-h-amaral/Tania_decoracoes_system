using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.Entities.Models.Clientes;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    /// <summary>
    /// Classe referente aos gêneros do sistema
    /// </summary>
    public class Genero : IEntityModel
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
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

        [IgnoreOnForm]
        [IgnoreOnGrid]
        public string Identificacao => Letra.HasValue ? Letra.Value.ToString() : Sexo;

        /// <summary>
        /// Coleção de clientes associados a esse gênero
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Cliente>? Clientes { get; set; }

        /// <summary>
        /// Coleção de dependentes de clientes
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<DependenteCliente>? DependentesClientes { get; set; }
    }
}
