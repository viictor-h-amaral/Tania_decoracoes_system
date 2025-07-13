using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Associacao
{
    public class AssociacaoDecoracaoItensDto
    {
        public AssociacaoDecoracaoItensDto()
        {
        }
        public AssociacaoDecoracaoItensDto(AssociacaoDecoracaoItens assoc)
        {
            this.Id = assoc.Id;
            this.DecoracaoId = assoc.DecoracaoId;
            this.ItemNome = assoc.ItemInstance.Apelido ?? assoc.ItemInstance.TipoItemInstance.Nome;
        }

        public int Id { get; set; }

        public int DecoracaoId { get; set; }

        public string ItemNome { get; set; }
    }
}
