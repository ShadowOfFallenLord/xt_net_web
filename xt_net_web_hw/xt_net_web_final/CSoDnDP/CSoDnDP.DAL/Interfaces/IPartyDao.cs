using CSoDnDP.Entities.Interfaces.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.DAL.Interfaces
{
    public interface IPartyDao
    {
        bool AddParty(string party_name, int master_id);
        void RemoveParty(int party_id);
        bool SetPartyState(int party_id, int state_id);
        IEnumerable<IParty> GetAllParties();
        IParty GetPartyByID(int party_id);
        bool AddPlayer(int party_id, int player_id, int char_id);
        void RemovePlayer(int party_id, int char_id);
        IEnumerable<IPartyPlayer> GetPlayers(int party_id);
    }
}
