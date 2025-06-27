using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Clientes
{
    /// <summary>
    /// Classe referente aos dependentes dos clientes
    /// </summary>
    public class DependenteCliente
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// 
        /// Required
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Retorna o Nome do dependente
        /// 
        /// Required
        /// </summary>
        public required string Nome { get; set; }
        /// <summary>
        /// Retorna a data de aniversário do dependente
        /// 
        /// Required
        /// </summary>
        public DateOnly DataAniversario { get; set; }
        /// <summary>
        /// Retorna o Id do registro do cliente responsável pelo dependente
        /// 
        /// Required
        /// </summary>
        public int ResponsavelId { get; set; }
        /// <summary>
        /// Instância do cliente responsável pelo dependente
        /// </summary>
        public required Cliente ResponsavelInstance { get; set; }
        /// <summary>
        /// Retorna o Id do registro do gênero do dependente
        /// </summary>
        public int GeneroId { get; set; }
        /// <summary>
        /// Instância do gênero do dependente
        /// </summary>
        public required Genero GeneroInstance { get; set; }

        /// <summary>
        /// Retorna a lista de decorações associadas a este dependente
        /// </summary>
        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
