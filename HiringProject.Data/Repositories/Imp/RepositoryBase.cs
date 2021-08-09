using HiringProject.Data.DataContext;
using HiringProject.Data.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HiringProject.Data.Repositories.Imp
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : MongoDbEntity, new()
    {
        protected readonly IMongoCollection<T> _collection;
        protected readonly IDbContext _context;

        public RepositoryBase(IDbContext context)
        {
            _context = context;
            _collection = context.GetCollection<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await (predicate == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(predicate))
                .ToListAsync();
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await (predicate == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(predicate))
                .FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(entity, options);
            return entity;
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            return (await _collection.BulkWriteAsync((IEnumerable<WriteModel<T>>)entities, options)).IsAcknowledged;
        }

        public virtual async Task<T> UpdateByIdAsync(string id, T entity)
        {
            return await UpdateExpressionAsync(entity, x => x.Id == id);
        }

        public virtual async Task<T> UpdateExpressionAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            await _collection.ReplaceOneAsync(predicate, entity);

            return await FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            return await _collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public virtual async Task<T> DeleteByIdAsync(string id)
        {
            return await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public virtual async Task<T> DeleteExpressionAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.FindOneAndDeleteAsync(filter);
        }
    }
}
