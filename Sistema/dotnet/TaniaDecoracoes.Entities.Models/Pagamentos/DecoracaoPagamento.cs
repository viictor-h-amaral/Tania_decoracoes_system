using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.Entities.Models.Pagamentos
{
    public class DecoracaoPagamento
    {
        public int Id { get; set; }

        public int DecoracaoId { get; set; }
        public required Decoracao DecoracaoInstance { get; set; }

        public int FormaPagamentoEntradaId { get; set; }
        public required FormaPagamento FormaPagamentoEntradaInstance { get; set; }
        public decimal ValorEntrada { get; set; }
        public DateOnly? DataPagamentoEntrada { get; set; }

        public int FormaPagamentoRestanteId { get; set; }
        public required FormaPagamento FormaPagamentoRestanteInstance { get; set; }
        public decimal ValorRestante { get; set; }
        public DateOnly? DataPagamentoRestante { get; set; }

        public decimal? ValorParcelaRestante { get; set; }

    }
}
