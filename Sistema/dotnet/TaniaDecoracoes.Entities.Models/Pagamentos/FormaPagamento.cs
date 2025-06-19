using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Pagamentos
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public required string Nome { get; set; }

        /*public byte _parcelado;
        public bool Parcelado
        {

            get => _parcelado == 1;

            set
            {
                _parcelado = (byte)(value ? 1 : 0);
            }
        }*/

        public bool Parcelado { set; get; }

        public int? NumeroParcelas { get; set; }
        public int? TaxaParcelamentoId { get; set; }
        public TaxaParcelamento? TaxaParcelamentoInstance { get; set; }

        public ICollection<DecoracaoPagamento>? DecoracoesPagamentosEntradas { get; set; }
        public ICollection<DecoracaoPagamento>? DecoracoesPagamentosRestante { get; set; }
    }
}
