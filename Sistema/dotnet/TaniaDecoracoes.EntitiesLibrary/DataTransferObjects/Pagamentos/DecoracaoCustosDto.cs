using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Pagamentos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Pagamentos
{
    public class DecoracaoCustosDto
    {
        public DecoracaoCustosDto()
        {
            
        }

        public DecoracaoCustosDto(DecoracaoCustos decoracaoCustos)
        {
            this.Id = decoracaoCustos.Id;
            this.DecoracaoIdentificacao = decoracaoCustos.DecoracaoInstance.Identificacao;
            this.CustoCalculado = decoracaoCustos.CustoCalculado;
            this.CustoFlores = decoracaoCustos.CustoFlores;
            this.CustoBaloes = decoracaoCustos.CustoBaloes;
            this.CustoTotal = decoracaoCustos.CustoTotal;
        }

        public int Id { get; set; }

        public string? DecoracaoIdentificacao { get; set; }

        public decimal? CustoCalculado { get; set; }

        public decimal? CustoFlores { get; set; }

        public decimal? CustoBaloes { get; set; }

        public decimal CustoTotal { get; set; }
    }
}
