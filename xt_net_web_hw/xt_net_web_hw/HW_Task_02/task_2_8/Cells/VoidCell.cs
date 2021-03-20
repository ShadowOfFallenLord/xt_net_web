using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    class VoidCell : ICellObject
    {
        public CellContentType Type => CellContentType.None;

        public char View => '.';

        private VoidCell() { }

        static VoidCell()
        {
            Instance = new VoidCell();
        }

        public static VoidCell Instance { get; private set; }
    }
}
