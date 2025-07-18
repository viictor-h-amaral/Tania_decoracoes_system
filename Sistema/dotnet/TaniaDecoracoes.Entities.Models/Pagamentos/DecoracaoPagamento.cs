﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.Entities.Models.Pagamentos
{
    /// <summary>
    /// Classe referente ao pagamento das decorações
    /// </summary>
    public class DecoracaoPagamento
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna o Id da decoração
        /// <para>Required</para>
        /// </summary>
        public int DecoracaoId { get; set; }

        /// <summary>
        /// Instância da decoração
        /// </summary>
        public required Decoracao DecoracaoInstance { get; set; }

        /// <summary>
        /// Retorna o Id da forma de pagamento da entrada do pagamento da decoração
        /// <para>Required</para>
        /// </summary>
        public int FormaPagamentoEntradaId { get; set; }

        /// <summary>
        /// Instância da forma de pagamento da entrada do pagamento da decoração
        /// </summary>
        public required FormaPagamento FormaPagamentoEntradaInstance { get; set; }

        /// <summary>
        /// Retorna o valor da entrada do pagamento da decoração
        /// <para>Required</para>
        /// </summary>
        public decimal ValorEntrada { get; set; }

        /// <summary>
        /// Retorna a data (somente data) do pagamento da entrada
        /// <para>Optional</para>
        /// </summary>
        public DateOnly? DataPagamentoEntrada { get; set; }

        /// <summary>
        /// Retorna o Id da forma de pagamento do restante do pagamento da decoração
        /// <para>Required</para>
        /// </summary>
        public int FormaPagamentoRestanteId { get; set; }

        /// <summary>
        /// Instância da forma de pagamento do restante do pagamento da decoração
        /// </summary>
        public required FormaPagamento FormaPagamentoRestanteInstance { get; set; }

        /// <summary>
        /// Retorna o valor do restante do pagamento da decoração
        /// <para>Required</para>
        /// </summary>
        public decimal ValorRestante { get; set; }

        /// <summary>
        /// Retorna a data (somente data) do pagamento do restante
        /// <para>Optional</para>
        /// </summary>
        public DateOnly? DataPagamentoRestante { get; set; }


        /// <summary>
        /// Retorna o valor de cada parcela do restante pagamento
        /// <para>Optional</para>
        /// </summary>
        public decimal? ValorParcelaRestante { get; set; }

    }
}
