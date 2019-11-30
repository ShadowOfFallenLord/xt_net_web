using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    class WolfEnemy : BaseEnemy
    {
        public override AttackType AttackType => AttackType.Effect1;
        public override char View => 'w';

        public WolfEnemy(int x, int y) : base(x, y)
        {
            //
        }
    }
}
