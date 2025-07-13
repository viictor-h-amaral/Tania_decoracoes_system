using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Enderecos
{
    public class TipoEnderecoClienteDto
    {
        public TipoEnderecoClienteDto()
        {
            
        }
        public TipoEnderecoClienteDto(TipoEnderecoCliente tipoEnderecoCliente)
        {
            this.Id = tipoEnderecoCliente.Id;
            this.TipoEndereco = tipoEnderecoCliente.TipoEndereco;
        }

        public int Id { get; set; }

        public required string TipoEndereco { get; set; }
    }
}
