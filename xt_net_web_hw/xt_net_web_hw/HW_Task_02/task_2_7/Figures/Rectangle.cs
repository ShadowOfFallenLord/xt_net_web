using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_7
{
    class Rectangle : Figure
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rectangle(Point point, int width, int height, Color color)
            : base(point, color)
        {
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException("Width is negative.");
            }

            if (height < 0)
            {
                throw new ArgumentOutOfRangeException("Height is negative.");
            }

            Width = width;
            Height = height;
        }

        public Rectangle(Point point, int width, int height)
            : this(point, width, height, Color.Black)
        {
            //
        }

        public override void Print()
        {
            Console.Write($"Print rectangle at ({Position.X}, {Position.Y}) ");
            Console.Write($"with {Width} width and {Height} height ");
            Console.WriteLine($"with {Color} color.");
        }
    }
}
