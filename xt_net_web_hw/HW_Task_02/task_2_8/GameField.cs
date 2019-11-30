using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_8
{
    class GameField
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public int BonusCount { get; private set; }
        public int EnemyCount { get; private set; }
        private PortalCell portal;

        public Cell[,] Field { get; private set; }
        public Cell this[int x, int y] { get => Field[x, y]; }

        public bool IsLevelFinished { get; private set; }

        public GameField(int w, int h, int bonus_count, int enemy_count)
        {
            Width = w;
            Height = h;

            BonusCount = bonus_count;
            EnemyCount = enemy_count;

            Field = new Cell[w, h];
            for(int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    Field[x, y] = new Cell();
                }
            }
        }

        public void Generate(EnemyKeeper enemy_keeper, Player player)
        {
            IsLevelFinished = false;
            enemy_keeper.Clear();
            // Set walls, enemies, bonuses, portal and player
            player.X = Width / 2;
            player.Y = Height / 2;
            Field[Width / 2, Height / 2].Content = portal = new PortalCell();
        }

        private void PlayerMoves(Player player, Cell cell)
        {
            if (cell.Content.Type == CellContentType.Bonus)
            {
                player.UseBonus(cell.Content as BaseBonus);
                cell.Content = VoidCell.Instance;
                BonusCount--;

                if (BonusCount == 0)
                {
                    portal.Activate();
                }
            }

            if (cell.Content.Type == CellContentType.Portal)
            {
                IsLevelFinished = true;
            }
        }

        public void MoveEssense(BaseEssense essense, int x, int y)
        {
            if(essense is Player)
            {
                PlayerMoves(essense as Player, Field[x, y]);
            }

            if (Field[x, y].Content.Type != CellContentType.None) return;

            Field[essense.X, essense.Y].Content = VoidCell.Instance;
            Field[x, y].Content = essense;
            essense.X = x;
            essense.Y = y;
        }
    }
}
