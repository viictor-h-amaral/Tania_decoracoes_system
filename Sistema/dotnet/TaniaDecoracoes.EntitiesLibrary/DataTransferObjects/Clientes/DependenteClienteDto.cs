using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Clientes;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Clientes
{
    public class DependenteClienteDto
    {
        public DependenteClienteDto()
        {
            
        }

        public DependenteClienteDto(DependenteCliente dependente)
        {
            this.Id = dependente.Id;
            this.Nome = dependente.Nome;
            this.DataAniversario = dependente.DataAniversario;
            this.GeneroNome = dependente.GeneroInstance?.Letra?.ToString();
            this.ResponsavelNome = dependente.ResponsavelInstance?.Nome;
        }

        public int Id { get; set; }

        public required string Nome { get; set; }

        public DateOnly DataAniversario { get; set; }

        public string? GeneroNome { get; set; }

        public string? ResponsavelNome { get; set; }

    }
}
