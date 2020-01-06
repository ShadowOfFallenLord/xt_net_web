using System;
using System.Collections;
using System.Collections.Generic;
using Task_6.Interfaces;

namespace Task_6.DAL.Awards
{
    public class AwardsPool : IAwardsPool
    {
        public List<IAward> Awards { get; }

        public AwardsPool(params IAward[] awards)
        {
            Awards = new List<IAward>(awards);
        }

        public int Count { get => Awards.Count; }

        public bool Add(IAward award)
        {
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
