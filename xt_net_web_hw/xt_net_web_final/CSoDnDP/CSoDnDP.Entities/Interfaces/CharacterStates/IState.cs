using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Interfaces.CharacterStates
{
    public interface IState
    {
        int Value { get; }
        int Bonus { get; }
        int Modificator { get; }
        Dictionary<string, ISkill> Skills { get; }
    }
}
