namespace TaniaDecoracoesSystem.Entities.Models.Enderecos
{
    public class Bairro
    {
        public required int Id { get; set; }
        public required int MunicipioId { get; set; }
        public required Municipio MunicipioInstance { get; set; }
        public required string Nome { get; set; }

        public ICollection<Logradouro>? Logradouros { get; set; }
        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }
        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
