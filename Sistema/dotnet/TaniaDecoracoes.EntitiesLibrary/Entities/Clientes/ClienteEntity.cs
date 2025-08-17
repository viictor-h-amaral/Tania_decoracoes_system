using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Models.Clientes;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;

namespace TaniaDecoracoes.EntitiesLibrary.Entities.Clientes
{
    public class ClienteEntity : EntityBase<Cliente>
    {
        public ClienteEntity(DbContext dbContext) : base(dbContext) 
        { 
        }
    }
}
