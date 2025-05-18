using TaniaDecoracoesSystem.Entities.Models.Clientes;

namespace TaniaDecoracoesSystem.Entities.Models.TabelasGerais
{
    public class Genero
    {
        public required int Id { get; set; }
        public required string Sexo { get; set; }
        public char? Letra { get; set; }

        public ICollection<Cliente>? Clientes { get; set; }
        public ICollection<DependentesCliente>? DependentesClientes { get; set; }
    }
}
