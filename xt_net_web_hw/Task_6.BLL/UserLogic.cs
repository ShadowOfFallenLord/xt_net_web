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

        public bool Add(string name, DateTime dob, int age)
        {
            return data_base.UserDataBase.Add(name, dob, age);
        }

        public bool Remove(int id)
        {
            return data_base.UserDataBase.Remove(data_base.UserDataBase[id]);
        }

        public bool ContainsAward(string title)
        {
            return data_base.AwardKeeper.ContainsAward(title);
        }

        public bool AddAward(int user_id, int award_id)
        {
            return data_base
                .UserDataBase[user_id]
                .Awards.Add(
                    data_base
                    .AwardKeeper
                    .GetAward(award_id));
        }

        public bool AddAward(int user_id, string award_title)
        {
            return data_base
                .UserDataBase[user_id]
                .Awards.Add(
                    data_base
                    .AwardKeeper
                    .GetAward(award_title));
        }

        public bool RemoveAward(int user_id, int award_id)
        {
            return data_base
                .UserDataBase[user_id]
                .Awards.Remove(award_id);
        }

        public IAward[] GetAllAwards()
        {
            return data_base.AwardKeeper.GetAwardsList();
        }

        public bool Save()
        {
            return data_base.Save(DataBaseFile);
        }

        public int UserCount { get => data_base.UserDataBase.Count; }
    }
}
