using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Enderecos
{
    public class CepDto
    {
        public CepDto()
        {
            
        }
        public CepDto(Cep cep)
        {
            this.Id = cep.Id;
            this.LogradouroNome = cep.LogradouroInstance?.Nome;
            this.CepValor = cep.CepValor;
        }

        public int Id { get; set; }
        
        public string? LogradouroNome { get; set; }

        public required string CepValor { get; set; }
    }
}
