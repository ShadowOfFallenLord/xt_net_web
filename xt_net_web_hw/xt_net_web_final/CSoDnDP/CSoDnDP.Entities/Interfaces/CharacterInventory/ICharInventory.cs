using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Interfaces.CharacterInventory
{
    public interface ICharInventory
    {
        List<ICharWeapon> Weapons { get; }
        List<ICharArmor> Armors { get; }
        List<ICharItem> Items { get; }
        int CopperMoney { get; }
        int SilverMoney { get; }
        int ElectrumMoney { get; }
        int GoldMoney { get; }
        int PlatinumMoney { get; }
    }
}
