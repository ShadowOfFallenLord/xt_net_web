using CSoDnDP.Entities.Interfaces.CharacterStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Implementation.CharacterStates
{
    public class State : IState
    {
        public int Value { get; set; }
        public int Bonus { get; set; }
        public int Modificator { get; set; }

        public Dictionary<string, ISkill> Skills { get; set; }
    }
}
