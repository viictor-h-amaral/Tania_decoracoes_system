using TaniaDecoracoesSystem.Entities.Models.Decoracoes;

namespace TaniaDecoracoesSystem.Entities.Models.Enderecos
{
    public class EnderecoEvento
    {
        public required int Id { get; set; }

        public required int EstadoId { get; set; }
        public required Estado EstadoInstance { get; set; }

        public required int MunicipioId { get; set; }
        public required Municipio MunicipioInstance { get; set; }

        public required int BairroId { get; set; }
        public required Bairro BairroInstance { get; set; }

        public required int LogradouroId { get; set; }
        public required Logradouro LogradouroInstance { get; set; }

        public required int TipoEnderecoEventoId { get; set; }
        public required TipoEnderecoEvento TipoEnderecoEventoInstance { get; set; }

        public required int NumeroEndereco { get; set; }
        public required string Apelido { get; set; }

        public string? Observacoes { get; set; }
        public int? AndarApartamento { get; set; }
        public int? NumeroApartamento { get; set; }

        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
