using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Task_6.Interfaces;

namespace Task_6.DAL.Awards
{
    [JsonObject]
    public class AwardsPool : IAwardsPool
    {
        [JsonProperty("AwardsInPool")]
        public List<Award> Awards { get; }

        public AwardsPool(params IAward[] in_awards)
        {
            if (in_awards != null)
            {
                Award[] awards = new Award[in_awards.Length];
                for (int i = 0; i < in_awards.Length; i++)
                {
                    awards[i] = in_awards[i] as Award;
                }

                Awards = new List<Award>(awards);
            }
            else
            {
                Awards = new List<Award>();
            }
        }

        [JsonIgnore]
        public int Count { get => Awards.Count; }

        public bool Add(IAward in_award)
        {
            Award award = in_award as Award;
            if (award == null) throw new ArgumentNullException("award");

            if(Awards.Contains(award))
            {
                return false;
            }

            Awards.Add(award);

            return true;
        }

        public bool Remove(int id)
        {
            int length = Awards.Count;
            Awards.RemoveAll((x) => (x.ID == id));

            if (length == Awards.Count)
            {
                return false;
            }
            return true;
        }

        public bool Remove(string title)
        {
            int length = Awards.Count;
            Awards.RemoveAll((x) => (x.Title == title));

            if (length == Awards.Count)
            {
                return false;
            }
            return true;
        }

        public IEnumerator<IAward> GetEnumerator()
        {
            return Awards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
