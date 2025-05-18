using TaniaDecoracoesSystem.Entities.Models.Clientes;
using TaniaDecoracoesSystem.Entities.Models.Enderecos;
using TaniaDecoracoesSystem.Entities.Models.TabelasGerais;

namespace TaniaDecoracoesSystem.Entities.Models.Decoracoes
{
    public class Decoracao
    {
        public required int Id { get; set; }
        public required DateOnly DataCadastro { get; set; }

        public required int ClienteId { get; set; }
        public required Cliente ClienteInstance { get; set; }

        public int? ComemorandoId { get; set; }
        public DependentesCliente? ComemorandoInstance { get; set; }

        public int? EnderecoEventoId { get; set; }
        public EnderecoEvento? EnderecoEventoInstance { get; set; }

        public required int TipoEventoId { get; set; }
        public required TipoEvento TipoEventoInstance { get; set; }

        public int? TemaAniversarioId { get; set; }
        public TemaAniversario? TemaAniversarioInstance { get; set; }

        public required int CarroUtilizadoId { get; set; }
        public required Carro CarroUtilizadoInstance { get; set; }

        public float? DistanciaDeCasa { get; set; }
        public decimal? ValorSugerido {  get; set; }
        public required decimal ValorCobrado { get; set; }
        public decimal? Lucro {  get; set; }
        public DateTime? DataEvento { get; set; }
        public DateTime? DataHoraMontagem { get; set; }
    }
}
