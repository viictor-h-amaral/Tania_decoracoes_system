using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.Entities.Models.Clientes;
using TaniaDecoracoes.Entities.Models.Enderecos;
using TaniaDecoracoes.Entities.Models.Pagamentos;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Decoracoes
{
    /// <summary>
    /// Classe referente às decorações
    /// </summary>
    public partial class Decoracao
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int Id { get; set; }

        /// <summary>
        /// Retorna a data de cadastro da decoração
        /// <para>Required</para>
        /// </summary>
        [TitleAttribute(title: "Data de cadastro")]
        public DateOnly DataCadastro { get; set; }

        /// <summary>
        /// Reotorna o Id do cliente associado à decoração
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int ClienteId { get; set; }

        /// <summary>
        /// Instância do cliente associado à decoração
        /// </summary>
        public virtual required Cliente ClienteInstance { get; set; }

        /// <summary>
        /// Retorna o Id do dependente do cliente associado à decoração
        /// <para>Optional</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int? ComemorandoId { get; set; }

        /// <summary>
        /// Instância do dependente do cliente associado à decoração
        /// </summary>
        public virtual DependenteCliente? ComemorandoInstance { get; set; }

        /// <summary>
        /// Retorna o Id do registro do endereço do evento
        /// <para>Opcional enquanto não houver um endereço definido ou confirmação do evento</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int? EnderecoEventoId { get; set; }

        /// <summary>
        /// Retorna a instância do endereço do evento
        /// </summary>
        [TitleAttribute(title : "Endereço do evento")]
        public virtual EnderecoEvento? EnderecoEventoInstance { get; set; }

        /// <summary>
        /// Retorna o Id do registro do tipo de evento da decoração
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int TipoEventoId { get; set; }

        /// <summary>
        /// Instância do tipo de evento da decoração
        /// </summary>
        [TitleAttribute(title: "Tipo do evento")]
        public virtual required TipoEvento TipoEventoInstance { get; set; }

        /// <summary>
        /// Retorna o Id do registro do tema de aniversário da decoração
        /// <para>Opcional quando não for aniversário</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int? TemaAniversarioId { get; set; }

        /// <summary>
        /// Instância do tema de aniversário da decoração
        /// </summary>
        [TitleAttribute(title: "Tema do aniversário")]
        public virtual TemaAniversario? TemaAniversarioInstance { get; set; }

        /// <summary>
        /// Retorna o Id do registro do carro utilizado na decoração
        /// <para>Required</para>
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public int CarroUtilizadoId { get; set; }

        /// <summary>
        /// Instância do carro utilizado na decoração
        /// </summary>
        public virtual required Carro CarroUtilizadoInstance { get; set; }

        /// <summary>
        /// Retorna a distância (em km) de casa até o local do evento
        /// <para>Optional</para>
        /// </summary>
        public float? DistanciaDeCasa { get; set; }

        /// <summary>
        /// Retorna o valor sugerido pelo sistema para a decoração
        /// <para>Optional</para>
        /// </summary>
        public decimal? ValorSugerido {  get; set; }

        /// <summary>
        /// Retorna o valor cobrado pelo serviço de decoração
        /// <para>Required</para>
        /// </summary>
        public decimal ValorCobrado { get; set; }

        /// <summary>
        /// Retorna o valor do lucro da decoração
        /// <para>Optional</para>>
        /// </summary>
        public decimal? Lucro {  get; set; }

        /// <summary>
        /// Retorna a data e hora do evento
        /// <para>Optional</para>
        /// </summary>
        [TitleAttribute(title: "Data do evento")]
        public DateTime? DataEvento { get; set; }

        /// <summary>
        /// Retorna a data e hora da montagem da decoração
        /// <para>Optional</para>
        /// </summary>
        public DateTime? DataHoraMontagem { get; set; }

        /// <summary>
        /// Reotorna se a decoração é, ou não, pegue e monte
        /// <para>Required</para>
        /// </summary>
        [TitleAttribute(title: "Pegue e monte?")]
        public bool PegueEMonte { get; set; }

        /// <summary>
        /// Instância do pagamento da decoração
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual DecoracaoPagamento? DecoracaoPagamentosInstance { get; set; }

        /// <summary>
        /// Instância dos custos da decoração
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual DecoracaoCustos? DecoracaoCustosInstance { get; set; }

        /// <summary>
        /// Retorna uma string com identificação básica da decoração
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public string Identificacao => @$"{ClienteInstance.Nome} 
                                                - {(DataEvento.HasValue ?
                                                        DataEvento.Value.ToString("dd/MM/yy")
                                                        : DataCadastro.ToString("dd/MM/yy"))}
                                                - {TipoEventoInstance.Nome}";

        /// <summary>
        /// Associações entre decoração e flores
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<AssociacaoDecoracaoFlores>? AssociacaoDecoracaoFlores { get; set; }

        /// <summary>
        /// Associação entre decoração e itens
        /// </summary>
        [IgnoreOnForm]
        [IgnoreOnGrid]
        public virtual ICollection<AssociacaoDecoracaoItens>? AssociacaoDecoracaoItens { get; set; }
    }
}
