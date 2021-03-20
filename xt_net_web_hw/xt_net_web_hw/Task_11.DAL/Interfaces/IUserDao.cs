using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.Entities.Interfaces;

namespace Task_11.DAL.Interfaces
{
    public interface IUserDao
    {
        int AddUser(string name, DateTime dob);
        bool UpdateUser(int id, string name, DateTime dob, byte[] img);
        bool UpdateUser(int id, string name, DateTime dob);
        bool RemoveUser(int id);
        IUser GetUserByID(int id);
        IEnumerable<IUser> GetAllUsers();
        int GetUsersCount();
    }
}
