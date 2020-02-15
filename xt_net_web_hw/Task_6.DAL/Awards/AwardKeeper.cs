using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Task_6.Interfaces;

namespace Task_6.DAL.Awards
{
    public class AwardKeeper : IAwardKeeper
    {
        private Regex regex;
        private List<IAward> awards;

        public AwardKeeper()
        {
            regex = new Regex(@"<{[^<{}>]+}>");
            awards = new List<IAward>();
        }

        public AwardKeeper(string input)
        {
            regex = new Regex(@"<{[^<{}>]+}>");
            Init(input);
        }

        public bool Init(string input)
        {
            MatchCollection match = regex.Matches(input);

            if (match.Count == 0)
            {
                awards = new List<IAward>();
                return false;
            }

            awards = new List<IAward>(match.Count);
            foreach (Match i in match)
            {
                string name = i.Value.Replace("<{", "").Replace("}>", "");
                IAward award = new Award(awards.Count, name);
                awards.Add(award);
            }
            return true;
        }

        public IAward[] GetAwardsList() => awards.ToArray();

        public IAward GetAward(int id) => awards[id];

        public IAward GetAward(string title)
        {
            IAward award = awards.Find((x) => (x.Title == title));
            if (award == null)
            {
                award = new Award(awards.Count, title);
                awards.Add(award);
            }
            return award;
        }

        public bool ContainsAward(string title)
        {
            IAward award = awards.Find((x) => (x.Title == title));
            if (award == null)
            {
                return false;
            }
            return true;
        }

        public bool ContainsAward(int id)
        {
            IAward award = awards.Find((x) => (x.ID == id));
            if (award == null)
            {
                return false;
            }
            return true;
        }

        public bool RemoveAward(int id)
        {
            IAward award = awards.Find((x) => (x.ID == id));
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

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach(Award award in awards)
            {
                builder.Append($"<{{{award.Title}}}>");
            }

            return builder.ToString();
        }
    }
}
