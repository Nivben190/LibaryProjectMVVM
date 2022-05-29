using BookLibary.LibaryItemsClasses;
using CommunityToolkit.Mvvm.Input;
using DimitryProject.LogicClass;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimitryProject.ViewModel
{
    public class DisplayItemsViewModel : ViewModelBase
    {
        #region fieldsAndProp
        private DisplayServices displayServices;
        private FilterService filterService;
        private AddDynamicClassViewModel addDynamicClassViewModel;
        private ListViewViewMode listViewViewModel;
        public string FilterCategoryText { get => filterCategoryText; set => Set(ref filterCategoryText, value); }
        private string itemName;
        public string ItemName
        {
            get { return itemName; }
            set
            {
                Set(ref itemName, value);
            }
        }
        private int itemAmount;
        public int ItemAmount
        {
            get { return itemAmount; }
            set
            {
                Set(ref itemAmount, value);
            }
        }

        private int priceFiltered;
        private string filterCategoryText;

        public int PriceFiltered
        {
            get { return priceFiltered; }
            set
            {
                Set(ref priceFiltered, value);
            }
        }
        #endregion fieldsAndProp

        #region RelayCommand
        public RelayCommand FilterByPriceCommand { get; set; }
        public RelayCommand FilterByAMounmCommand { get; set; }
        public RelayCommand FilterByNameCommand { get; set; }
        public RelayCommand FilterByCategoryCommand { get; set; }
        public RelayCommand DisplayAllItemsCommand { get; set; }
        #endregion RelayCommand

        public DisplayItemsViewModel(DisplayServices displayServices, FilterService filterService, AddDynamicClassViewModel addDynamicClassViewModel, ListViewViewMode listViewViewModel)
        {
            this.addDynamicClassViewModel = addDynamicClassViewModel;
            this.listViewViewModel = listViewViewModel;
            this.displayServices = displayServices;
            this.filterService = filterService;
            DisplayAllItemsCommand = new RelayCommand(DisplayAllItems);
            FilterByPriceCommand = new RelayCommand(FilterByPrice);
            FilterByAMounmCommand = new RelayCommand(FilterByAmountInLibary);
            FilterByNameCommand = new RelayCommand(FilterByName);
            FilterByCategoryCommand = new RelayCommand(FilterByCategory);
        }

        #region DisplayItems
        private void AddListToObservableCollection() => displayServices.DisplayAllItems();
        private void AddFilteredListToObservableCollection() => displayServices.DisplayFilterItems();
        #endregion DisplayItems

        #region FilterFunc
        public void FilterByPrice() => FilterBy("Item Price", PriceFiltered);
        private void FilterBy(string stringToFilterBy, object enteredByUser)
        {
            filterService.FilterBy(stringToFilterBy, enteredByUser);
            DisplayFilteredItems();
            ResetFilteredTextBox();
        }
        public void FilterByAmountInLibary() => FilterBy("Item Amount", ItemAmount);
        public void FilterByName() => FilterBy("Item Name", ItemName);
        public void FilterByCategory()
        {
            filterService.FilterByCategory(FilterCategoryText);
            DisplayFilteredItems();
            ResetFilteredTextBox();
        }
        #endregion FilterFunc

        #region DisplayItems
        void DisplayAllItems() => displayServices.Display(AddListToObservableCollection);
        void DisplayFilteredItems() => displayServices.Display(AddFilteredListToObservableCollection);
        #endregion DisplayItems

        #region ResetParameters
        void ResetFilteredTextBox() => PriceFiltered = 0;
        #endregion ResetParameters

    }
}
