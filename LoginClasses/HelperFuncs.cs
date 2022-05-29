using BookLibary.LibaryManagmentClasses;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimitryProject.LoginClasses
{
    public static class HelperFuncs
    {
        public static Customer CurrentCustomer { get; private set; }

        public static Customer FindIfThereIsAlreadyCustomerInMongoCollection(IMongoCollection<Customer> collection,string customerName,int IdNumber)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.Name == customerName && x.IdNumber == IdNumber);
        }
        public static Worker FindIfThereIsAlreadyWorkerInMongoCollection(IMongoCollection<Worker> collection, string workerName, string password)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.Name == workerName && x.Password == password);
        }
        public static Customer SetCurrentCustomer(Customer customerFound)
        {
            return customerFound;  
        }
    }
}
