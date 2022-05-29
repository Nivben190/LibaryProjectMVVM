using BookLibary.LibaryManagmentClasses;
using DimitryProject.ViewModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCustomMessageBox;

namespace DimitryProject.LoginClasses
{
    public class Login
    {
        //private void LoginCustomerToLibary(Customer customer)
        //{
        //    IMongoCollection<Customer> collection = MongoDBClass.GetMongoDBCustomerCollection();
        //    Customer customerFound = HelperFuncs.FindIfThereIsAlreadyCustomerInMongoCollection(collection, CustomerName, IdNumber);
        //    customer = HelperFuncs.SetCurrentCustomer(customerFound);
        //    if (customerFound != default)
        //    {
        //        IsVissibleForManager = Visibility.Collapsed;
        //        IsVissibleForCustomer = Visibility.Visible;
        //        IsVissibleForManagerAndWorker = Visibility.Collapsed;
        //        CustomMessageBox.Show("Thank you, enjoy your time in the libary");

        //    }
        //    else CustomMessageBox.Show("Login Info Not currect ");
        //    IdNumber = 0;
        //    Name = string.Empty;
        //}
    }
}
