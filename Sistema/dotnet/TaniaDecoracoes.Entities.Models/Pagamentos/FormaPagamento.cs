﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models.Pagamentos
{
    /// <summary>
    /// Classe referente à forma de pagamento
    /// </summary>
    public class FormaPagamento
    {
        /// <summary>
        /// Retorna o Id da forma de pagamento da entrada da decoração
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o nome da forma de pagamento
        /// <para>Required</para>
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Retorna se a forma de pagamento é, ou não é, parcelada
        /// <para>Required</para>
        /// </summary>
        public bool Parcelado { set; get; }

        /// <summary>
        /// Retorna o número de parcelas da forma de pagamento parcelada
        /// <para>Optional</para>
        /// </summary>
        public int? NumeroParcelas { get; set; }
        /// <summary>
        /// Retorna o Id da taxa de parcelamento da forma de pagamento
        /// <para>Optional</para>
        /// </summary>
        public int? TaxaParcelamentoId { get; set; }

        /// <summary>
        /// Instância da taxa de parcelamento da forma de pagamento
        /// </summary>
        public TaxaParcelamento? TaxaParcelamentoInstance { get; set; }

        /// <summary>
        /// Coleção de entradas de pagamentos de decorações associadas com essa forma de pagamento
        /// </summary>
        public ICollection<DecoracaoPagamento>? DecoracoesPagamentosEntradas { get; set; }

        /// <summary>
        /// Coleção de pagamentos restantes de decorações associados com essa forma de pagamento
        /// </summary>
        public ICollection<DecoracaoPagamento>? DecoracoesPagamentosRestante { get; set; }
    }
}
