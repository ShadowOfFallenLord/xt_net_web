using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    class PortalCell : ICellObject
    {
        private bool is_active;

        public PortalCell()
        {
            is_active = false;
        }

        public void Activate()
        {
            is_active = true;
        }

        public char View
        {
            get
            {
                if (is_active)
                {
                    return 'O';
                }
                return '.';
            }
        }

        public CellContentType Type
        {
            get
            {
                if (is_active)
                {
                    return CellContentType.Portal;
                }
                return CellContentType.None;
            }
        }
    }
}
