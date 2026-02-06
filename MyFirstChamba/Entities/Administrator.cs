using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstChamba.Entities
{
    internal class Administrator : Teaching
    {
        public int AccessLevel { get; set; }
    }
    
}
