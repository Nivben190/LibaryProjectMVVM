using BookLibary.LibaryItemsClasses;
using CommunityToolkit.Mvvm.Input;
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
    public class UpdateViewModel:ViewModelBase
    {

        #region UpdateAmountBinding
        private string updateAmountName;
        public string UpdateAmountName
        {
            get { return updateAmountName; }
            set
            {
                Set(ref updateAmountName, value);
            }
        }
        private int itemAmountUpdate;

        public int ItemAmountUpdate
        {
            get { return itemAmountUpdate; }
            set
            {
                Set(ref itemAmountUpdate, value);
            }
        }
        #endregion UpdateAmountBinding
        public RelayCommand UpdateAmountCommand { get; set; }
        public UpdateViewModel()
        {
            UpdateAmountCommand = new RelayCommand(UpdateAmount);

        }
        public void UpdateAmount()
        {
            if (Logic.Instance.CheckIfDetailesValid(UpdateAmountName, ItemAmountUpdate))
            {
                MessageBox.Show("pls enter valid detailes");
                return;
            }

            ClassInstance classInstance = Logic.Instance.GetClassInstance(UpdateAmountName);
            PropertyInstance itemAmount = Logic.Instance.GetItemAmount(classInstance);
            itemAmount.Value =ItemAmountUpdate;
            classInstance.SaveClassWithJson(UpdateAmountName);

            UpdateAmountName = "";
            ItemAmountUpdate = 0;
        }

    }
}
