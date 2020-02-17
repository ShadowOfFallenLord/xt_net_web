using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6.Interfaces
{
    public interface IAwardKeeper
    {
        IAward[] GetAwardsList();
        IAward GetAward(int id);
        IAward GetAward(string title);
        bool ContainsAward(string title);
        bool ContainsAward(int id);
        bool RemoveAward(int id);
        int Count { get; }
    }
}
