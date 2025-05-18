namespace TaniaDecoracoesSystem.Entities.Models.TabelasGerais
{
    public class TipoCombustivel
    {
        public int Id { get; set; }
        public required string NomeCombustivel { get; set; }

        public ICollection<Carro>? Carros { get; set; }
        public ICollection<CustoCombustivel>? CustosCombustiveis { get; set; }
    }
}
