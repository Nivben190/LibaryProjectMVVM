using BookLibary.LibaryItemsClasses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibary.LibaryManagmentClasses
{
    [BsonIgnoreExtraElements]

    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public bool IsCustomerAccess { get; set; }
        public int IdNumber { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public List<ClassInstance> BorrowedItemList { get; set; }
        public Customer()
        {
            Credit = 500;
            BorrowedItemList = new List<ClassInstance>();
        }
    }
}
