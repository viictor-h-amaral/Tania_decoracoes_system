using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Pagamentos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Pagamentos
{
    public class TaxaParcelamentoDto
    {
        public TaxaParcelamentoDto()
        {
            
        }

        public TaxaParcelamentoDto(TaxaParcelamento taxaParcelamento)
        {
            this.Id = taxaParcelamento.Id;
            this.Juros = taxaParcelamento.Juros;
            this.Meses = taxaParcelamento.Meses;
            this.JurosCompostos = taxaParcelamento.JurosCompostos;
        }

        public int Id { get; set; }

        public decimal Juros { get; set; }

        public int Meses { get; set; }

        public bool JurosCompostos { get; set; }
    }
}
