using MongoDB.Bson.Serialization.Attributes;
using Services.ServicesExtensions;
using System;

namespace BookLibary
{
    [BsonIgnoreExtraElements(true)]

    public class Journal:AbstractItem
    {
        [Flags]
        public  enum Categorys
        {
            Other =0,
            Chemistry = 1,
            Engineering=2,
            Physics=4, 
            Fashion=8,
            Food=16
        }
        public Categorys JournalCategory { get; set; }

        public Journal(string name, int price, int discount, int amountInLibary, DateTime PrintDate, Categorys categorys, string journalName, int itemNumber,long ISBN, DateTime ReleaseDate, Categorys journalCategorys) : base(name, price, discount, amountInLibary, ISBN, ReleaseDate)
        {
            this.JournalCategory = journalCategorys;
        }
        public string JournalName { get; set; }
        public int ItemNumber { get; set; }
        
    }
}
