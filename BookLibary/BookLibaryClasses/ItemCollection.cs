using BookLibary.LibaryItemsClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibary
{
    public class ItemCollection
    {
        public  List<ClassInstance> ListOfAllItemsInLibary { get; set; }

        public ItemCollection()
        {
            ListOfAllItemsInLibary = new List<ClassInstance>();
        }    
        public void AddItem(ClassInstance ClassInstanceAdded)
        {
            if (!ListOfAllItemsInLibary.Contains(ClassInstanceAdded)&&ClassInstanceAdded!=null)
                ListOfAllItemsInLibary.Add(ClassInstanceAdded);
        }

        #region Indexers
        public ClassInstance this[string name]
        {
            get
            {              
                return ListOfAllItemsInLibary.Find(item => (string)item["Item Name"].Value == name);
            }
        }
        public ClassInstance this[int ISBN]
        {
            get
            {
                return ListOfAllItemsInLibary.Find(item => (int) item["Item Isbn"].Value  == ISBN);
            }
        }
       
        #endregion Indexers


    }
}
