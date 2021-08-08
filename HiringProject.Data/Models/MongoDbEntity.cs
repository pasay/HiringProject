using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HiringProject.Data.Models
{
    public abstract class MongoDbEntity : IEntity<string>
    {
        [BsonRepresentation(BsonType.String)]
        [BsonId]
        [BsonElement(Order = 0)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
    }
}
