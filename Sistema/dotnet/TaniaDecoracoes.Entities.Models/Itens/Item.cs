using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Itens
{
    public class Item
    {
        public int Id { get; set; }
        public string? Apelido { get; set; }

        public int TipoItemId { get; set; }
        public required TipoItem TipoItemInstance { get; set; }

        public int QuantidadeEstoque { get; set; }
        public decimal? Preco {  get; set; }

        public int? CorId { get; set; }
        public Cor? CorInstance { get; set; }

        public int? TamanhoId { get; set; }
        public Tamanho? TamanhoInstance { get; set; }

        public float? Altura { get; set; }
        public float? Comprimento { get; set; }
        public float? Largura { get; set; }
        public string? EnderecoImagem { get; set; }

        public ICollection<AssociacaoDecoracaoItens>? AssociacaoDecoracaoItens { get; set; }

    }
}
