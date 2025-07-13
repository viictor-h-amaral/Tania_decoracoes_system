using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Decoracoes
{
    public class TipoEventoDto
    {
        public TipoEventoDto()
        {
            
        }

        public TipoEventoDto(TipoEvento tipoEvento)
        {
            this.Id = tipoEvento.Id;
            this.Nome = tipoEvento.Nome;
        }

        public int Id { get; set; }

        public required string Nome { get; set; }
    }
}
