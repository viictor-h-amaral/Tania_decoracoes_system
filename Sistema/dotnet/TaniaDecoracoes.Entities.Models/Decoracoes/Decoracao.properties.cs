using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Models.Decoracoes
{
    public partial class Decoracao
    {
        public class Fields
        {
            public const string Id = "ID";
            public const string DataCadastro = "DATACADASTRO";
            public const string ClienteId = "CLIENTE";
            public const string ClienteInstance = null;
            public const string ComemorandoId = "COMEMORANDO";
            public const string ComemorandoInstance = null;
            public const string EnderecoEventoId = "ENDERECOEVENTO";
            public const string EnderecoEventoInstance = null;
            public const string TipoEventoId = "TIPOEVENTO";
            public const string TipoEventoInstance = null;
            public const string CarroUtilizadoId = "CARROUTILIZADO";
            public const string CarroUtilizadoInstance = null;
            public const string DistanciaDeCasa = "DISTANCIOADECASA";
            public const string ValorSugerido = "VALORSUGERIDO";
            public const string ValorCobrado = "VALORCOBRADO";
            public const string Lucro = "LUCRO";
            public const string DataEvento = "DATAEVENTO";
            public const string DataHoraMontagem = "DATAHORAMONTAGEM";
            public const string PegueEMonte = "PEGUEEMONTE";
            public const string AssociacaoDecoracaoItens = null;
            public const string AssociacaoDecoracaoFlores = null;
        }

        public readonly IDictionary<string, string> PropertyNameFieldName = new Dictionary<string, string>()
        {
            [nameof(Id)] = Fields.Id,
            [nameof(DataCadastro)] = Fields.DataCadastro,
            [nameof(ClienteId)] = Fields.ClienteId,
            [nameof(ComemorandoId)] = Fields.ComemorandoId,
            [nameof(EnderecoEventoId)] = Fields.EnderecoEventoId,
            [nameof(TipoEventoId)] = Fields.TipoEventoId,
            [nameof(CarroUtilizadoId)] = Fields.CarroUtilizadoId,
            [nameof(DistanciaDeCasa)] = Fields.DistanciaDeCasa,
            [nameof(ValorSugerido)] = Fields.ValorSugerido,
            [nameof(ValorCobrado)] = Fields.ValorCobrado,
            [nameof(Lucro)] = Fields.Lucro,
            [nameof(DataEvento)] = Fields.DataEvento,
            [nameof(DataHoraMontagem)] = Fields.DataHoraMontagem,
            [nameof(PegueEMonte)] = Fields.PegueEMonte
        };
    }
}
