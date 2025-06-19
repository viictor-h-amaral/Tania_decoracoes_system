using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Enderecos;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Clientes
{
    public class Cliente
    {
        public int Id { get; set; }
        public DateOnly DataCadastro { get; set; }
        public required string Nome { get; set; }
        public string? Apelido { get; set; }
        public DateOnly? DataNascimento { get; set; }

        public int? GeneroId { get; set; }
        public Genero? GeneroInstance { get; set; }

        public int EnderecoClienteId { get; set; }
        public required EnderecoCliente EnderecoClienteInstance {  get; set; }

        public required string TelefoneCelular { get; set; }
        public string? Cpf { get; set; }

        public ICollection<DependenteCliente>? DependentesClientes { get; set; }
        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
