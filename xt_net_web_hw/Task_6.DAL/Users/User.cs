using System;
using System.Text;
using Task_6.DAL.Awards;
using Task_6.Interfaces;
using System.Linq;

namespace Task_6.DAL.Users
{
    public class User : IUser
    {
        public int ID { get; set; }
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public int Age { get; set; }
        public IAwardsPool Awards { get; private set; }

        public User(int id, string name, DateTime dob, int age, params IAward[] awards)
        {
            ID = id;
            Name = name;
            DateOfBirth = dob;
            Age = age;
            Awards = new AwardsPool(awards);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<<");

            builder.Append($"\"{ID}\",");
            builder.Append($"\"{Name}\",");
            builder.Append($"\"{DateOfBirth}\",");
            builder.Append($"\"{Age}\"");
            builder.Append(":");
            foreach(IAward i in Awards)
            {
                builder.Append($"{{{i.Title}}}");
            }
            builder.Append(">>");

            return builder.ToString();
        }
    }
}
