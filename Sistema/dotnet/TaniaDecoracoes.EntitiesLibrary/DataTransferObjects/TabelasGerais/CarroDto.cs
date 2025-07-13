using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.TabelasGerais
{
    public class CarroDto
    {
        public CarroDto()
        {
            
        }

        public CarroDto(Carro carro)
        {
            this.Id = carro.Id;
            this.Apelido = carro.Apelido;
            this.LitrosPorKm = carro.LitrosPorKm;
            this.TipoCombustivel = carro.TipoCombustivelInstance.NomeCombustivel;
            this.EstaAtivo = carro.EstaAtivo;
        }
        public int Id { get; set; }

        public required string Apelido { get; set; }

        public float LitrosPorKm { get; set; }

        public string? TipoCombustivel { get; set; }

        public bool? EstaAtivo { get; set; }
    }
}
