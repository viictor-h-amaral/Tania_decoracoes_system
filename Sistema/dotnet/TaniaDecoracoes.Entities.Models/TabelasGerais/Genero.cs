using TaniaDecoracoes.Entities.Models.Clientes;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    public class Genero
    {
        public int Id { get; set; }
        public required string Sexo { get; set; }
        public char? Letra { get; set; }

        public ICollection<Cliente>? Clientes { get; set; }
        public ICollection<DependenteCliente>? DependentesClientes { get; set; }
    }
}
