using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    enum CellContentType
    {
        None = 0,
        Wall,
        Bonus,
        Portal,
        Player,
        Enemy
    }

    enum BonusType
    {
        Effect1,
        Effect2
    }

    enum AttackType
    {
        Effect1,
        Effect2
    }

    enum PlayerComands
    {
        Up, Down, Left, Right, Other
    }
}
