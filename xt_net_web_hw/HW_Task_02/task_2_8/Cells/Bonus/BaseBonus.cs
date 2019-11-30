using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    abstract class BaseBonus : ICellObject
    {
        public abstract char View { get; }

        public abstract BonusType Bonus { get; }

        public CellContentType Type => CellContentType.Bonus;
    }
}
