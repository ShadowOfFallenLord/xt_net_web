using CSoDnDP.Entities.Interfaces.CharacterInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Implementation.CharacterInventory
{
    public class CharInventory : ICharInventory
    {
        public List<ICharWeapon> Weapons { get; set; }
        public List<ICharArmor> Armors { get; set; }
        public List<ICharItem> Items { get; set; }
        public int CopperMoney { get; set; }
        public int SilverMoney { get; set; }
        public int ElectrumMoney { get; set; }
        public int GoldMoney { get; set; }
        public int PlatinumMoney { get; set; }
    }
}
