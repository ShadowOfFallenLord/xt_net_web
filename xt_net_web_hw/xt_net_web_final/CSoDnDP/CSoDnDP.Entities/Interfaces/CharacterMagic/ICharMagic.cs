using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Interfaces.CharacterMagic
{
    public interface ICharMagic
    {
        Dictionary<int, int> SpellCells { get; }
        Dictionary<int, List<string>> Spells { get; }
    }
}
