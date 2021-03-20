using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.Entities.Interfaces;

namespace Task_11.DAL.Interfaces
{
    public interface IAwardDao
    {
        int AddAward(string title);
        IEnumerable<IAward> GetAllAwards();
        IAward GetAwardByID(int id);
        IAward GetAwardByTitle(string title);
        int GetAwardsCount();
        bool UpdateAward(int id, string title, byte[] img);
        bool UpdateAward(int id, string title);
        bool RemoveAward(int id);
    }
}
