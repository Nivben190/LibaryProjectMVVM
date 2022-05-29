using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Models
{

    [BsonIgnoreExtraElements]

    public class Customerss
    {
        public ObjectId id { get; set; }
        public bool IsCustomerAccess { get; set; }
        public  int IdNumber { get; set; } 
        public string Name { get; set; }
        public int Credit { get; set; }
        public List<object> BorrowedItemList { get; set; }
        public Customerss()
        {
            Credit = 500;
            BorrowedItemList = new List<object>();
        }
    }
}
