using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_7
{
    class Ring : Circle
    {
        public int InnerRadius { get; private set; }

        public Ring(Circle circle, int inner_radius)
            : this(circle.Position, circle.Raduis, inner_radius)
        {
            //
        }

        public Ring(Point point, int radius, int inner_radius)
            : this(point, radius, inner_radius, Color.Black)
        {
            //
        }

        public Ring(Point point, int radius, int inner_radius, Color color)
            : base(point, radius, color)
        {
            if (inner_radius < 0)
            {
                throw new ArgumentOutOfRangeException("InnerRadius is negative.");
            }

            InnerRadius = inner_radius;
        }

        public override void Print()
        {
            Console.Write($"Print ring at ({Position.X}, {Position.Y}) ");
            Console.Write($"with {Raduis} radius and {InnerRadius} inner radius ");
            Console.WriteLine($"with {Color} color.");
        }
    }
}
