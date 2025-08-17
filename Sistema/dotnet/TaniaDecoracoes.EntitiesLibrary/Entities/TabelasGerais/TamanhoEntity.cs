using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Models.TabelasGerais;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;

namespace TaniaDecoracoes.EntitiesLibrary.Entities.TabelasGerais
{
    public class TamanhoEntity : EntityBase<Tamanho>
    {
        public TamanhoEntity(DbContext dbContext) : base(dbContext) 
        { 
        }
    }
}
