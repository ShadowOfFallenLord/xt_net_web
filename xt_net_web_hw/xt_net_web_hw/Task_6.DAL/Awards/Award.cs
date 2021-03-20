using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Task_6.Interfaces;
using Newtonsoft.Json;

namespace Task_6.DAL.Awards
{
    [JsonObject]
    public class Award : IAward
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("ImageKeeperInAward")]
        public ImageKeeper image;
        [JsonIgnore]
        public IImageKeeper Image { get => image; }

        public Award(int id, string title)
        {
            ID = id;
            Title = title;
            image = DefaultImageKeeper.Keeper;
        }
    }
}
