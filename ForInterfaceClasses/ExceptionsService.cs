using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimitryProject.ForInterfaceClasses
{
    public class ExceptionsService : IExecptionService
    {
        private ExceptionsService() { }
        private static ExceptionsService instance = null;
        public static ExceptionsService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExceptionsService();
                }
                return instance;
            }
        }
        public bool IsItemISBNValid(long isbn)
        {
            if (isbn.GetType() == typeof(long)) return true;
            else return false;
        }
        public bool IsItemNameValid(string name)
        {
            if (name.Length > 30) return false;
            else return true;
        }
        public bool IsItemStockEnded(int amountInLibary)
        {
            if (amountInLibary >= 1) return false;
            else return true;
        }
        public bool IsItemValide(int amount, string name)
        {
            if (!IsItemNameIsNotNull(name)) return false;
            if (IsItemNameValid(name) && !IsItemStockEnded(amount))
                return true;
            else return false;
        }
        private bool IsItemNameIsNotNull(string  ItemName)
        {
            return ItemName != null;
        }
    }
}

