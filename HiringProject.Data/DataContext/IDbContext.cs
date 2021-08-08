using HiringProject.Data.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Data.DataContext
{
    public interface IDbContext
    {
        IMongoDatabase Database { get; }

        IMongoCollection<T> GetCollection<T>();
    }
}
