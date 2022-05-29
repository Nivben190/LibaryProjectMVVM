using BookLibary.LibaryItemsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimitryProject.LogicClass
{
    public static  class HelperFuncService
    {   
        public static ClassInstance GetItemByName(string ItemName , List<ClassInstance> ListOfAllItems) => ListOfAllItems.FirstOrDefault(x => x.ClassName == ItemName);
        public static PropertyInstance GetItemPrice(ClassInstance classInstance, string itemPriceConst) => classInstance.ListOfPropertyInstances.FirstOrDefault(item => item.PropertyTamplate.Name == itemPriceConst);

    }
}
