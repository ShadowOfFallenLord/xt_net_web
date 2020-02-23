using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.Entities.Interfaces;

namespace Task_11.Entities.Implementation
{
    public class User : IUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get => DateTime.Now.Year - DateOfBirth.Year; }
        public byte[] Image { get; set; }
    }
}
