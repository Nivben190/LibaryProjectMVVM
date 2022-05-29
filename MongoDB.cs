using BookLibary.LibaryItemsClasses;
using BookLibary.LibaryManagmentClasses;
using DimitryProject.ViewModel;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimitryProject.LoginClasses
{
    public static class MongoDBClass
    {
         static MongoClient dbClient;
        public static void CreateMongo()
        {
           dbClient = new MongoClient("mongodb+srv://********@cluster0.zleme.mongodb.net/test");
        }
        public static IMongoCollection<Customer> GetMongoDBCustomerCollection()
        {
            var database = dbClient.GetDatabase("LibaryManagmentDB");
            var collection = database.GetCollection<Customer>("CustomerCollections");
            return collection;
        }
        public static IMongoCollection<Worker> GetMongoDBCWorkersCollection()
        {
            var database = dbClient.GetDatabase("LibaryManagmentDB");
            var collection = database.GetCollection<Worker>("WorkersCollections");
            return collection;
        }
        public  static void ConvertDBToList(List<ClassInstance> ListOfAllItems)
        {
            ListOfAllItems.Clear();
            string json;
            foreach (string file in Directory.EnumerateFiles(@"\\Mac\Home\Desktop\ObjectOriented\DimitryProject\DynamicClassFolder\", "*.json"))
            {
                json = File.ReadAllText(file);
                var classInstance = JsonConvert.DeserializeObject<ClassInstance>(json);
                ListOfAllItems.Add(classInstance);

            }
        }

    }
}
