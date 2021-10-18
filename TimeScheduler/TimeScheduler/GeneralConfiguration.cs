using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeScheduler
{
    public class GeneralConfiguration
    {
        public GeneralConfiguration() { }

        public string ExecutionDate { get; set; }
        public string Enabled { get; set; }
        public string NumDays { get; set; }
        public string ExecutionType { get; set; }
    }
}
