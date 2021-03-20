using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Interfaces.CharacterStates
{
    public interface ISkill
    {
        bool Mastery { get; }
        int Bonus { get; }
        int Value { get; }
    }
}
