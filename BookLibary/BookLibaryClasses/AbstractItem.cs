using BookLibary.LibaryManagmentClasses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibary
{
    [BsonKnownTypes(typeof(Book))]
    [BsonKnownTypes(typeof(Journal))]
    [BsonIgnoreExtraElements(true)]
    public abstract class AbstractItem
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public DateTime RentExipredDate { get; set; }
        public Customer RentedByCustomerRef { get; set; }
        public int AmountInLibary { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long ISBN {get;set;} 
        public AbstractItem(string name, int price, int discount, int amountInLibary,long ISBN,DateTime ReleaseDate)
        {
            Name = name;   
            Discount = discount;
            this.ReleaseDate = ReleaseDate;
            Price = price;
            RentExipredDate = DateTime.Now.AddDays(7);
            AmountInLibary = amountInLibary;
            this.ISBN = ISBN;
        }

        public override string ToString()
        {
            return $"Name:{Name},Price:{Price},Amount In Libary:{AmountInLibary}";
        }

       
    }
}
