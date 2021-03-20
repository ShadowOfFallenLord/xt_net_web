using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Interfaces.CharacterInventory
{
    public interface ICharArmor
    {
        string Name { get; }
        string Type { get; }
        int ArmorClass { get; }
        string Properties { get; }
    }
}
