using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Enderecos
{
    public class TipoEnderecoEventoDto
    {
        public TipoEnderecoEventoDto()
        {
            
        }
        public TipoEnderecoEventoDto(TipoEnderecoEvento tipoEnderecoEvento)
        {
            this.Id = tipoEnderecoEvento.Id;
            this.TipoEndereco = tipoEnderecoEvento.TipoEndereco;
        }

        public int Id { get; set; }

        public required string TipoEndereco { get; set; }
    }
}
