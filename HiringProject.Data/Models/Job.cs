using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringProject.Data.Models
{
    public class Job: MongoDbEntity
    {
        public string CompanyId { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        [BsonDateTimeOptions]
        public DateTime TimeToLive { get; set; }
        public string FringeBenefits { get; set; }
        public string WorkType { get; set; }
        public int Salary { get; set; }
    }
}
