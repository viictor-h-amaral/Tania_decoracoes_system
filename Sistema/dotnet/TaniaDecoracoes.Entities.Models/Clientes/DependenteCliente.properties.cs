using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.Entities.Models.Clientes
{
    public partial class DependenteCliente
    {
        public class Fields
        {
            public const string Id = "ID";
            public const string Nome = "NOME";
            public const string DataAniversario = "DATANIVERSARIO";
            public const string ResponsavelId = "RESPONSAVEL";
            public const string ResponsavelInstance = null;
            public const string GeneroId = "GENERO";
            public const string GeneroInstance = null;
            public const string Decoracoes = null;
        }

        public readonly IDictionary<string, string> PropertyNameFieldName = new Dictionary<string, string>()
        {
            [nameof(Id)] = Fields.Id,
            [nameof(Nome)] = Fields.Nome,
            [nameof(DataAniversario)] = Fields.DataAniversario,
            [nameof(ResponsavelId)] = Fields.ResponsavelId,
            [nameof(GeneroId)] = Fields.GeneroId
        };
    }
}
