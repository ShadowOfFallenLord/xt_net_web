using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    class Player : BaseEssense
    {
        public override CellContentType Type => CellContentType.Player;

        public override char View => '@';

        public bool IsAlive { get; private set; }

        public int State1 { get; private set; }
        public int State2 { get; private set; }

        public Player(int x, int y) : base(x, y)
        {
            State1 = 5;
            State2 = 5;
            IsAlive = true;
        }

        public void UseBonus(BaseBonus bonus)
        {
            switch(bonus.Bonus)
            {
                case BonusType.Effect1:
                    State1++;
                    break;
                case BonusType.Effect2:
                    State2++;
                    break;
            }
        }

        public void GetDamage(BaseEnemy enemy)
        {
            switch(enemy.AttackType)
            {
                case AttackType.Effect1:
                    State1--;
                    break;
                case AttackType.Effect2:
                    State2--;
                    break;
            }

            if (State1 == 0)
            {
                IsAlive = false;
            }

            if (State2 == 0)
            {
                IsAlive = false;
            }
        }
    }
}
