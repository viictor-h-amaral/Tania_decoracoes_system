using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Itens
{
    public class TipoItemDto
    {
        public TipoItemDto()
        {
            
        }
        public TipoItemDto(TipoItem tipoItem)
        {
            this.Id = tipoItem.Id;
            this.Nome = tipoItem.Nome;
        }

        public int Id { get; set; }

        public required string Nome { get; set; }
    }
}
