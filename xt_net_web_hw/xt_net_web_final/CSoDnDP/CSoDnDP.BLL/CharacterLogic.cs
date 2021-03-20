using CSoDnDP.DAL.Implementation;
using CSoDnDP.DAL.Interfaces;
using CSoDnDP.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSoDnDP.BLL
{
    public class CharacterLogic
    {
        private string connection_string;
        private ICharacterDao character_dao;

        public CharacterLogic(string connection_string)
        {
            this.connection_string = connection_string;
            character_dao = new CharacterDao(connection_string);
        }

        public IEnumerable<ICharacter> GetAllCharacter()
        {
            return character_dao.GetAllCharacters();
        }

        public IEnumerable<ICharacter> GetPlayerCharacter(string user_name)
        {
            return character_dao.GetAllCharacters().Where((x) => x.PlayerName == user_name);
        }

        public ICharacter GetCharacterByID(int id)
        {
            return character_dao.GetCharacterByID(id);
        }

        public bool AddChar(int player_id, string char_name, XElement info,
            XElement states, XElement magic, XElement inventory)
        {
            return character_dao.AddChar(player_id,
                char_name, info, states, magic, inventory);
        }

        public void RemoveChar(int char_id)
        {
            character_dao.RemoveChar(char_id);
        }

        public void UpdateChar(int char_id, string char_name, XElement info,
            XElement states, XElement magic, XElement inventory)
        {
            character_dao.UpdateChar(char_id, char_name, info, states, magic, inventory);
        }
    }
}
