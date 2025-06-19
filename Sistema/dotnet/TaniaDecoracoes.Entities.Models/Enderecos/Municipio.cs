namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    public class Municipio
    {
        public int Id { get; set; }

        public int EstadoId { get; set; }
        public required Estado EstadoInstance { get; set; }

        public required string Nome { get; set; }
        public int? CodigoIBGE { get; set; }

        public ICollection<Bairro>? Bairros { get; set; }
        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }
        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
