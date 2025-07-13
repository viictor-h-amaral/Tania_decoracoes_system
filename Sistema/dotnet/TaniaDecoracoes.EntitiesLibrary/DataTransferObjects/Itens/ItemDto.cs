using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Itens
{
    public class ItemDto
    {
        public ItemDto()
        {
            
        }
        public ItemDto(Item item)
        {
            this.Id = item.Id;
            this.Apelido = item.Apelido;
            this.TipoItemNome = item.TipoItemInstance?.Nome;
            this.QuantidadeEstoque = item.QuantidadeEstoque;
            this.Preco = item.Preco;
            this.CorNome = item.CorInstance?.Nome;
            this.Dimensao = item.Dimensoes;
        }

        public int Id { get; set; }

        public string? Apelido { get; set; }

        public string? TipoItemNome { get; set; }

        public int QuantidadeEstoque { get; set; }

        public decimal? Preco { get; set; }

        public string? CorNome { get; set; }

        public string? Dimensao { get; set; }
    }
}
