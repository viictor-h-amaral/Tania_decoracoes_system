using TaniaDecoracoesSystem.Entities.Models.TabelasGerais;

namespace TaniaDecoracoesSystem.Entities.Models.Itens
{
    public class Item
    {
        public required int Id { get; set; }
        public string? Apelido { get; set; }

        public required int TipoItemId { get; set; }
        public required TipoItem TipoItemInstance { get; set; }

        public required int quantidadeEstoque { get; set; }
        public decimal? Preco {  get; set; }

        public int? CorId { get; set; }
        public Cor? CorInstance { get; set; }

        public int? TamanhoId { get; set; }
        public Tamanho? TamanhoInstance { get; set; }

        public float? Altura { get; set; }
        public float? Comprimento { get; set; }
        public float? Largura { get; set; }
        public string? EnderecoImagem { get; set; }
    }
}
