using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.DAL.Interfaces;
using Task_11.DAL.Implementation;
using Task_11.Entities.Interfaces;
using Task_11.Entities.Enums;

namespace Task_11.BLL
{
    public class DBLogic
    {
        private string connection_string = @"Data Source=DARKMASHINE\SQLEXPRESS;Initial Catalog=UsersDB;Integrated Security=True";
        private IUserDao users_dao;
        private IAwardDao award_dao;
        private IUserAwardsDao user_awards_dao;
        private IClientDao client_dao;

        public DBLogic()
        {
            users_dao = new UserDao(connection_string);
            award_dao = new AwardDao(connection_string);
            user_awards_dao = new UserAwardsDao(connection_string);
            client_dao = new ClientDao(connection_string);
        }

        #region USER_METHODS

        public IUser[] GetAllUsers()
        {
            return users_dao.GetAllUsers().ToArray();
        }

        public IUser GetUserInfo(int id)
        {
            return users_dao.GetUserByID(id);
        }

        public bool AddUser(string name, DateTime dob)
        {
            users_dao.AddUser(name, dob);
            return true;
        }

        public bool UpdateUser(int id, string name, DateTime date)
        {
            return users_dao.UpdateUser(id, name, date);
        }

        public bool UpdateUser(int id, string name, DateTime date, byte[] new_image)
        {
            return users_dao.UpdateUser(id, name, date, new_image);
        }

        public bool RemoveUser(int id)
        {
            user_awards_dao.RemoveAllAwardFromUser(id);
            return users_dao.RemoveUser(id);
        }

        public int UserCount { get => users_dao.GetUsersCount(); }

        #endregion
        #region AWARD_METHODS

        public IAward[] GetAllAwards()
        {
            return award_dao.GetAllAwards().ToArray();
        }

        public IAward GetAward(int id)
        {
            return award_dao.GetAwardByID(id);
        }

        public int AwardCount
        {
            get => award_dao.GetAwardsCount();
        }

        public bool AddAward(string title)
        {
            return award_dao.AddAward(title) > 0;
        }

        public bool ContainsAward(int id)
        {
            return award_dao.GetAwardByID(id) != null;
        }

        public bool ContainsAward(string title)
        {
            return award_dao.GetAwardByTitle(title) != null;
        }

        public bool UpdateAward(int id, string title)
        {
            return award_dao.UpdateAward(id, title);
        }

        public bool UpdateAward(int id, string title, byte[] new_image)
        {
            return award_dao.UpdateAward(id, title, new_image);
        }

        public bool RemoveAward(int id)
        {
            user_awards_dao.RemoveAwardFromAll(id);
            return award_dao.RemoveAward(id);
        }

        #endregion
        #region USER_AWARDS_METHODS

        public IAward[] GetUserAwards(int user_id)
        {
            return user_awards_dao.GetUserAwards(user_id).ToArray();
        }

        public bool AddAwardToUser(int user_id, int award_id)
        {
            if(user_awards_dao.HaveUserAward(user_id, award_id))
            {
                return false;
            }
            return user_awards_dao.AddAwardToUser(user_id, award_id);
        }

        public bool AddAwardToUser(int user_id, string award_title)
        {
            IAward award = award_dao.GetAwardByTitle(award_title);
            int id = -1;
            if(award != null)
            {
                id = award.ID;
            }
            else
            {
                id = award_dao.AddAward(award_title);
            }
            return AddAwardToUser(user_id, id);
        }

        public bool RemoveAwardFromUser(int user_id, int award_id)
        {
            return user_awards_dao.RemoveAwardFromUser(user_id, award_id);
        }

        public bool RemoveAwardFromAll(int award_id)
        {
            return user_awards_dao.RemoveAwardFromAll(award_id);
        }
        #endregion
        #region CLIENT_METHODS
        public IClient[] GetAllClients()
        {
            return client_dao.GetAllClients();
        }

        public string[] GetRolesForClient(string user_name)
        {
            return client_dao.GetRolesForClient(user_name);
        }

        public int GetClientID(string user_name)
        {
            return client_dao.GetClientID(user_name);
        }

        public bool SetRoleToClient(int user_id, bool set_admin = false)
        {
            return client_dao.SetRoleToClient(user_id, set_admin);
        }

        public bool AddNewClient(string user_name, string user_pass)
        {
            return client_dao.AddNewClient(user_name, user_pass);
        }

        public AuthResult AuthClient(string user_name, string user_pass)
        {
            return client_dao.AuthClient(user_name, user_pass);
        }
        #endregion
    }
}
