using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.TabelasGerais
{
    public class TipoCombustivelDto
    {
        public TipoCombustivelDto()
        {
            
        }

        public TipoCombustivelDto(TipoCombustivel tipoCombustivel)
        {
            this.Id = tipoCombustivel.Id;
            this.NomeCombustivel = tipoCombustivel.NomeCombustivel;
        }

        public int Id { get; set; }

        public required string NomeCombustivel { get; set; }
    }
}
