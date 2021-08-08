﻿using HiringProject.Data.DataContext;
using HiringProject.Data.Models;
using MongoDB.Bson;
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

        public virtual async Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await Task.FromResult(predicate == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(predicate));
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            //return await _collection.Find(predicate);
            return await (predicate == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(predicate))
                .FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            //var @event = await _collection.Find($"{{ _id: string('{id.ToString()}') }}").SingleAsync();
            //var res = _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
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

        public virtual async Task<T> UpdateAsync(string id, T entity)
        {
            return await _collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }

        public virtual async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            return await _collection.FindOneAndReplaceAsync(predicate, entity);
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            return await _collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public virtual async Task<T> DeleteAsync(string id)
        {
            return await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public virtual async Task<T> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.FindOneAndDeleteAsync(filter);
        }
    }
}
