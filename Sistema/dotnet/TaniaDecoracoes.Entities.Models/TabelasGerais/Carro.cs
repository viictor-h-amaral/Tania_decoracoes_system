using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.Entities.Models.TabelasGerais
{
    public class Carro
    {
        public int Id { get; set; }
        public required string Apelido { get; set; }
        public float LitrosPorKm { get; set; }

        public int TipoCombustivelId { get; set; }
        public required TipoCombustivel TipoCombustivelInstance { get; set; }

        /*private byte? _estaAtivo;
        public bool? EstaAtivo {
            get => _estaAtivo is null ? null : _estaAtivo == 1;
            set =>  _estaAtivo = (value is null ? null : (value.Value ? (byte)1 : (byte)0));
        }*/

        public bool? EstaAtivo { get; set; }

        public ICollection<Decoracao>? Decoracoes { get; set; }
    }
}
