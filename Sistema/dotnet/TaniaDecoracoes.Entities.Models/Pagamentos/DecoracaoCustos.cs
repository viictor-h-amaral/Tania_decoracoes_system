using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.Entities.Models.Pagamentos
{
    public class DecoracaoCustos
    {
        public int Id { get; set; }
        public int  DecoracaoId { get; set; }
        public required Decoracao  DecoracaoInstance { get; set; }
        public decimal? CustoCalculado { get; set; }
        public decimal? CustoFlores { get; set; }
        public decimal? CustoBaloes { get; set; }
        public decimal? CustoMoveis { get; set; }
        public decimal? CustosExtras { get; set; }
        public decimal CustosCombustivel { get; set; }
        public decimal CustoTotal { get; set; }
    }
}
