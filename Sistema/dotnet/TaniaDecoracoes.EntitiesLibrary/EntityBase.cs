using System.Linq.Expressions;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;

namespace TaniaDecoracoes.EntitiesLibrary
{
    public class EntityBase<T> : IEntityBase where T : class
    {
        /// <summary>
        /// Usado para retornar uma lista de entidades do tipo <typeparamref name="T"/> que satisfazem as restrições fornecidas.
        /// </summary>
        /// <param name="predicado">Parâmetro opcional que define a cláusula where para buscar os registros. Se <see langword="null"/>, todos registros de <typeparamref name="T"/> são retornados.</param>
        /// <returns>Uma lista de elementos do tipo <typeparamref name="T"/> que satisfazem o critério passado como parâmetro. Retorna <see langword="null"/> Se nenhum registro for encontrado.</returns>
        public static List<T>? GetMany(Expression<Func<T, bool>>? predicado = null)
        {
            using (var context = new TaniaDecoracoesDbContext())
            {
                var registros = predicado is null ?
                        context.Set<T>().ToList()
                        : context.Set<T>().Where(predicado).ToList();
                return registros;
            }
        }


        /// <summary>
        /// Usado para retornar a primeira entidade do tipo <typeparamref name="T"/> que satisfaz as restrições fornecidas.
        /// </summary>
        /// <param name="predicado">Parâmetro opcional que define a cláusula where para buscar os registros. Se <see langword="null"/>, todos registros de <typeparamref name="T"/> são considerados.</param>
        /// <returns>O primeiro registro na forma de elementos do tipo <typeparamref name="T"/> que satisfaz o critério passado como parâmetro. Retorna <see langword="null"/> Se nenhum registro for encontrado.</returns>
        public static T? FirstOrDefault(Expression<Func<T, bool>>? predicado = null)
        {
            using (var context = new TaniaDecoracoesDbContext())
            {
                var registro = predicado is null ?
                        context.Set<T>().FirstOrDefault()
                        : context.Set<T>().FirstOrDefault(predicado);
                return registro;
            }
        }
    }
}
