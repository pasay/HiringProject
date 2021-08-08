using HiringProject.Data.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HiringProject.Data.Repositories
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(string id);
        Task<T> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateByIdAsync(string id, T entity);
        Task<T> UpdateExpressionAsync(T entity, Expression<Func<T, bool>> predicate);
        Task<T> DeleteAsync(T entity);
        Task<T> DeleteByIdAsync(string id);
        Task<T> DeleteExpressionAsync(Expression<Func<T, bool>> predicate);
    }
}
