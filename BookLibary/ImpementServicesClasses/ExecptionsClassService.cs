using Services;
using Services.ServicesExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibary.ImpementServicesClasses
{
    internal class ExecptionsClassService : IExecptionService  
    {
       
        public bool IsItemISBNValid(long isbn)
        {
            throw new NotImplementedException();
        }

        public bool IsItemNameValid(string name)
        {
            if (name.Length > 30) return false;
            else return true;
        }

        public bool IsItemStockEnded(int amountInLibary)
        {
            if(amountInLibary<=0) return true;
            else return false ;
        }
    }
}
