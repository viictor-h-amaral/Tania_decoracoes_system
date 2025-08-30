using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Clientes
{
    /// <summary>
    /// Classe referente aos dependentes dos clientes
    /// </summary>
    public partial class DependenteCliente
    {
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Nome do dependente
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Retorna a data de aniversário do dependente
        /// <para>Required</para>
        /// </summary>
        [TitleAttribute(title: "Data de aniversário")]
        public DateOnly DataAniversario { get; set; }

        /// <summary>
        /// Retorna o Id do registro do cliente responsável pelo dependente
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int ResponsavelId { get; set; }

        /// <summary>
        /// Instância do cliente responsável pelo dependente
        /// </summary>
        [BindingAttribute(fieldName: "Nome")]
        [TitleAttribute(title: "Responsável")]
        public virtual required Cliente ResponsavelInstance { get; set; }

        /// <summary>
        /// Retorna o Id do registro do gênero do dependente
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int GeneroId { get; set; }

        /// <summary>
        /// Instância do gênero do dependente
        /// </summary>
        [BindingAttribute(fieldName: "Identificacao")]
        [TitleAttribute(title: "Gênero")]
        public virtual required Genero GeneroInstance { get; set; }

        public string Identificacao => $"{Nome}, {ResponsavelInstance.Nome}";
        /// <summary>
        /// Retorna a lista de decorações associadas a este dependente
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
