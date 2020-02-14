using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_6.BLL;

namespace HW_Task_10_1
{
    public class LogicKeeper
    {
        public static bool IsFirst = true;
        public static UserLogic Logic { get; private set; } = new UserLogic("E:\\Program\\Git\\xt_net_web\\xt_net_web_hw\\HW_Task_10_1\\Content\\data.base");
    }
}