using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.Entities.Enums;
using Task_11.Entities.Interfaces;

namespace Task_11.DAL.Interfaces
{
    public interface IClientDao
    {
        IClient[] GetAllClients();
        string[] GetRolesForClient(string username);
        int GetClientID(string user_name);
        bool SetRoleToClient(int user_id, bool set_admin = false);
        bool AddNewClient(string user_name, string user_pass);
        AuthResult AuthClient(string user_name, string user_pass);
    }
}
