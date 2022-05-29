using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCustomMessageBox;
using System.Reflection;
using System.Reflection.Emit;
using MongoDB.Driver;
using BookLibary.LibaryManagmentClasses;
using DimitryProject.LoginClasses;
using DimitryProject.ForInterfaceClasses;

namespace DimitryProject.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        #region RelayCommands
        public RelayCommand LogoutCommand { get; set; }
        public RelayCommand Login { get; set; }
        public RelayCommand RegisterWorker { get; set; }
        public RelayCommand LoginWorker { get; set; }
        public RelayCommand RegisterCustomer { get; set; }
        public RelayCommand LoginCustomer { get; set; }

        #endregion RelayCommands

        #region InstanceAndProp
        RegisterTextBoxViewModel RegisterTextBoxViewModels;
        VisibilityFuncs VisibilityFuncsInstance;
        public Customer CurrentCustomer { get; set; }
        #endregion InstanceAndProp
        public RegisterViewModel(RegisterTextBoxViewModel RegisterTextBoxViewModel, VisibilityFuncs VisibilityFuncsInstances)
        {
            this.VisibilityFuncsInstance = VisibilityFuncsInstances;
            this.RegisterTextBoxViewModels = RegisterTextBoxViewModel;
            MongoDBClass.CreateMongo();
            LogoutCommand = new RelayCommand(Logout);
            VisibilityFuncsInstance.ResetAllVisiblity();
            Login = new RelayCommand(LoginManagerToLibary);
            RegisterWorker = new RelayCommand(RegisterWorkerToLibary);
            LoginWorker = new RelayCommand(LoginWorkerToLibary);
            RegisterCustomer = new RelayCommand(RegisterCustomerToLibary);
            LoginCustomer = new RelayCommand(LoginCustomerToLibary);
            RegisterTextBoxViewModels.listOfManagers.Add(new Manager { Name = "niv", Password = "1234" });
        }

        #region Login
        private void LoginCustomerToLibary()
        {
            IMongoCollection<Customer> collection = MongoDBClass.GetMongoDBCustomerCollection();
            Customer customerFound = HelperFuncs.FindIfThereIsAlreadyCustomerInMongoCollection(collection, RegisterTextBoxViewModels.CustomerName, RegisterTextBoxViewModels.IdNumber);
            CurrentCustomer = HelperFuncs.SetCurrentCustomer(customerFound);
            if (customerFound != default)
            {
                VisibilityFuncsInstance.LoginCustomerVisibility();
                LoginCurrectMessage();
            }
            else LoginNotCurrectMessage();
            RegisterTextBoxViewModels.ResetCutomerTextBinding();
        }
        private void LoginWorkerToLibary()
        {
            IMongoCollection<Worker> collection = MongoDBClass.GetMongoDBCWorkersCollection();
            Worker workerFound = HelperFuncs.FindIfThereIsAlreadyWorkerInMongoCollection(collection, RegisterTextBoxViewModels.Name, RegisterTextBoxViewModels.Password);
            if (workerFound != default)
            {
                LoginCurrectMessage();
                VisibilityFuncsInstance.LoginWorkerVisibility();             
            }
            else LoginNotCurrectMessage();
            RegisterTextBoxViewModels.ResetWorkerTextBinding();
        }
        private void LoginManagerToLibary()
        {
            Manager manager = RegisterTextBoxViewModels.listOfManagers.FirstOrDefault(item => item.Name == RegisterTextBoxViewModels.Name && item.Password == RegisterTextBoxViewModels.Password);
            if (manager != default)
            {
                LoginCurrectMessage();
                VisibilityFuncsInstance.LoginManagerVisibility();              
            }
            else LoginNotCurrectMessage();
            RegisterTextBoxViewModels.ResetManagerTextBinding();
        }
        private void Logout()
        {
            VisibilityFuncsInstance.ResetAllVisiblity();
            CurrentCustomer = default;
            MessageBox.Show("Thank you , You are now Logout, have a nice day");
        }

        #endregion Login

        #region Register
        private async void RegisterCustomerToLibary()
        {
            IMongoCollection<Customer> collection = MongoDBClass.GetMongoDBCustomerCollection();
            Customer libaryCustomer = new Customer { Name = RegisterTextBoxViewModels.CustomerName, IdNumber = RegisterTextBoxViewModels.IdNumber };
            Customer customerFound = HelperFuncs.FindIfThereIsAlreadyCustomerInMongoCollection(collection, RegisterTextBoxViewModels.CustomerName, RegisterTextBoxViewModels.IdNumber);
            if (customerFound != default)
            {
                await collection.InsertOneAsync(libaryCustomer);
                MessageBox.Show("Thank you you are now registered, please login ");
            }
            else MessageBox.Show("you already Registered");
            RegisterTextBoxViewModels.ResetCutomerTextBinding();
        }
        private async void RegisterWorkerToLibary()
        {
            IMongoCollection<Worker> collection = MongoDBClass.GetMongoDBCWorkersCollection();
            Worker libaryWorker = new Worker { Name = RegisterTextBoxViewModels.Name, Password = RegisterTextBoxViewModels.Password, BirthDay = RegisterTextBoxViewModels.BirthDay, StartedWorkingDate = RegisterTextBoxViewModels.StartDate };
            Worker workerFound = HelperFuncs.FindIfThereIsAlreadyWorkerInMongoCollection(collection, RegisterTextBoxViewModels.Name, RegisterTextBoxViewModels.Password);
            if (workerFound == default)
            {
                await collection.InsertOneAsync(libaryWorker);
                MessageBox.Show("Thank you you are now registered, please login ");
            }
            else MessageBox.Show("you already Registered");
            RegisterTextBoxViewModels.ResetWorkerTextBinding();
        }
        #endregion  Register

        #region MessageFunc
        private static void LoginCurrectMessage()
        {
            ForInterface.ForInterfaceInstance.DisplayWarning("Thank you, enjoy your time in the libary");
        }
        private static void LoginNotCurrectMessage()
        {
            ForInterface.ForInterfaceInstance.DisplayError("Login Info Not currect");
        }
        #endregion MessageFunc
    }
}
