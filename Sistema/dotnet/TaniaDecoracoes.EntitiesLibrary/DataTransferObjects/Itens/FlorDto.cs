using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Itens
{
    public class FlorDto
    {
        public FlorDto()
        {
            
        }
        public FlorDto(Flor flor)
        {
            this.Id = flor.Id;
            this.Nome = flor.Nome;
            this.PrecoTemporada = flor.PrecoTemporada;
            this.PrecoPadrao = flor.PrecoPadrao;
            this.CorNome = flor.CorInstance?.Nome;
        }

        public int Id { get; set; }

        public required string Nome { get; set; }

        public decimal? PrecoTemporada { get; set; }

        public decimal PrecoPadrao { get; set; }

        public string? CorNome { get; set; }
    }
}
