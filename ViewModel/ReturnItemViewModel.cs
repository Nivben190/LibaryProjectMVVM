using BookLibary;
using BookLibary.LibaryItemsClasses;
using CommunityToolkit.Mvvm.Input;
using DimitryProject.ForInterfaceClasses;
using DimitryProject.LogicClass;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DimitryProject.ViewModel
{
    public class ReturnItemViewModel : ViewModelBase
    {
        #region Binding
        private string bookName;
        public string BookName
        {
            get { return bookName; }
            set
            {
                Set(ref bookName, value);
            }
        }
        readonly LibaryManager libaryManager;
        readonly ReportsViewModel reportsViewModel;
        public RelayCommand ReturnItemCommand { get; set; }
        public RelayCommand AddReturnItem { get; set; }
        #endregion Binding
        public ReturnItemViewModel(LibaryManager libaryManager, ReportsViewModel reportsViewModel)
        {
            this.libaryManager = libaryManager;
            this.reportsViewModel = reportsViewModel;
            ReturnItemCommand = new RelayCommand(ReturnItem);
            AddReturnItem = new RelayCommand(AddReturnItemFunc);
        }
        public void ReturnItem()
        {
            libaryManager.ReturnItem();
            libaryManager.ListOfItemsCustomerWantToReturn.ForEach(x => reportsViewModel.AddRowsReturned(x));           
            BookName = "";
        }
        private void AddReturnItemFunc()
        {
            bool isBookNameNull = BookName == "";

            if (isBookNameNull)
            {
                MessageBox.Show("Pls Enter Book Name");
                return;
            }
            ClassInstance classInstance = Logic.Instance.GetClassInstance(BookName);
            if (classInstance != null) libaryManager.ListOfItemsCustomerWantToReturn.Add(classInstance);

            else ForInterface.ForInterfaceInstance.DisplayError("you didnt rented this book");
            BookName = "";
        }

    }
}
