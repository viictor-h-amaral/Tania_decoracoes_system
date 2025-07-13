using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Enderecos
{
    public class EnderecoEventoDto
    {
        public EnderecoEventoDto()
        {
            
        }
        public EnderecoEventoDto(EnderecoEvento enderecoEvento)
        {
            this.Id = enderecoEvento.Id;
            this.EstadoNome = enderecoEvento.EstadoInstance?.Nome;
            this.MunicipioNome = enderecoEvento.MunicipioInstance?.Nome;
            this.BairroNome = enderecoEvento.BairroInstance?.Nome;
            this.LogradouroNome = enderecoEvento.LogradouroInstance?.Nome;
            this.TipoEnderecoEventoNome = enderecoEvento.TipoEnderecoEventoInstance?.TipoEndereco;
            this.NumeroEndereco = enderecoEvento.NumeroEndereco;
        }

        public int Id { get; set; }

        public string? EstadoNome { get; set; }

        public string? MunicipioNome { get; set; }

        public string? BairroNome { get; set; }

        public string? LogradouroNome { get; set; }

        public string? TipoEnderecoEventoNome { get; set; }

        public int NumeroEndereco { get; set; }
    }
}
