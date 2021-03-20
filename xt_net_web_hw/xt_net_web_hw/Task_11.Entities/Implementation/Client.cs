using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.Entities.Interfaces;

namespace Task_11.Entities.Implementation
{
    public class Client : IClient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
