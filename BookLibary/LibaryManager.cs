using BookLibary.LibaryItemsClasses;
using BookLibary.LibaryManagmentClasses;
using Services;
using Services.ServicesExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibary
{
    public class LibaryManager
    {
        #region InstanceAndProp
        Timer libaryTimeManagment;
         
        public ItemCollection ItemCollection { get; set; }
        IMessagbleService messagbleService;
        public List<ClassInstance> ListOfItemsCustomerWantToRent { get; set; }
        public List<ClassInstance> ListOfItemsCustomerWantToReturn { get; set; }
        #endregion InstanceAndProp

        public LibaryManager(IMessagbleService messagbleService)
        {
            TimeSpan afterSevenDays = new TimeSpan(0, 0, 0, 36);
            TimeSpan everyDay = new TimeSpan(0, 0, 0, 30);
            this.messagbleService = messagbleService;
            ItemCollection = new ItemCollection();
            ListOfItemsCustomerWantToRent = new List<ClassInstance>();
            ListOfItemsCustomerWantToReturn = new List<ClassInstance>();
            libaryTimeManagment = new Timer(CheckRentedDates, null, afterSevenDays, everyDay);
        }

        #region timerManager
        private void CheckRentedDates(object state)
        {
            for (int i = 0; i < ItemCollection.ListOfAllItemsInLibary.Count; i++)
            {
                if (ItemCollection.ListOfAllItemsInLibary[i].RentExipredDate <= DateTime.Now)
                {
                    var itemAmount = Convert.ToInt32(ItemCollection.ListOfAllItemsInLibary[i].ListOfPropertyInstances.FirstOrDefault(itemAmounts => itemAmounts.PropertyTamplate.Name == "Item Amount").Value);
                    ItemCollection.ListOfAllItemsInLibary[i]["Item Amount"].Value = itemAmount++;
                    ItemCollection.ListOfAllItemsInLibary[i].RentedByCustomerRef.Credit -=  Convert.ToInt32(ItemCollection.ListOfAllItemsInLibary[i]["Item Price"].Value);
                    messagbleService.DisplayWarning($"{ItemCollection.ListOfAllItemsInLibary[i].RentedByCustomerRef.Name} failed to return {ItemCollection.ListOfAllItemsInLibary[i].ClassName} \n and funded By the amount of {ItemCollection.ListOfAllItemsInLibary[i]["Item Price"].Value}");
                }
                else return;
            }
        }
        #endregion timerManager

        #region RentBook
        public void RentBook(Customer currentCustomer)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ListOfItemsCustomerWantToRent)
            {
                int itemAmount, itemPrice;
                GetItemAmountAndPrice(item, out itemAmount, out itemPrice);
                if (item != default && currentCustomer.Credit > itemPrice && itemAmount >= 1)
                {
                    item.RentExipredDate = DateTime.Now.AddDays(7);
                    currentCustomer.BorrowedItemList.Add(item);
                    item.RentedByCustomerRef = currentCustomer;
                    CalaculateCreditAndAmount(currentCustomer, item);
                    sb.Append($"{item.ClassName}\n");
                    item.SaveClassWithJson(item.ClassName);
                }
                else
                {
                    messagbleService.DisplayError($"We Are Sorry, we cant complete Your Rent, the book that didnt completed is {item.ClassName}");
                    RentBookFailed(ListOfItemsCustomerWantToRent, currentCustomer);
                    return;
                }
            }
            messagbleService.DisplayWarning($"thank you for you Rent,you rented this books:\n {sb} please returnd them by next week ");
        }
        public void ReturnItem()
        {
            if (ListOfItemsCustomerWantToReturn.Count == 0)
            {
                messagbleService.DisplayError("we are sorry but you didnt rent any book");
                return;
            }
            foreach (var itemToReturn in ListOfItemsCustomerWantToReturn)
            {
                int itemAmount = Convert.ToInt32(itemToReturn.ListOfPropertyInstances.FirstOrDefault(itemAmounts => itemAmounts.PropertyTamplate.Name == "Item Amount").Value);

                if (itemToReturn != default)
                {
                    itemToReturn["Item Amount"].Value = itemAmount + 1;
                    //findedBook.RentExipredDate = DateTime.Now.AddDays(7);
                    itemToReturn.RentedByCustomerRef = null;
                    itemToReturn.SaveClassWithJson(itemToReturn.ClassName);

                }
                else messagbleService.DisplayError($"We Are Sorry, You didnt Rented This Item{itemToReturn.ClassName}");
            }
        }
        private static void CalaculateCreditAndAmount(Customer customer, ClassInstance classInstance)
        {
            int itemAmount = Convert.ToInt32(classInstance.ListOfPropertyInstances.FirstOrDefault(itemAmounts => itemAmounts.PropertyTamplate.Name == "Item Amount").Value);
            int itemPrice = Convert.ToInt32(classInstance.ListOfPropertyInstances.FirstOrDefault(itemAmounts => itemAmounts.PropertyTamplate.Name == "Item Price").Value);

            customer.Credit -= itemPrice;
            classInstance["Item Amount"].Value = itemAmount-1;
        }
        private void RentBookFailed(List<ClassInstance> listOfitemUserRented,Customer customer)
        {
            foreach (var item in listOfitemUserRented)
            {
                var itemAmount = Convert.ToInt32(item.ListOfPropertyInstances.FirstOrDefault(itemAmounts => itemAmounts.PropertyTamplate.Name == "Item Amount").Value);
                int itemPrice = Convert.ToInt32(item.ListOfPropertyInstances.FirstOrDefault(itemAmounts => itemAmounts.PropertyTamplate.Name == "Item Price").Value);

                item["Item Amount"].Value = itemAmount + 1;
                customer.Credit += itemPrice;
            }
        }
        private static void GetItemAmountAndPrice(ClassInstance item, out int itemAmount, out int itemPrice)
        {
            itemAmount = Convert.ToInt32(item.ListOfPropertyInstances.FirstOrDefault(itemAmounts => itemAmounts.PropertyTamplate.Name == "Item Amount").Value);
            itemPrice = Convert.ToInt32(item.ListOfPropertyInstances.FirstOrDefault(itemAmounts => itemAmounts.PropertyTamplate.Name == "Item Price").Value);
        }
       
        #endregion RentBook
    }
}
