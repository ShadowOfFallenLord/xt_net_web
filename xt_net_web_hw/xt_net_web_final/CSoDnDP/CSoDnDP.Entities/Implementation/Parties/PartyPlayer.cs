using CSoDnDP.Entities.Interfaces.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Implementation.Parties
{
    public class PartyPlayer : IPartyPlayer
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public int CharID { get; set; }
        public string CharName { get; set; }
    }
}
