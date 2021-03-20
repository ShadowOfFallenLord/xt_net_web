using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Interfaces.Parties
{
    public interface IPartyPlayer
    {
        int PlayerID { get; }
        string PlayerName { get; }
        int CharID { get; }
        string CharName { get; }
    }
}
