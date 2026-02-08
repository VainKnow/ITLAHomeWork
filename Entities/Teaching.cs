using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstChamba.Entities
{
    internal class Teaching : Employee

    {
        public string Subject { get; set; }

        public string TeacherId { get; set; }

        public string TeacherName { get; set; }

        public string TeacherEmail { get; set; }

    }
}
