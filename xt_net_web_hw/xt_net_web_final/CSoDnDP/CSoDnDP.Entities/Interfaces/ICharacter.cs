using CSoDnDP.Entities.Interfaces.CharacterInfo;
using CSoDnDP.Entities.Interfaces.CharacterInventory;
using CSoDnDP.Entities.Interfaces.CharacterMagic;
using CSoDnDP.Entities.Interfaces.CharacterStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSoDnDP.Entities.Interfaces
{
    public interface ICharacter
    {
        int ID { get; }
        string PlayerName { get; }
        string Name { get; }
        XElement InfoXML { get; }
        XElement StatesXML { get; }
        XElement MagicXML { get; }
        XElement InventoryXML { get; }

        ICharInfo Info { get; }
        ICharStates States { get; }
        ICharMagic Magic { get; }
        ICharInventory Inventory { get; }

        ICharInfo GetCharInfo();
        ICharStates GetCharStates();
        ICharMagic GetMagic();
        ICharInventory GetCharInventory();

        bool ParseXML();
    }
}
