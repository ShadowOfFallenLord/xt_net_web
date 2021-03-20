using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    class Cell
    {
        public ICellObject Content { get; set; }

        public Cell()
        {
            Content = VoidCell.Instance;
        }
    }
}
