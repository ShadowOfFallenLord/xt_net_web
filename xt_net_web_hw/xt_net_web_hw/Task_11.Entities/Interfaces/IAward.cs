using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11.Entities.Interfaces
{
    public interface IAward
    {
        int ID { get; }
        string Title { get; }
        byte[] Image { get; }
    }
}
