using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Enderecos
{
    public class MunicipioDto
    {
        public MunicipioDto()
        {
            
        }
        public MunicipioDto(Municipio municipio)
        {
            this.Id = municipio.Id;
            this.EstadoNome = municipio.EstadoInstance?.Nome;
            this.Nome = municipio.Nome;
            this.CodigoIBGE = municipio.CodigoIBGE;
        }

        public int Id { get; set; }

        public string? EstadoNome { get; set; }

        public required string Nome { get; set; }

        public int? CodigoIBGE { get; set; }
    }
}
