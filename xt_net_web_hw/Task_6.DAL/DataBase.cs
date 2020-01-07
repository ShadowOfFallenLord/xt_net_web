using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Task_6.Interfaces;
using Task_6.DAL.Users;
using Task_6.DAL.Awards;

namespace Task_6.DAL
{
    public class DataBase
    {
        private UserParser user_parser;
        public IAwardKeeper AwardKeeper { get; private set; }
        public IUserDataBase UserDataBase { get; private set; }

        public DataBase()
        {
            user_parser = new UserParser();
            AwardKeeper = new AwardKeeper();
            UserDataBase = new UserDataBase();
        }

        public DataBase(string path)
        {
            user_parser = new UserParser();

            if(!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            string file_content = File.ReadAllText(path);
            string[] file_parts = file_content.Split('\0');

            if(file_parts.Length != 2)
            {
                throw new FormatException("File format wrong.");
            }

            AwardKeeper = new AwardKeeper(file_parts[0]);
            IUser[] users = user_parser.ParseArray(file_parts[1], AwardKeeper);
            UserDataBase = new UserDataBase(users);
        }

        public bool Save(string path)
        {
            using(StreamWriter file = new StreamWriter(path))
            {
                file.Write(AwardKeeper.ToString());
                file.Write('\0');
                foreach (IUser user in UserDataBase)
                {
                    file.Write(user.ToString());
                }
            }
            return true;
        }
    }
}
