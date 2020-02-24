using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11.Entities.Interfaces
{
    public interface IClient
    {
        int ID { get; }
        string Name { get; }
        string Role { get; }
    }
}
