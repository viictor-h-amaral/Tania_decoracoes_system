using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Enderecos
{
    public class BairroDto
    {
        public BairroDto()
        {
            
        }
        public BairroDto(Bairro bairro)
        {
            this.Id = bairro.Id;
            this.MunicipioNome = bairro.MunicipioInstance?.Nome;
            this.Nome = bairro.Nome;
        }

        public int Id { get; set; }
        public string? MunicipioNome { get; set; }

        public required string Nome { get; set; }
    }
}
