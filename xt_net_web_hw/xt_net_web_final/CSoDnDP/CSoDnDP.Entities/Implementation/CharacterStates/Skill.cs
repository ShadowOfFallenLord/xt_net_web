using CSoDnDP.Entities.Interfaces.CharacterStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Implementation.CharacterStates
{
    public class Skill : ISkill
    {
        public bool Mastery { get; set; }
        public int Bonus { get; set; }
        public int Value { get; set; }
    }
}
