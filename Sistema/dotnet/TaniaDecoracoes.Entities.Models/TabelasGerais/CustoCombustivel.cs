namespace TaniaDecoracoesSystem.Entities.Models.TabelasGerais
{
    public class CustoCombustivel
    {
        public required int Id { get; set; }

        public required int CombustivelId { get; set; }
        public required TipoCombustivel CombustivelInstance { get; set; }

        public required decimal ReaisPorLitro { get; set; }
        public required DateOnly DataInicial { get; set; }
        public DateOnly? DataFinal { get; set; }
    }
}
