using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_7
{
    class Round : Circle
    {
        public Round(Circle circle)
            : base(circle.Position, circle.Raduis)
        {
            //
        }

        public Round(Point point, int radius)
            : base(point, radius)
        {
            //
        }

        public Round(Point point, int radius, Color color) 
            : base(point, radius, color)
        {
            //
        }

        public override void Print()
        {
            Console.Write($"Print round at ({Position.X}, {Position.Y}) ");
            Console.Write($"with {Raduis} radius ");
            Console.WriteLine($"with {Color} color.");
        }
    }
}
