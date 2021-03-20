using CSoDnDP.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.DAL.Interfaces
{
    public interface IUserDao
    {
        IUser GetUserByName(string name);
        IEnumerable<IUser> GetAllUsers();
        IEnumerable<string> GetUserRoles(int user_id);
        bool SetUserRole(int user_id, int role_id);
        bool AddUser(string user_login, string user_pass);
        void RemoveUser(int user_id);
    }
}
