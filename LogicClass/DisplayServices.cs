using BookLibary.LibaryItemsClasses;
using DimitryProject.LoginClasses;
using DimitryProject.ViewModel;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimitryProject.LogicClass
{
    public class DisplayServices : Idisplayable
    {
        private readonly FilterService FilterService;
        private  readonly ListViewViewMode listViewViewMode;
        private   readonly AddDynamicClassViewModel addDynamicClassViewModel;
        public DisplayServices(FilterService FilterService,
                               AddDynamicClassViewModel addDynamicClassViewModel,
                               ListViewViewMode listViewViewMode)
        {
            this.FilterService = FilterService;
            this.addDynamicClassViewModel = addDynamicClassViewModel;
            this.listViewViewMode = listViewViewMode;
        }
        public void Display(Action display)
        {
            listViewViewMode.ListOfAllItemInLibary.Clear();
            display();
        }
        public void DisplayAllItems()
        {
            MongoDBClass.ConvertDBToList(addDynamicClassViewModel.ListOfAllItems);
            addDynamicClassViewModel.ListOfAllItems.ForEach(x => listViewViewMode.ListOfAllItemInLibary.Add(x));
        }
        public void DisplayFilterItems() => FilterService.FilteredListOfAllItemsInLibary.ForEach(x => listViewViewMode.ListOfAllItemInLibary.Add(x));
    }
}
