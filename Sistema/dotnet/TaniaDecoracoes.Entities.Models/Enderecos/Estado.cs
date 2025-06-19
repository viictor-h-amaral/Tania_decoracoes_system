namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    public class Estado
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Sigla { get; set; }

        public ICollection<Municipio>? Municipios { get; set; }
        public ICollection<EnderecoCliente>? EnderecosClientes { get; set; }
        public ICollection<EnderecoEvento>? EnderecosEventos { get; set; }
    }
}
