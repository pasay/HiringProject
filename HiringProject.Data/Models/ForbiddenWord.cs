using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HiringProject.Data.Models
{
    public class ForbiddenWord : MongoDbEntity
    {
        public string Word { get; set; }
    }
}
