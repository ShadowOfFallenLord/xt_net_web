using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    class CherryBonus : BaseBonus
    {
        public override char View => '8';

        public override BonusType Bonus => BonusType.Effect2;
    }
}
