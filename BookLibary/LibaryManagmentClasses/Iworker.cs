using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibary.LibaryManagmentClasses
{
    internal interface IWorker
    {
        string Name { get; set; }
        string Password { get; set; }
    }
}
