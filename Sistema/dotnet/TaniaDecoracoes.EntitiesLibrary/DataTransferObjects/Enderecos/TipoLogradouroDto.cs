using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Enderecos
{
    public class TipoLogradouroDto
    {
        public TipoLogradouroDto()
        {
            
        }
        public TipoLogradouroDto(TipoLogradouro tipoLogradouro)
        {
            this.Id = tipoLogradouro.Id;
            this.Nome = tipoLogradouro.Nome;
        }

        public int Id { get; set; }

        public required string Nome { get; set; }
    }
}
