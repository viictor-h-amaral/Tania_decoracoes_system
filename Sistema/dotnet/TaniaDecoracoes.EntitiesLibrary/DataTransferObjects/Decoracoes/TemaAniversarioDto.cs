using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Decoracoes
{
    public class TemaAniversarioDto
    {
        public TemaAniversarioDto()
        {
            
        }

        public TemaAniversarioDto(TemaAniversario temaAniver)
        {
            this.Id = temaAniver.Id;
            this.Nome = temaAniver.Nome;
        }

        public int Id { get; set; }

        public required string Nome { get; set; }
    }
}
