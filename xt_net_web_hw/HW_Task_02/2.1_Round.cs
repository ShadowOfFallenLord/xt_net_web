using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02
{
    class Round
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Radius { get; private set; }

        public double Length { get; protected set; }
        public double Area { get; protected set; }

        public Round(int x, int y, int r)
        {
            if (r < 0) throw new ArgumentOutOfRangeException("r < 0");

            X = x;
            Y = y;
            Radius = r;

            Length = 2 * Math.PI * Radius;
            Area = Math.PI * Math.PI * Radius;
        }
    }
}
