using System;
using System.Text;
using Task_6.DAL.Awards;
using Task_6.Interfaces;
using System.Linq;
using Newtonsoft.Json;
using System.Drawing;

namespace Task_6.DAL.Users
{
    [JsonObject]
    public class User : IUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        [JsonProperty("AwardsPoolInUser")]
        private AwardsPool awards_pool;
        [JsonIgnore]
        public IAwardsPool Awards { get => awards_pool; }
        [JsonProperty("ImageKeeperInUser")]
        public ImageKeeper image;
        [JsonIgnore]
        public IImageKeeper Image { get => image; }

        public User(int id, string name, DateTime dob, int age, params IAward[] awards)
        {
            ID = id;
            Name = name;
            DateOfBirth = dob;
            Age = age;
            awards_pool = new AwardsPool(awards);
            image = DefaultImageKeeper.Keeper;
        }
    }
}
