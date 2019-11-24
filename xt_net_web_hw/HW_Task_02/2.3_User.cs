using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02
{
    class User
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string FatherName { get; private set; }

        public DateTime Birth { get; private set; }
        public int Age { get; private set; }

        public User(string name, string last_name, string fathe_name, DateTime birth, int age)
        {
            Name = name;
            LastName = last_name;
            FatherName = fathe_name;
            Birth = birth;
            Age = age;
        }
    }
}
