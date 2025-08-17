using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;

namespace TaniaDecoracoes.EntitiesLibrary.Entities.Itens
{
    public class ItemEntity : EntityBase<Item>
    {
        public ItemEntity(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
