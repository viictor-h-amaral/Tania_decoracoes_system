using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Clientes;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Enderecos;
using TaniaDecoracoes.Entities.Models.Pagamentos;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Decoracoes
{
    public class DecoracaoDto
    {
        public DecoracaoDto()
        {
            
        }

        public DecoracaoDto(Decoracao decoracao)
        {
            this.Id = decoracao.Id;
            this.DataCadastro = decoracao.DataCadastro;
            this.ClienteNome = decoracao.ClienteInstance.Nome;
            this.TipoEventoNome = decoracao.TipoEventoInstance.Nome;
            this.ValorCobrado = decoracao.ValorCobrado;
            this.DataEvento = decoracao.DataEvento;
            this.DataHoraMontagem = decoracao.DataHoraMontagem;
            this.PegueEMonte = decoracao.PegueEMonte;
        }

        public int Id { get; set; }

        public DateOnly DataCadastro { get; set; }

        public string? ClienteNome { get; set; }

        public string TipoEventoNome { get; set; }

        public decimal ValorCobrado { get; set; }

        public DateTime? DataEvento { get; set; }

        public DateTime? DataHoraMontagem { get; set; }

        public bool PegueEMonte { get; set; }

    }
}
