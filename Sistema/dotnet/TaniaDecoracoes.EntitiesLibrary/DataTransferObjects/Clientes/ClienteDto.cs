using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Clientes;
using TaniaDecoracoes.Entities.Models.Enderecos;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Clientes
{
    public class ClienteDto
    {
        public ClienteDto()
        {
            
        }
        public ClienteDto(Cliente cliente)
        {
            this.Id = cliente.Id;
            this.DataCadastro = cliente.DataCadastro;
            this.Nome = cliente.Nome;
            this.Apelido = cliente.Apelido;
            this.DataNascimento = cliente.DataNascimento;
            this.GeneroNome = cliente.GeneroInstance?.Letra?.ToString();

            var enderecoCliente = cliente.EnderecoClienteInstance;
            this. EnderecoCliente = $"{enderecoCliente.LogradouroInstance.Nome}, " +
                                    $"{enderecoCliente.BairroInstance.Nome} - " +
                                    $"{enderecoCliente.MunicipioInstance.Nome}";

            this.TelefoneCelular = cliente.TelefoneCelular;
            this.Cpf = cliente.Cpf;
        }

        public int Id { get; set; }

        public DateOnly DataCadastro { get; set; }

        public required string Nome { get; set; }

        public string? Apelido { get; set; }

        public DateOnly? DataNascimento { get; set; }

        public string? GeneroNome { get; set; }

        public string? EnderecoCliente { get; set; }

        public required string TelefoneCelular { get; set; }

        public string? Cpf { get; set; }
    }
}
