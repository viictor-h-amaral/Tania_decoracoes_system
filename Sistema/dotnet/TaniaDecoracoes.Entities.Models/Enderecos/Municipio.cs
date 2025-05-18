namespace TaniaDecoracoesSystem.Entities.Models.Enderecos
{
    public class Municipio
    {
        public required int Id { get; set; }

        public required int EstadoId { get; set; }
        public required Estado EstadoInstance { get; set; }

        public required string Nome { get; set; }
        public int? CodigoIBGE { get; set; }

        public ICollection<Bairro>? Bairros { get; set; }
        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }
        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
