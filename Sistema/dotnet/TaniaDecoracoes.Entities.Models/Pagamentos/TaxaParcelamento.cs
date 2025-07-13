using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Pagamentos
{
    /// <summary>
    /// Classe referente à taxa de parcelamento
    /// </summary>
    public class TaxaParcelamento
    {
        /// <summary>
        /// Retorna o Id da taxa de parcelamento
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna os Juros da taxa de parcelamento
        /// <para>Required</para>
        /// </summary>
        public decimal Juros { get; set; }

        /// <summary>
        /// Retorna a quantidade de meses para essa taxa de parcelamento
        /// <para>Required</para>
        /// </summary>
        public int Meses { get; set; }

        /// <summary>
        /// Retorna se a taxa de parcelamento será, ou não, por Juros compostos
        /// <para>Required</para>
        /// </summary>
        public bool JurosCompostos { get; set; }

        /// <summary>
        /// Retorna uma string com um resumo da taxa de parcelamento
        /// </summary>
        public string Identificacao => $@"{Meses} meses a {Juros}% de juros";

        /// <summary>
        /// Coleção das formas de pagamentos associadas à essa taxa de parcelamento
        /// </summary>
        public ICollection<FormaPagamento>? FormasPagamento { get; set; }
    }
}
