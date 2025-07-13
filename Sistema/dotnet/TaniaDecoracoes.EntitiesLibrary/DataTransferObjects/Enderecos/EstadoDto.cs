using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Enderecos
{
    public class EstadoDto
    {
        public EstadoDto()
        {
            
        }

        public EstadoDto(Estado estado)
        {
            this.Id = estado.Id;
            this.Nome = estado.Nome;
            this.Sigla = estado.Sigla;
        }

        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Sigla { get; set; }
    }
}
