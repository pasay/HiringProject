using HiringProject.Data.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Data.DataContext.Imp
{
    public class HiringProjectMongoDbContext : IDbContext
    {
        public HiringProjectMongoDbContext(IMongoDatabase database)
        {
            Database = database;
        }
        public IMongoDatabase Database { get; private set; }

        public IMongoCollection<T> GetCollection<T>()
        {
            return Database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }
    }
}
