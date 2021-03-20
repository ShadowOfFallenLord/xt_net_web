using CSoDnDP.DAL.Implementation;
using CSoDnDP.DAL.Interfaces;
using CSoDnDP.Entities.Interfaces.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.BLL
{
    public class PartyLogic
    {
        private string connection_string;
        private IPartyDao party_dao;

        public PartyLogic(string connection_string)
        {
            this.connection_string = connection_string;
            party_dao = new PartyDao(connection_string);
        }

        public bool AddParty(string party_name, int master_id)
        {
            return party_dao.AddParty(party_name, master_id);
        }

        public void RemoveParty(int party_id)
        {
            party_dao.RemoveParty(party_id);
        }

        public bool SetPartyState(int party_id, int state_id)
        {
            return party_dao.SetPartyState(party_id, state_id);
        }

        public IEnumerable<IParty> GetAllParties()
        {
            return party_dao.GetAllParties();
        }

        public IParty GetPartyByID(int party_id)
        {
            return party_dao.GetPartyByID(party_id);
        }

        public bool AddPlayer(int party_id, int player_id, int char_id)
        {
            return party_dao.AddPlayer(party_id, player_id, char_id);
        }

        public void RemovePlayer(int party_id, int char_id)
        {
            party_dao.RemovePlayer(party_id, char_id);
        }

        public IEnumerable<IPartyPlayer> GetPlayers(int party_id)
        {
            return party_dao.GetPlayers(party_id);
        }
    }
}
