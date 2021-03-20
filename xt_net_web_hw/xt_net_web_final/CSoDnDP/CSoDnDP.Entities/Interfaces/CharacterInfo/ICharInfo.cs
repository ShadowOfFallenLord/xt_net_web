using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Interfaces.CharacterInfo
{
    public interface ICharInfo
    {
        string Race { get; }
        Dictionary<string, int> Classes { get; }
        string Alignment { get; }
        string Background { get; }
        int LevelMod { get; }
        int Exp { get; }
        int Hp { get; }
        int MaxHp { get; }
        int Speed { get; }
        string Traits { get; }
        string Ideals { get; }
        string Bonds { get; }
        string Flaws { get; }
        Dictionary<string, string> Features { get; }
    }
}
