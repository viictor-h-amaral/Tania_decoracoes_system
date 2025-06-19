using TaniaDecoracoes.Entities.Models.Clientes;

namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    public class EnderecoCliente
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

        public int TipoEnderecoClienteId { get; set; }
        public required TipoEnderecoCliente TipoEnderecoClienteInstance { get; set; }

        public int NumeroEndereco { get; set; }

        public string? Observacoes { get; set; }
        public int? AndarApartamento { get; set; }
        public int? NumeroApartamento { get; set; }

        public ICollection<Cliente>? Clientes { get; set; }
    }
}
