using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.TabelasGerais
{
    public class CustoCombustivelDto
    {
        public CustoCombustivelDto()
        {
            
        }
        public CustoCombustivelDto(CustoCombustivel custoCombustivel)
        {
            this.Id = custoCombustivel.Id;
            this.Combustivel = custoCombustivel.CombustivelInstance?.NomeCombustivel;
            this.ReaisPorLitro = custoCombustivel.ReaisPorLitro;
            this.DataInicial = custoCombustivel.DataInicial;
            this.DataFinal = custoCombustivel.DataFinal;
        }

        public int Id { get; set; }

        public string? Combustivel { get; set; }

        public decimal ReaisPorLitro { get; set; }

        public DateOnly DataInicial { get; set; }

        public DateOnly? DataFinal { get; set; }
    }
}
