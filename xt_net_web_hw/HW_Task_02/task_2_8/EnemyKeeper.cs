using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    class EnemyKeeper
    {
        private List<BaseEnemy> enemies;
        
        public EnemyKeeper()
        {
            enemies = new List<BaseEnemy>();
        }

        public void Add(BaseEnemy enemy)
        {
            enemies.Add(enemy);
        }

        private bool HasPlayerAround(int x, int y, GameField field)
        {
            // find player around
            return false;
        }

        private void FindNewPath(BaseEnemy enemy, GameField field)
        {
            // Find new path finish point
        }

        private void MoveEnemy(BaseEnemy enemy, GameField field)
        {
            // Move enemy or attack player
        }

        public void EnemiesStep(GameField field, Player player)
        {
            BaseEnemy current;
            for(int i = 0; i < enemies.Count; i++)
            {
                current = enemies[i];
                if(current.X == current.PathX && current.Y == current.PathY)
                {
                    FindNewPath(current, field);
                }

                if(HasPlayerAround(current.X, current.Y, field))
                {
                    current.SetPath(player.X, player.Y);
                }

                MoveEnemy(current, field);
            }
        }

        public void Clear() => enemies.Clear();
    }
}
