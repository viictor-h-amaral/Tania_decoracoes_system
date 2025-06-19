using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Pagamentos
{
    public class TaxaParcelamento
    {
        public int Id { get; set; }
        public decimal Juros { get; set; }
        public int Meses { get; set; }

        private byte? _jurosCompostos;
        public bool? JurosCompostos {
            get => _jurosCompostos is null ? null : _jurosCompostos == 1 ;
            set => _jurosCompostos = (value is null ? null : (value.Value ? (byte)1 : (byte)0));
        }

        public ICollection<FormaPagamento>? FormasPagamento { get; set; }
    }
}
