using CSoDnDP.Entities.Interfaces.CharacterStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Implementation.CharacterStates
{
    public class CharStates : ICharStates
    {
        public int LevelBonus { get; set; }
        public Dictionary<string, IState> States { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Proficiencies { get; set; }
    }
}
