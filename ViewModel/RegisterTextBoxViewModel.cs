using BookLibary.LibaryManagmentClasses;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DimitryProject.ViewModel
{
    public class RegisterTextBoxViewModel:ViewModelBase
    {
        private Visibility isVissibleForCustomer;
        private Visibility isVissibleForManagerAndWorker;
        private Visibility isVissibleForManager;
        public Visibility IsVissibleForCustomer
        {
            get { return isVissibleForCustomer; }
            set => Set(ref isVissibleForCustomer, value);
        }
        public Visibility IsVissibleForManager
        {
            get { return isVissibleForManager; }
            set => Set(ref isVissibleForManager, value);
        }
        public Visibility IsVissibleForManagerAndWorker
        {
            get { return isVissibleForManagerAndWorker; }
            set => Set(ref isVissibleForManagerAndWorker, value);
        }

        #region ManagerBindingAndInstance
        public List<Manager> listOfManagers = new List<Manager>();
        Manager manager;
        public Manager ManagerInstance
        {
            get { return manager; }
            set
            {
                Set(ref manager, value);
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                Set(ref name, value);
            }

        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                Set(ref password, value);
            }
        }
        #endregion ManagerBindingAndInstance

        #region CustomerBindingAndInstance
        Customer customer;
        public Customer CustomerInstance
        {
            get { return customer; }
            set
            {
                Set(ref customer, value);
            }
        }
        private int idNumber;
        public int IdNumber
        {
            get { return idNumber; }
            set
            {
                Set(ref idNumber, value);
            }
        }
        private string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                Set(ref customerName, value);
            }
        }
        #endregion CustomerBindingAndInstance

        #region WorkerBindingAndInstance
        Worker worker;
        public Worker WorkerInstance
        {
            get { return worker; }
            set
            {
                Set(ref worker, value);
            }
        }
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                Set(ref startDate, value);
            }
        }
        private DateTime birthDay;
        public DateTime BirthDay
        {
            get { return birthDay; }
            set
            {
                Set(ref birthDay, value);
            }
        }
        #endregion WorkerBindingAndInstance
        public void ResetCutomerTextBinding()
        {         
            IdNumber = 0;
            Name = string.Empty;
        }
        public void ResetWorkerTextBinding()
        {
            Password = string.Empty;
            Name = string.Empty;
            BirthDay = DateTime.Now;
            StartDate = DateTime.Now;
        }
        public void ResetManagerTextBinding()
        {
            Password = string.Empty;
            Name = string.Empty;
        }
    }
}
