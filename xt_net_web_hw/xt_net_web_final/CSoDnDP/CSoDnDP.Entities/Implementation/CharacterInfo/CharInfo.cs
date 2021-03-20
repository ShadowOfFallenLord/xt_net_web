using CSoDnDP.Entities.Interfaces.CharacterInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Implementation.CharacterInfo
{
    public class CharInfo : ICharInfo
    {
        public string Race { get; set; }
        public Dictionary<string, int> Classes { get; set; }
        public string Alignment { get; set; }
        public string Background { get; set; }
        public int LevelMod { get; set; }
        public int Exp { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Speed { get; set; }
        public string Traits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public Dictionary<string, string> Features { get; set; }
    }
}
