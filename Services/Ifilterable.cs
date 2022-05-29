using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IFilterable
    {
        void FilterBy(string stringToFilterBy, object enteredByUser);
        void FilterByPrice(string filtered);
        void FilterByAmountInLibary(string filtered);
        void FilterByCategory(string filterText);
        void FilterByName(string filtered);

    }
}
