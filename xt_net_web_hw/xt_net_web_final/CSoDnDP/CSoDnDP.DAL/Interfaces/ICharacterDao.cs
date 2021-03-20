using CSoDnDP.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSoDnDP.DAL.Interfaces
{
    public interface ICharacterDao
    {
        IEnumerable<ICharacter> GetAllCharacters();
        ICharacter GetCharacterByID(int id);
        bool AddChar(int player_id, string char_name, XElement info,
            XElement states, XElement magic, XElement inventory);
        void UpdateChar(int char_id, string char_name, XElement info,
            XElement states, XElement magic, XElement inventory);
        void RemoveChar(int char_id);
    }
}
