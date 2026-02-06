using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstChamba.Entities
{
    internal class Employee: CommunityMember
    {
        public decimal Salary { get; set; }

        public int SNS  { get; set; }

        public String Job { get; set; }


    }
}
