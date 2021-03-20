using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Interfaces.CharacterInventory
{
    public interface ICharWeapon
    {
        string Name { get; }
        string Type { get; }
        int Modificator { get; }
        string Damage { get; }
        string Properties { get; }
    }
}
