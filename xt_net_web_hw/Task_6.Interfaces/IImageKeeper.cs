using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6.Interfaces
{
    public interface IImageKeeper
    {
        int Width { get; }
        int Height { get; }
        byte[] Content { get; }
    }
}
