using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.Entities.Interfaces;

namespace Task_11.DAL.Interfaces
{
    public interface IUserAwardsDao
    {
        IEnumerable<IAward> GetUserAwards(int user_id);
        bool HaveUserAward(int user_id, int award_id);
        bool AddAwardToUser(int user_id, int award_id);
        bool RemoveAwardFromUser(int user_id, int award_id);
        bool RemoveAwardFromAll(int award_id);
        bool RemoveAllAwardFromUser(int user_id);
    }
}
