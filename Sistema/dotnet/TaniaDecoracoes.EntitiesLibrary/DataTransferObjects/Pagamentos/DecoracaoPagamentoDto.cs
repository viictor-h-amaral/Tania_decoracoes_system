using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Pagamentos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Pagamentos
{
    public class DecoracaoPagamentoDto
    {
        public DecoracaoPagamentoDto()
        {
            
        }
        public DecoracaoPagamentoDto(DecoracaoPagamento decoracaoPagamento)
        {
            this.Id = decoracaoPagamento.Id;
            this.DecoracaoIdentificacao = decoracaoPagamento.DecoracaoInstance.Identificacao;
            this.ValorEntrada = decoracaoPagamento.ValorEntrada;
            this.FormaPagamentoEntradaNome = decoracaoPagamento.FormaPagamentoEntradaInstance.Nome;
            this.DataPagamentoEntrada = decoracaoPagamento.DataPagamentoEntrada;
            this.ValorRestante = decoracaoPagamento.ValorRestante;
            this.FormaPagamentoRestanteNome = decoracaoPagamento.FormaPagamentoRestanteInstance.Nome;
        }

        public int Id { get; set; }

        public string? DecoracaoIdentificacao { get; set; }

        public decimal ValorEntrada { get; set; }
        public string? FormaPagamentoEntradaNome { get; set; }


        public DateOnly? DataPagamentoEntrada { get; set; }

        public decimal ValorRestante { get; set; }
        public string FormaPagamentoRestanteNome { get; set; }


    }
}
