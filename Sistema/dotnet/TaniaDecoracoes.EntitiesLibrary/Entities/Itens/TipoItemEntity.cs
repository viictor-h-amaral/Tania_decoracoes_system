using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;

namespace TaniaDecoracoes.EntitiesLibrary.Entities.Itens
{
    public class TipoItemEntity : EntityBase<TipoItem>
    {
        public TipoItemEntity(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
