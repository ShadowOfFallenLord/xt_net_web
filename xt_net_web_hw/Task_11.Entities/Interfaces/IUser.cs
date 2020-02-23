using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11.Entities.Interfaces
{
    public interface IUser
    {
        int ID { get; }
        string Name { get; }
        DateTime DateOfBirth { get; }
        int Age { get; }
        byte[] Image { get; }
    }
}
