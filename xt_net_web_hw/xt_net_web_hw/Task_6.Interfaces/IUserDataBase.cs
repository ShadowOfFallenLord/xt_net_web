using System;
using System.Collections.Generic;

namespace Task_6.Interfaces
{
    public interface IUserDataBase : IEnumerable<IUser>
    {
        bool Add(string name, DateTime dob, int age, params IAward[] awards);
        bool Remove(IUser user);
        int Count { get; }
        IUser this[int index] { get; }
    }
}
