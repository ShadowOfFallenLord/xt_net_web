using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Task_6.DAL;
using Task_6.DAL.Users;
using Task_6.DAL.Awards;
using Task_6.Interfaces;

namespace Task_6.BLL
{
    public class UserLogic
    {
        private DataBase data_base;
        public string DataBaseFile { get; private set; }
        public InitErrors InitError { get; private set; }

        public UserLogic(string file)
        {
            DataBaseFile = file;
            InitError = InitErrors.None;

            try
            {
                data_base = new DataBase(DataBaseFile);
            }
            catch(FileNotFoundException)
            {
                InitError = InitErrors.FileExistError;
            }
            catch(FormatException)
            {
                InitError = InitErrors.FileFormatError;
            }
            finally
            {
                if(data_base == null)
                {
                    data_base = new DataBase();
                }
            }
        }

        public UserLogic() : this(Environment.CurrentDirectory + "\\data.base")
        {
            //
        }

        public string[] GetAllUsers()
        {
            return data_base.UserDataBase.Select(x => x.Name).ToArray();
        }

        public IUser GetUserInfo(int id)
        {
            return data_base.UserDataBase[id];
        }

        public bool UpdateUser(IUser in_user, string name, DateTime date)
        {
            User user = in_user as User;
            user.Name = name;
            user.DateOfBirth = date;
            return true;
        }

        public bool AddUser(string name, DateTime dob, int age)
        {
            return data_base.UserDataBase.Add(name, dob, age);
        }

        public bool RemoveUser(int id)
        {
            return data_base.UserDataBase.Remove(data_base.UserDataBase[id]);
        }

        public int UserCount { get => data_base.UserDataBase.Count; }

        public bool AddAwardToUser(int user_id, int award_id)
        {
            return data_base
                .UserDataBase[user_id]
                .Awards.Add(
                    data_base
                    .AwardKeeper
                    .GetAward(award_id));
        }

        public bool AddAwardToUser(int user_id, string award_title)
        {
            return data_base
                .UserDataBase[user_id]
                .Awards.Add(
                    data_base
                    .AwardKeeper
                    .GetAward(award_title));
        }

        public bool RemoveAwardToUser(int user_id, int award_id)
        {
            return data_base
                .UserDataBase[user_id]
                .Awards.Remove(award_id);
        }

        public IAward[] GetAllAwards()
        {
            return data_base.AwardKeeper.GetAwardsList();
        }

        public bool ContainsAward(int id)
        {
            return data_base.AwardKeeper.ContainsAward(id);
        }

        public IAward GetAward(int id)
        {
            return data_base.AwardKeeper.GetAward(id);
        }

        public bool AddAward(string title)
        {
            if(data_base.AwardKeeper.ContainsAward(title))
            {
                return false;
            }
            data_base.AwardKeeper.GetAward(title);
            return true;
        }

        public bool UpdateAward(IAward in_award, string title)
        {
            Award award = in_award as Award;
            award.Title = title;
            return true;
        }

        public bool RemoveAward(int id)
        {
            return data_base.AwardKeeper.RemoveAward(id);
        }

        public bool Save()
        {
            return data_base.Save(DataBaseFile);
        }
    }
}
