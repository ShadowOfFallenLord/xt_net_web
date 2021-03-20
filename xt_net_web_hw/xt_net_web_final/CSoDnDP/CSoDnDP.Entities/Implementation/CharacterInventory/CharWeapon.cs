using CSoDnDP.Entities.Interfaces.CharacterInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Implementation.CharacterInventory
{
    public class CharWeapon : ICharWeapon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Modificator { get; set; }
        public string Damage { get; set; }
        public string Properties { get; set; }
    }
}
