using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Interfaces.CharacterStates
{
    public interface ICharStates
    {
        int LevelBonus { get; }
        Dictionary<string, IState> States { get; }
        List<string> Languages { get; }
        List<string> Proficiencies { get; }
    }
}
