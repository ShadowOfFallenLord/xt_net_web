using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    abstract class BaseEnemy : BaseEssense
    {
        public override CellContentType Type => CellContentType.Enemy;

        public int PathX { get; private set; }
        public int PathY { get; private set; }

        public void SetPath(int x, int y)
        {
            PathX = x;
            PathY = y;
        }

        public BaseEnemy(int x, int y) : base(x, y)
        {
            PathX = x;
            PathY = y;
        }

        public abstract AttackType AttackType { get; }
    }
}
