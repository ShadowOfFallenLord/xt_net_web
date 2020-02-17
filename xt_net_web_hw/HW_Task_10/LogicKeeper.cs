using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_6.BLL;

namespace HW_Task_10
{
    public class LogicKeeper
    {
        public const int ImageWidth = 200;
        public const int ImageHeight = 200;
        public static bool IsFirst = true;
        public static UserLogic Logic { get; private set; } = new UserLogic("E:\\" +
            "Program\\Git\\xt_net_web\\xt_net_web_hw\\HW_Task_10\\Content\\data.base");
        // I don't want create files in IIS folder
        // Set folder that is convenient for you
        // With data base file name at end.
    }
}