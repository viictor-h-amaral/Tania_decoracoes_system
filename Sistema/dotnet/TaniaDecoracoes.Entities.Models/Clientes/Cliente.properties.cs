using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Clientes
{
    public partial class Cliente
    {
        public class Fields
        {
            public const string Id = "ID";
            public const string DataCadastro = "DATACADASTRO";
            public const string Nome = "NOME";
            public const string Apelido = "APELIDO";
            public const string DataNascimento = "DATANASCIMENTO";
            public const string GeneroId = "GENERO";
            public const string GeneroInstance = null;
            public const string EnderecoClienteId = "ENDERECO";
            public const string EnderecoClienteInstance = null;
            public const string TelefoneCelular = "TELEFONECELULAR";
            public const string Cpf = "CPF";
            public const string DependentesClientes = null;
            public const string Decoracoes = null;
        }

        public readonly IDictionary<string, string> PropertyNameFieldName = new Dictionary<string, string>()
        {
            [nameof(Id)] = Fields.Id,
            [nameof(DataCadastro)] = Fields.DataCadastro,
            [nameof(Nome)] = Fields.Nome,
            [nameof(Apelido)] = Fields.Apelido,
            [nameof(DataNascimento)] = Fields.DataNascimento,
            [nameof(GeneroId)] = Fields.GeneroId,
            [nameof(EnderecoClienteId)] = Fields.EnderecoClienteId,
            [nameof(TelefoneCelular)] = Fields.TelefoneCelular,
            [nameof(Cpf)] = Fields.Cpf
        };
    }
}
