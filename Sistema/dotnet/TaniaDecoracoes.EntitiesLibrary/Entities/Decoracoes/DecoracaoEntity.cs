using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;

namespace TaniaDecoracoes.EntitiesLibrary.Entities.Decoracoes
{
    public class DecoracaoEntity : EntityBase<Decoracao>
    {
        public DecoracaoEntity(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
