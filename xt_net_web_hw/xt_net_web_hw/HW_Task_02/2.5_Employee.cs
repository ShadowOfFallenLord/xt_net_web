using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02
{
    class Employee : User
    {
        public string Post { get; private set; }
        public int Experience { get; private set; }

        public Employee(string name, string last_name, 
            string fathe_name, DateTime birth, int age,
            string post, int exp)
            : base(name, last_name, fathe_name, birth, age)
        {
            if (exp < 1) throw new ArgumentOutOfRangeException("exp");

            Post = post;
            Experience = exp;
        }
    }
}
