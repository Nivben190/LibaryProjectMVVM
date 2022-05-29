using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Worker : IWorker
    {
        public bool IsWorkerAccess { get; set; }
        public string Name { get; set ; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime StartedWorkingDate { get; set; }

    }
}
