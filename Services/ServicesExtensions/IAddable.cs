using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesExtensions
{
    public interface IAddable
    {
        void AddItemToList(object itemToAdd,List<object>list);
    }
}
