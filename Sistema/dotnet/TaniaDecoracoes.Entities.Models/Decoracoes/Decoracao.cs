using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.Clientes;
using TaniaDecoracoes.Entities.Models.Enderecos;
using TaniaDecoracoes.Entities.Models.Pagamentos;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Decoracoes
{
    /// <summary>
    /// Classe referente às decorações
    /// </summary>
    public class Decoracao
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retorna a data de cadastro da decoração
        /// <para>Required</para>
        /// </summary>
        public DateOnly DataCadastro { get; set; }

        /// <summary>
        /// Reotorna o Id do cliente associado à decoração
        /// <para>Required</para>
        /// </summary>
        public int ClienteId { get; set; }

        /// <summary>
        /// Instância do cliente associado à decoração
        /// </summary>
        public required Cliente ClienteInstance { get; set; }

        /// <summary>
        /// Retorna o Id do dependente do cliente associado à decoração
        /// <para>Optional</para>
        /// </summary>
        public int? ComemorandoId { get; set; }

        /// <summary>
        /// Instância do dependente do cliente associado à decoração
        /// </summary>
        public DependenteCliente? ComemorandoInstance { get; set; }

        /// <summary>
        /// Retorna o Id do registro do endereço do evento
        /// <para>Opcional enquanto não houver um endereço definido ou confirmação do evento</para>
        /// </summary>
        public int? EnderecoEventoId { get; set; }

        /// <summary>
        /// Retorna a instância do endereço do evento
        /// </summary>
        public EnderecoEvento? EnderecoEventoInstance { get; set; }

        /// <summary>
        /// Retorna o Id do registro do tipo de evento da decoração
        /// <para>Required</para>
        /// </summary>
        public int TipoEventoId { get; set; }

        /// <summary>
        /// Instância do tipo de evento da decoração
        /// </summary>
        public required TipoEvento TipoEventoInstance { get; set; }

        /// <summary>
        /// Retorna o Id do registro do tema de aniversário da decoração
        /// <para>Opcional quando não for aniversário</para>
        /// </summary>
        public int? TemaAniversarioId { get; set; }

        /// <summary>
        /// Instância do tema de aniversário da decoração
        /// </summary>
        public TemaAniversario? TemaAniversarioInstance { get; set; }

        /// <summary>
        /// Retorna o Id do registro do carro utilizado na decoração
        /// <para>Required</para>
        /// </summary>
        public int CarroUtilizadoId { get; set; }

        /// <summary>
        /// Instância do carro utilizado na decoração
        /// </summary>
        public required Carro CarroUtilizadoInstance { get; set; }

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
        public bool PegueEMonte { get; set; }


        /// <summary>
        /// Instância do pagamento da decoração
        /// </summary>
        public DecoracaoPagamento? DecoracaoPagamentosInstance { get; set; }

        /// <summary>
        /// Instância dos custos da decoração
        /// </summary>
        public DecoracaoCustos? DecoracaoCustosInstance { get; set; }

        /// <summary>
        /// Associações entre decoração e flores
        /// </summary>
        public ICollection<AssociacaoDecoracaoFlores>? AssociacaoDecoracaoFlores { get; set; }

        /// <summary>
        /// Associação entre decoração e itens
        /// </summary>
        public ICollection<AssociacaoDecoracaoItens>? AssociacaoDecoracaoItens { get; set; }
    }
}
