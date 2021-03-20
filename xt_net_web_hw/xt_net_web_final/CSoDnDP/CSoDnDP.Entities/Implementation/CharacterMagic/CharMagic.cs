using CSoDnDP.Entities.Interfaces.CharacterMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Implementation.CharacterMagic
{
    public class CharMagic : ICharMagic
    {
        public Dictionary<int, int> SpellCells { get; set; }
        public Dictionary<int, List<string>> Spells { get; set; }
    }
}
