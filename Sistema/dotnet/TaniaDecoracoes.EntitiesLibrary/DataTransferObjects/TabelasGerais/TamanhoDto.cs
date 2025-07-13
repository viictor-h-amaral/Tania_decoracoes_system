using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.TabelasGerais
{
    public class TamanhoDto
    {
        public TamanhoDto()
        {
            
        }

        public TamanhoDto(Tamanho tamanho)
        {
            this.Id = tamanho.Id;
            this.Valor = tamanho.Valor;
        }

        public int Id { get; set; }

        public required string Valor { get; set; }
    }
}
