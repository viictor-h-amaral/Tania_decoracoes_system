using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;

namespace TaniaDecoracoes.EntitiesLibrary.Entities.Associacao
{
    public class AssociacaoDecoracaoFloresEntity : EntityBase<AssociacaoDecoracaoFlores>
    {
        public AssociacaoDecoracaoFloresEntity(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
