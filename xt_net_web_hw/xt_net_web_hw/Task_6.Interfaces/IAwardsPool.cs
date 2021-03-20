using System.Collections.Generic;

namespace Task_6.Interfaces
{
    public interface IAwardsPool : IEnumerable<IAward>
    {
        int Count { get; }
        bool Add(IAward award);
        bool Remove(int id);
        bool Remove(string title);
    }
}
