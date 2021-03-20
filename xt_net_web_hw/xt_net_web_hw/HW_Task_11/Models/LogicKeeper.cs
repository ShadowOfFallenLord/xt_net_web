using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_11.BLL;

namespace HW_Task_11
{
    public static class LogicKeeper
    {
        public const int ImageWidth = 200;
        public const int ImageHeight = 200;
        public static DBLogic Logic { get; private set; } = new DBLogic();
        public static DarkRoleProvider RoleProvider { get; private set; } = new DarkRoleProvider();
    }
}