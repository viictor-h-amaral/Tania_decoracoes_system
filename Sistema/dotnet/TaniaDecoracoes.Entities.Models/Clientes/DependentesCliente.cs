using TaniaDecoracoesSystem.Entities.Models.Decoracoes;
using TaniaDecoracoesSystem.Entities.Models.TabelasGerais;

namespace TaniaDecoracoesSystem.Entities.Models.Clientes
{
    public class DependentesCliente
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required DateOnly DataAniversario { get; set; }

        public required int ResponsavelId { get; set; }
        public required Cliente ResponsavelInstance { get; set; }

        public required int GeneroId { get; set; }
        public required Genero GeneroInstance { get; set; }

        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
