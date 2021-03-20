using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    interface ICellObject
    {
        char View { get; }
        CellContentType Type { get; }
    }
}
