using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Task_6.Interfaces;

namespace Task_6.DAL.Awards
{
    [JsonObject]
    public class AwardKeeper : IAwardKeeper
    {
        [JsonProperty("AwardsInKeeper")]
        private List<Award> awards;

        public AwardKeeper()
        {
            awards = new List<Award>();
        }

        public IAward[] GetAwardsList() => awards.ToArray();

        public IAward GetAward(int id) => awards[id];

        public IAward GetAward(string title)
        {
            Award award = awards.Find((x) => (x.Title == title));
            if (award == null)
            {
                award = new Award(awards.Count, title);
                awards.Add(award);
            }
            return award;
        }

        public bool ContainsAward(string title)
        {
            Award award = awards.Find((x) => (x.Title == title));
            if (award == null)
            {
                return false;
            }
            return true;
        }

        public bool ContainsAward(int id)
        {
            Award award = awards.Find((x) => (x.ID == id));
            if (award == null)
            {
                return false;
            }
            return true;
        }

        public bool RemoveAward(int id)
        {
            Award award = awards.Find((x) => (x.ID == id));
            if (award == null)
            {
                return false;
            }

            for(int i = award.ID + 1; i < awards.Count; i++)
            {
                (awards[i] as Award).ID--;
            }
            awards.RemoveAt(award.ID);
            return true;
        }

        public int Count { get => awards.Count; }
    }
}
