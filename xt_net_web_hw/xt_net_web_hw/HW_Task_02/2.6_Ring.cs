using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02
{
    class Ring : Round
    {
        public int InnerRadius { get; private set; }

        public Ring(int x, int y, int inner_radius, int radius) : base(x, y, radius)
        {
            if (inner_radius < 0) throw new ArgumentOutOfRangeException("inner_radius < 0");

            if (inner_radius >= radius)
            {
                throw new ArgumentException("inner_radius >= radius");
            }

            InnerRadius = inner_radius;

            Length = Length + 2 * Math.PI * InnerRadius;
            Area = Area - Math.PI * InnerRadius * InnerRadius;
        }
    }
}
