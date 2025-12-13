using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;

namespace TaniaDecoracoes.EntitiesLibrary
{
    public class EntityBase<T> : IEntityBase<T> where T : class, IEntityModel
    {
        private readonly DbContext _dbContext;

        public EntityBase(DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Usado para retornar uma lista de entidades do tipo <typeparamref name="T"/> que satisfazem as restrições fornecidas.
        /// </summary>
        /// <param name="predicado">Parâmetro opcional que define a cláusula where para buscar os registros. Se <see langword="null"/>, todos registros de <typeparamref name="T"/> são retornados.</param>
        /// <returns>Uma lista de elementos do tipo <typeparamref name="T"/> que satisfazem o critério passado como parâmetro. Retorna <see langword="null"/> Se nenhum registro for encontrado.</returns>
        public IEnumerable<T>? GetMany(Expression<Func<T, bool>>? predicado = null)
        {
            try
            {
                var registros = predicado is null ?
                    _dbContext.Set<T>().ToList()
                    : _dbContext.Set<T>().Where(predicado).ToList() as IEnumerable<T>;
                return registros;
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? "";
                var innerStack = ex.InnerException?.StackTrace ?? "";
                throw new Exception(
                    $"OPS: trace em {ex.StackTrace} - mensagem {ex.Message} " +
                    $"| InnerException: {innerMessage} - InnerTrace: {innerStack}"
                );
            }
        }

        /// <summary>
        /// Usado para retornar a primeira entidade do tipo <typeparamref name="T"/> que satisfaz as restrições fornecidas.
        /// </summary>
        /// <param name="predicado">Parâmetro opcional que define a cláusula where para buscar os registros. Se <see langword="null"/>, todos registros de <typeparamref name="T"/> são considerados.</param>
        /// <returns>O primeiro registro na forma de elementos do tipo <typeparamref name="T"/> que satisfaz o critério passado como parâmetro. Retorna <see langword="null"/> Se nenhum registro for encontrado.</returns>
        public T? FirstOrDefault(Expression<Func<T, bool>>? predicado = null)
        {
            try
            {
                var registro = predicado is null ?
                                        _dbContext.Set<T>().FirstOrDefault()
                                        : _dbContext.Set<T>().FirstOrDefault(predicado);
                return registro;
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? "";
                var innerStack = ex.InnerException?.StackTrace ?? "";
                throw new Exception(
                    $"OPS: trace em {ex.StackTrace} - mensagem {ex.Message} " +
                    $"| InnerException: {innerMessage} - InnerTrace: {innerStack}"
                );
            }
        }


        /// <summary>
        /// Salva a entidade do tipo <typeparamref name="T"/> no banco.
        /// </summary>
        /// <param name="entity">Parâmetro obrigatório à entidade do tipo <typeparamref name="T"/> a ser salva.</param>
        /// <returns>O primeiro registro na forma de elementos do tipo <typeparamref name="T"/> que satisfaz o critério passado como parâmetro. Retorna <see langword="null"/> Se nenhum registro for encontrado.</returns>
        public bool Save(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? "";
                var innerStack = ex.InnerException?.StackTrace ?? "";
                throw new Exception(
                    $"OPS: trace em {ex.StackTrace} - mensagem {ex.Message} " +
                    $"| InnerException: {innerMessage} - InnerTrace: {innerStack}"
                );
            }
        }

        public bool Update(T entity)
        {
            try
            {
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? "";
                var innerStack = ex.InnerException?.StackTrace ?? "";
                throw new Exception(
                    $"OPS: trace em {ex.StackTrace} - mensagem {ex.Message} " +
                    $"| InnerException: {innerMessage} - InnerTrace: {innerStack}"
                );
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? "";
                var innerStack = ex.InnerException?.StackTrace ?? "";
                throw new Exception(
                    $"OPS: trace em {ex.StackTrace} - mensagem {ex.Message} " +
                    $"| InnerException: {innerMessage} - InnerTrace: {innerStack}"
                );
            }
        }

        /// <summary>
        /// Usado para contagem de registros na tabela <typeparamref name="T"/> que satisfazem as restrições fornecidas.
        /// </summary>
        /// <param name="predicado">Parâmetro opcional que define a cláusula where para contagem os registros. Se <see langword="null"/>, todos registros de <typeparamref name="T"/> são contabilizados.</param>
        /// <returns>Quantidade de registros na tabela conforme critério.</returns>
        public int Count(Expression<Func<T, bool>>? predicado = null)
        {
            try
            {
                int result = predicado is null ?
                    _dbContext.Set<T>().Count()
                    : _dbContext.Set<T>().Count(predicado);
                return result;
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? "";
                var innerStack = ex.InnerException?.StackTrace ?? "";
                throw new Exception(
                    $"OPS: trace em {ex.StackTrace} - mensagem {ex.Message} " +
                    $"| InnerException: {innerMessage} - InnerTrace: {innerStack}"
                );
            }
        }

    }
}
