using TaniaDecoracoesSystem.Entities.Models.Decoracoes;
using TaniaDecoracoesSystem.Entities.Models.Enderecos;
using TaniaDecoracoesSystem.Entities.Models.TabelasGerais;

namespace TaniaDecoracoesSystem.Entities.Models.Clientes
{
    public class Cliente
    {
        public required int Id { get; set; }
        public required DateOnly DataCadastro { get; set; }
        public required string Nome { get; set; }
        public string? Apelido { get; set; }
        public DateOnly? DataNascimento { get; set; }

        public int? GeneroId { get; set; }
        public Genero? GeneroInstance { get; set; }

        public required int EnderecoCliente { get; set; }
        public required EnderecoCliente EnderecoClienteInstance {  get; set; }

        public required string TelefoneCelular { get; set; }
        public string? Cpf { get; set; }

        public ICollection<DependentesCliente>? DependentesClientes { get; set; }
        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
