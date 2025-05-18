using TaniaDecoracoesSystem.Entities.Models.Clientes;

namespace TaniaDecoracoesSystem.Entities.Models.Enderecos
{
    public class EnderecoCliente
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

        public required int TipoEnderecoClienteId { get; set; }
        public required TipoEnderecoCliente TipoEnderecoClienteInstance { get; set; }

        public required int NumeroEndereco { get; set; }

        public string? Observacoes { get; set; }
        public int? AndarApartamento { get; set; }
        public int? NumeroApartamento { get; set; }

        public ICollection<Cliente>? Clientes { get; set; }
    }
}
