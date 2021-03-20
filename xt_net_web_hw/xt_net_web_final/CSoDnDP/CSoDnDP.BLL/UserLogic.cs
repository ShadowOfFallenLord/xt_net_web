using CSoDnDP.DAL.Implementation;
using CSoDnDP.DAL.Interfaces;
using CSoDnDP.Entities.Enums;
using CSoDnDP.Entities.Implementation;
using CSoDnDP.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.BLL
{
    public class UserLogic
    {
        private string connection_string;
        private IUserDao user_dao;

        public UserLogic(string connection_string)
        {
            this.connection_string = connection_string;
            user_dao = new UserDao(connection_string);
        }

        public IEnumerable<IUser> GetAllUser()
        {
            return user_dao.GetAllUsers();
        }

        public IUser GetUserInfo(string user_name)
        {
            return user_dao.GetUserByName(user_name);
        }

        public IEnumerable<string> GetUserRoles(int user_id)
        {
            return user_dao.GetUserRoles(user_id);
        }

        public bool SetUserRole(int user_id, string role)
        {
            int role_id = -1;
            switch (role)
            {
                case "user":
                    role_id = 0;
                    break;
                case "admin":
                    role_id = 1;
                    break;
                default: return false;
            }

            return user_dao.SetUserRole(user_id, role_id);
        }

        public bool AddUser(string user_name, string user_pass)
        {
            if(user_dao.GetUserByName(user_name) != null)
            {
                return false;
            }

            return user_dao.AddUser(user_name, user_pass);
        }

        public AuthResult CheckAuth(string user_name, string user_pass)
        {
            IUser user = user_dao.GetUserByName(user_name);

            if(user == null)
            {
                return AuthResult.LoginFail;
            }

            if((user as User).Password != user_pass)
            {
                return AuthResult.PasswordFail;
            }

            return AuthResult.Correct;
        }

        public void RemoveUser(int user_id)
        {
            user_dao.RemoveUser(user_id);
        }
    }
}
