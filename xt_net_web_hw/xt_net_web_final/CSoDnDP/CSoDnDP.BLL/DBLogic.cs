using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.BLL
{
    public class DBLogic
    {
        private string connection_string = @"Data Source=darkmashine\sqlexpress;Initial Catalog=CSoDnDP;Integrated Security=True";        
        public UserLogic User { get; private set; }
        public PartyLogic Party { get; private set; }
        public CharacterLogic Character { get; private set; }

        public DBLogic()
        {
            User = new UserLogic(connection_string);
            Party = new PartyLogic(connection_string);
            Character = new CharacterLogic(connection_string);
        }
    }
}
