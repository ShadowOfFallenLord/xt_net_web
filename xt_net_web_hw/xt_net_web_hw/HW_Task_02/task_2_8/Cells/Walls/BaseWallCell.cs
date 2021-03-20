using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    abstract class BaseWallCell : ICellObject
    {
        public BaseWallCell()
        {
            //
        }

        public CellContentType Type => CellContentType.Wall;

        public abstract char View { get; }
    }
}
