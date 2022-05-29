using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Manager : IWorker
    {
        public bool IsManagerAccess { get;set; }
        public string Name { get; set ; }
        public string Password { get; set ; }
    }
}
