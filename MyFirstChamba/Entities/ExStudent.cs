using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstChamba.Entities
{
    internal class ExStudent : Student
    {
        public string Reason { get; set; }

        public DateTime ExclusionDate { get; set; }

        public bool Graduated { get; set; }
    }
}
