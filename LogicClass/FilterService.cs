using BookLibary.LibaryItemsClasses;
using DimitryProject.ViewModel;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimitryProject.LogicClass
{
    public class FilterService : IFilterable
    {
        private AddDynamicClassViewModel addDynamicClassViewModel;
        public List<ClassInstance> FilteredListOfAllItemsInLibary { get; set; }
        public FilterService(AddDynamicClassViewModel addDynamicClassViewModel)
        {
            FilteredListOfAllItemsInLibary = new List<ClassInstance>();
            this.addDynamicClassViewModel = addDynamicClassViewModel;
        }
        public void FilterBy(string stringToFilterBy, object enteredByUser)
        {
            FilteredListOfAllItemsInLibary.Clear();

            foreach (var item in addDynamicClassViewModel.ListOfAllItems)
            {
                ClassInstance classInstance = item.Filter(stringToFilterBy, enteredByUser);
                if (classInstance != default) FilteredListOfAllItemsInLibary.Add(classInstance);
            }
        }
        public void FilterByAmountInLibary(string filtered) => FilterBy("Item Amount", filtered);
        public void FilterByCategory(string filterText)
        {
            FilteredListOfAllItemsInLibary.Clear();
            foreach (var item in addDynamicClassViewModel.ListOfAllItems)
            {
                bool isThere = item.ListOfCategorys.Contains(filterText);
                if (isThere != false) FilteredListOfAllItemsInLibary.Add(item);
            }
        }
        public void FilterByName(string filtered) => FilterBy("Item Amount", filtered);
        public void FilterByPrice(string filtered) => FilterBy("Item Price", filtered);
    }
}
