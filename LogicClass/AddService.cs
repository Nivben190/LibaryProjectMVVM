using BookLibary.LibaryItemsClasses;
using Services.ServicesExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimitryProject.LogicClass
{
    public class AddService
    {
        private AddService() { }
        private static AddService instance = null;
        public static AddService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AddService();
                }
                return instance;
            }
        }
        public void AddItemToList(ClassInstance itemToAdd, List<ClassInstance> list)
        {
            list.Add(itemToAdd);

        }
    }
}
