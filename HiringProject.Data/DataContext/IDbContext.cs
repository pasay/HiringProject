using MongoDB.Driver;

namespace HiringProject.Data.DataContext
{
    public interface IDbContext
    {
        IMongoDatabase Database { get; }

        IMongoCollection<T> GetCollection<T>();
    }
}
