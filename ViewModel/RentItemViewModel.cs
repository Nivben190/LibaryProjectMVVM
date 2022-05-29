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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DimitryProject.ViewModel
{
    public class RentItemViewModel : ViewModelBase
    {
        readonly LibaryManager libaryManager;
        readonly ReportsViewModel reportsViewModel;
        readonly RegisterViewModel registerViewModel;
        public RelayCommand RentItemCommand { get; set; }
        public RentItemViewModel(ReportsViewModel reportsViewModel, RegisterViewModel registerViewModel, LibaryManager libaryManager)
        {
            this.libaryManager = libaryManager;
            this.registerViewModel = registerViewModel;
            this.reportsViewModel = reportsViewModel;
            RentItemCommand = new RelayCommand(RentBooks);
        }
        public void AddRentBook(ClassInstance classInstance) => Logic.Instance.AddItemToLists(classInstance, libaryManager);
        private void RentBooks()
        {
            libaryManager.RentBook(registerViewModel.CurrentCustomer);
            libaryManager.ListOfItemsCustomerWantToRent.ForEach(x =>reportsViewModel.AddRowsRented(x));
            libaryManager.ListOfItemsCustomerWantToRent.Clear();         
        }
    }
}
