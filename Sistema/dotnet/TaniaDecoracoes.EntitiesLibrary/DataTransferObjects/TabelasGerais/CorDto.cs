using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.TabelasGerais
{
    public class CorDto
    {
        public CorDto()
        {
            
        }

        public CorDto(Cor cor)
        {
            this.Id = cor.Id;
            this.Nome = cor.Nome;
            this.CodigoHex = cor.CodigoHex;
        }

        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? CodigoHex { get; set; }
    }
}
