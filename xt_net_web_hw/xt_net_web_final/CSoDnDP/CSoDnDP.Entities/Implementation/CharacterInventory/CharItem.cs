using CSoDnDP.Entities.Interfaces.CharacterInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Implementation.CharacterInventory
{
    public class CharItem : ICharItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
