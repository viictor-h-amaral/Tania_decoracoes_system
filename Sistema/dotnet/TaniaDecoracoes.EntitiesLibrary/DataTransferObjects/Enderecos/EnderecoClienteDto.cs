using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Enderecos
{
    public class EnderecoClienteDto
    {
        public EnderecoClienteDto()
        {
            
        }
        public EnderecoClienteDto(EnderecoCliente enderecoCliente)
        {
            this.Id = enderecoCliente.Id;
            this.EstadoNome = enderecoCliente.EstadoInstance?.Nome;
            this.MunicipioNome = enderecoCliente.MunicipioInstance?.Nome;
            this.BairroNome = enderecoCliente.BairroInstance?.Nome;
            this.LogradouroNome = enderecoCliente.LogradouroInstance?.Nome;
            this.TipoEnderecoClienteNome = enderecoCliente.TipoEnderecoClienteInstance?.TipoEndereco;
            this.NumeroEndereco = enderecoCliente.NumeroEndereco;
        }

        public int Id { get; set; }

        public string? EstadoNome { get; set; }

        public string? MunicipioNome { get; set; }

        public string? BairroNome { get; set; }

        public string? LogradouroNome { get; set; }

        public string? TipoEnderecoClienteNome { get; set; }

        public int NumeroEndereco { get; set; }
    }
}
