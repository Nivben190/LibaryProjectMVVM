using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BookLibary
{
    [Flags]
    public enum BookCategorys
    {
        Other=-1,
        Cooking=1,
        History=2,
        Arts=4,
        Biographies=8,
        Health=16,
        Religion=32,
        Travel=64,
        Sports=128,
        Fiction=256
    }

    [BsonIgnoreExtraElements(true)]

    public class Book  : AbstractItem 
    {
        public BookCategorys Category { get ; set; } 
        public string Author { get; set; }    
        public Book( string name, int price, int discount, int amountInLibary, DateTime ReleaseDate, string autor, BookCategorys category,long ISBN)
         :base(name, price,discount,amountInLibary,ISBN, ReleaseDate)
        {
            Author = autor;
            this.Category = category;
        }   
    }

}
