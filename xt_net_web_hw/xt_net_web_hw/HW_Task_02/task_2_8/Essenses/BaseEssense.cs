using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    abstract class BaseEssense : ICellObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public BaseEssense(int x, int y)
        {
            X = x;
            Y = y;
        }        

        public abstract char View { get; }
        public abstract CellContentType Type { get; }
    }
}
