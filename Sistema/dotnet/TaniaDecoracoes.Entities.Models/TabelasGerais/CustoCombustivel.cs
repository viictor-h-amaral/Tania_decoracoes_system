namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    public class CustoCombustivel
    {
        public int Id { get; set; }

        public int CombustivelId { get; set; }
        public required TipoCombustivel CombustivelInstance { get; set; }

        public decimal ReaisPorLitro { get; set; }
        public required DateOnly DataInicial { get; set; }
        public DateOnly? DataFinal { get; set; }
    }
}
