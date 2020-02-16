using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Task_6.Interfaces;
using Task_6.DAL.Users;
using Task_6.DAL.Awards;
using Newtonsoft.Json;

namespace Task_6.DAL
{
    [JsonObject]
    public class DataBase
    {
        [JsonProperty("AwardsKeeper")]
        private AwardKeeper award_keeper;
        [JsonProperty("UsersKeeper")]
        private UserDataBase user_data_base;
        [JsonIgnore]
        public IAwardKeeper AwardKeeper { get => award_keeper; }
        [JsonIgnore]
        public IUserDataBase UserDataBase { get => user_data_base; }

        public DataBase()
        {
            award_keeper = new AwardKeeper();
            user_data_base = new UserDataBase();
        }
    }
}
