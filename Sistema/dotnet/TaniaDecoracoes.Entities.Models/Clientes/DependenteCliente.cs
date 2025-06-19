using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Clientes
{
    public class DependenteCliente
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required DateOnly DataAniversario { get; set; }

        public int ResponsavelId { get; set; }
        public required Cliente ResponsavelInstance { get; set; }

        public int GeneroId { get; set; }
        public required Genero GeneroInstance { get; set; }

        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
