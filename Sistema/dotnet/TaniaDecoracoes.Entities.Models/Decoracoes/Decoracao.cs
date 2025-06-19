using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.Clientes;
using TaniaDecoracoes.Entities.Models.Enderecos;
using TaniaDecoracoes.Entities.Models.Pagamentos;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Decoracoes
{
    public class Decoracao
    {
        public int Id { get; set; }
        public required DateOnly DataCadastro { get; set; }

        public int ClienteId { get; set; }
        public required Cliente ClienteInstance { get; set; }

        public int? ComemorandoId { get; set; }
        public DependenteCliente? ComemorandoInstance { get; set; }

        public int? EnderecoEventoId { get; set; }
        public EnderecoEvento? EnderecoEventoInstance { get; set; }

        public int TipoEventoId { get; set; }
        public required TipoEvento TipoEventoInstance { get; set; }

        public int? TemaAniversarioId { get; set; }
        public TemaAniversario? TemaAniversarioInstance { get; set; }

        public int CarroUtilizadoId { get; set; }
        public required Carro CarroUtilizadoInstance { get; set; }

        public float? DistanciaDeCasa { get; set; }
        public decimal? ValorSugerido {  get; set; }
        public required decimal ValorCobrado { get; set; }
        public decimal? Lucro {  get; set; }
        public DateTime? DataEvento { get; set; }
        public DateTime? DataHoraMontagem { get; set; }

        /*public required byte _pegueEMonte;
        public bool PegueEMonte {

            get => _pegueEMonte == 1;

            set 
            { 
                _pegueEMonte = (byte)(value ? 1 : 0); 
            }
        }*/

        public bool PegueEMonte { get; set; }

        public DecoracaoPagamento? DecoracaoPagamentosInstance { get; set; }
        public DecoracaoCustos? DecoracaoCustosInstance { get; set; }
        public ICollection<AssociacaoDecoracaoFlores>? AssociacaoDecoracaoFlores { get; set; }
        public ICollection<AssociacaoDecoracaoItens>? AssociacaoDecoracaoItens { get; set; }
    }
}
