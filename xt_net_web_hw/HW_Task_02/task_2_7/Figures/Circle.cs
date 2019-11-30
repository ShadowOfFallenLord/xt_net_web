using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_7
{
    class Circle : Figure
    {
        public int Raduis { get; private set; }

        public Circle(Point point, int radius, Color color)
            : base(point, color)
        {
            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException("Radius is negative.");
            }

            Raduis = radius;
        }

        public Circle(Point point, int radius)
            : this(point, radius, Color.Black)
        {
            //
        }

        public override void Print()
        {
            Console.Write($"Print circle at ({Position.X}, {Position.Y}) ");
            Console.Write($"with {Raduis} radius ");
            Console.WriteLine($"with {Color} color.");
        }
    }
}
