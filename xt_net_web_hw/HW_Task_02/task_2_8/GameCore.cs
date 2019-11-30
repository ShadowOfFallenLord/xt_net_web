using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    class GameCore
    {
        private GameField field;
        private EnemyKeeper enemy_keeper;
        private Player player;
        private bool is_game_over;

        public GameCore(int w, int h, int bonus_count, int enemy_count)
        {
            is_game_over = false;
            player = new Player(0, 0);
            enemy_keeper = new EnemyKeeper();

            field = new GameField(w, h, bonus_count, enemy_count);
            field.Generate(enemy_keeper, player);
        }

        private void SayGameOver()
        {
            // smt logic
        }

        public void Step(PlayerComands comand)
        {
            if (is_game_over) return;

            switch(comand)
            {
                case PlayerComands.Up:
                    field.MoveEssense(player, player.X, player.Y - 1);
                    break;
                case PlayerComands.Down:
                    field.MoveEssense(player, player.X, player.Y + 1);
                    break;
                case PlayerComands.Left:
                    field.MoveEssense(player, player.X - 1, player.Y);
                    break;
                case PlayerComands.Right:
                    field.MoveEssense(player, player.X + 1, player.Y);
                    break;
            }

            enemy_keeper.EnemiesStep(field, player);

            if(!player.IsAlive)
            {
                is_game_over = true;
                SayGameOver();
            }

            if(field.IsLevelFinished)
            {
                field.Generate(enemy_keeper, player);
            }
        }
    }
}
