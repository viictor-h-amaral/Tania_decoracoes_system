using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Enderecos
{
    public class LogradouroDto
    {
        public LogradouroDto()
        {
            
        }
        public LogradouroDto(Logradouro logradouro)
        {
            this.Id = logradouro.Id;
            this.BairroNome = logradouro.BairroInstance?.Nome;
            this.Nome = logradouro.Nome;
            this.TipoLogradouroNome = logradouro.TipoLogradouroInstance?.Nome;
        }

        public int Id { get; set; }

        public string? BairroNome { get; set; }

        public required string Nome { get; set; }

        public string? TipoLogradouroNome { get; set; }
    }
}
