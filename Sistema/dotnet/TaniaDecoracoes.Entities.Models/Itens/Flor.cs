using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Itens
{
    /// <summary>
    /// Classe referente às flores do sistema
    /// </summary>
    public class Flor
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome da flor
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Retorna o preço da flor em época de temporada
        /// <para>Optional</para>
        /// </summary>
        public decimal? PrecoTemporada { get; set; }

        /// <summary>
        /// Retorna o preço padrão da flor
        /// <para>Required</para>
        /// </summary>
        public decimal PrecoPadrao { get; set; }

        /// <summary>
        /// Retorna o endereço da imagem da flor
        /// <para>Optional</para>
        /// </summary>
        public string? EnderecoImagem { get; set; }

        /// <summary>
        /// Retorna o Id da cor da flor
        /// <para>Optional</para>
        /// </summary>
        public int? CorId {  get; set; }

        /// <summary>
        /// Instância da cor da flor
        /// </summary>
        public virtual Cor? CorInstance { get; set; }

        /// <summary>
        /// Coleção de associações entre decorações e esta flor
        /// </summary>
        public virtual ICollection<AssociacaoDecoracaoFlores>? AssociacaoDecoracaoFlores { get; set; }
    }
}
