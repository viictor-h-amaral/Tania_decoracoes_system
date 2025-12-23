using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TaniaDecoracoes.EntitiesLibrary.Interfaces
{
    public interface IEntityBase<T>
    {
        IEnumerable<T>? GetMany(Expression<Func<T, bool>>? predicado = null);
        IEnumerable<T>? GetManyWithNoTracking(Expression<Func<T, bool>>? predicado = null);
        T? FirstOrDefault(Expression<Func<T, bool>>? predicado = null);
        T? FirstOrDefaultWithNoTracking(Expression<Func<T, bool>>? predicado = null);
        T First(Expression<Func<T, bool>>? predicado = null);
        T FirstWithNoTracking(Expression<Func<T, bool>>? predicado = null);
        bool Save(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        int Count(Expression<Func<T, bool>>? predicado = null);
    }
}
