using CSoDnDP.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Interfaces.Parties
{
    public interface IParty
    {
        int ID { get; }
        string Name { get; }
        string MasterName { get; }
        PartyState State { get; }
    }
}
