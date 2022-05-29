using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DimitryProject.LoginClasses
{
    public class VisibilityFuncs : ViewModelBase
    {
        #region Binding

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
        #endregion Binding       
        public VisibilityFuncs() 
        {
            IsVissibleForManager = Visibility.Collapsed;
            IsVissibleForCustomer = Visibility.Collapsed;
            IsVissibleForManagerAndWorker = Visibility.Collapsed;
        }
        public void ResetAllVisiblity()
        {
            IsVissibleForCustomer = Visibility.Collapsed;
            IsVissibleForManager = Visibility.Collapsed;
            IsVissibleForManagerAndWorker = Visibility.Collapsed;
        }
        public void LoginCustomerVisibility()
        {
            IsVissibleForManager = Visibility.Collapsed;
            IsVissibleForCustomer = Visibility.Visible;
            IsVissibleForManagerAndWorker = Visibility.Collapsed;
        }
        public void LoginWorkerVisibility()
        {
            IsVissibleForCustomer = Visibility.Collapsed;
            IsVissibleForManagerAndWorker = Visibility.Visible;
            IsVissibleForManager = Visibility.Collapsed;
        }
        public void LoginManagerVisibility()
        {
            IsVissibleForCustomer = Visibility.Collapsed;
            IsVissibleForManagerAndWorker = Visibility.Visible;
            IsVissibleForManager = Visibility.Visible;
        }
    }
}
