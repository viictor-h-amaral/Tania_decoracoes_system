using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Pagamentos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Pagamentos
{
    public class FormaPagamentoDto
    {
        public FormaPagamentoDto()
        {
            
        }
        public FormaPagamentoDto(FormaPagamento formaPagamento)
        {
            this.Id = formaPagamento.Id;
            this.Nome = formaPagamento.Nome;
            this.Parcelado = formaPagamento.Parcelado;
            this.NumeroParcelas = formaPagamento.NumeroParcelas;
            this.TaxaParcelamentoIdentificacao = formaPagamento.TaxaParcelamentoInstance?.Identificacao;
        }

        public int Id { get; set; }

        public required string Nome { get; set; }

        public bool Parcelado { set; get; }

        public int? NumeroParcelas { get; set; }
        
        public string? TaxaParcelamentoIdentificacao { get; set; }
    }
}
