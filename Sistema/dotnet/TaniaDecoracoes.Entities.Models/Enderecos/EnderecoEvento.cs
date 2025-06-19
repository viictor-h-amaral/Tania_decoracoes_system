using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    public class EnderecoEvento
    {
        public int Id { get; set; }

        public int EstadoId { get; set; }
        public required Estado EstadoInstance { get; set; }

        public int MunicipioId { get; set; }
        public required Municipio MunicipioInstance { get; set; }

        public int BairroId { get; set; }
        public required Bairro BairroInstance { get; set; }

        public int LogradouroId { get; set; }
        public required Logradouro LogradouroInstance { get; set; }

        public int TipoEnderecoEventoId { get; set; }
        public required TipoEnderecoEvento TipoEnderecoEventoInstance { get; set; }

        public int NumeroEndereco { get; set; }
        public required string Apelido { get; set; }

        public string? Observacoes { get; set; }
        public int? AndarApartamento { get; set; }
        public int? NumeroApartamento { get; set; }

        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
