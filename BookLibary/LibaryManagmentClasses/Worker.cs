using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibary.LibaryManagmentClasses
{
    public class Worker : IWorker
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public bool IsWorkerAccess { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime StartedWorkingDate { get; set; }
    }
}
