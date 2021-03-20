using CSoDnDP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSoDnDP.Model
{
    public static class LogicKeeper
    {
        public static DBLogic Logic { get; private set; } = new DBLogic();
    }
}