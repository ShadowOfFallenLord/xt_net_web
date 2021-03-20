using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.Entities.Interfaces
{
    public interface IUser
    {
        int ID { get; }
        string Login { get; }
        //string Password { get; }
        string Role { get; }
    }
}
