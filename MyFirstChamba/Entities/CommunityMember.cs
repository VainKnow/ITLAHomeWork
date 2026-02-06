using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstChamba.Entities
{
    public class CommunityMember
    {
        public int id { get; set; }
        public string Name { get; set; }

        public int age { get; set; }

        public string Description { get; set; } 

        public void Mostrarinfo()
        {
            Console.WriteLine($"ID: {id}, Name: {Name}, Description: {Description}");
        }
    }
}
