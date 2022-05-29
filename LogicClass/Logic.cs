using BookLibary;
using BookLibary.LibaryItemsClasses;
using DimitryProject.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DimitryProject.LogicClass
{
    public class Logic
    {
        private Logic() { }
        private static Logic instance = null;
        public static Logic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logic();
                }
                return instance;
            }
        }
        ClassTemplate ClassTemplateByUsers;
        public ClassInstance GetClassInstance(string name)
        {
            ClassTemplateByUsers = ClassTemplate.CreateInstance(name);
            object[] prop = ClassTemplateByUsers.ListOfProperties.ToArray();
            ClassInstance classInstance = ClassTemplateByUsers.LoadFromJson();
            return classInstance;
        }
        public void AddItemToLists(ClassInstance classInstance, LibaryManager libaryManager)
        {
            if (classInstance is null)
            {
                throw new ArgumentNullException(nameof(classInstance));
            }

            libaryManager.ListOfItemsCustomerWantToRent.Add(classInstance);
        }
        public bool CheckIfDetailesValid(string first,int second)
        {
            return first == "" || first == null || second < 0;
        }
        public PropertyInstance GetItemAmount(ClassInstance classInstance)
        {
            return classInstance.ListOfPropertyInstances.FirstOrDefault(item => item.PropertyTamplate.Name == "Item Amount");
        }
       

    }
}
