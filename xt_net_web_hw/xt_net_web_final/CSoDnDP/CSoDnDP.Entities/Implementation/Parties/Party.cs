using CSoDnDP.Entities.Enums;
using CSoDnDP.Entities.Interfaces.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Implementation.Parties
{
    public class Party : IParty
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MasterName { get; set; }
        public PartyState State { get; set; }
    }
}
