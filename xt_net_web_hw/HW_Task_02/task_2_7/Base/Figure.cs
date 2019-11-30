using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_7
{
    abstract class Figure
    {
        public Point Position { get; protected set; }
        public Color Color { get; protected set; }

        protected Figure(Point p, Color color)
        {
            Position = p;
            Color = color;
        }

        protected Figure() 
            : this(new Point(0, 0), Color.Black)
        {
            //
        }

        protected Figure(int x, int y) 
            : this(new Point(x, y), Color.Black)
        {
            //
        }

        protected Figure(int x, int y, Color color)
            : this(new Point(x, y), color)
        {
            //
        }

        protected Figure(int x, int y, byte r, byte g, byte b)
            : this(new Point(x, y), new Color(r, g, b))
        {
            //
        }

        public void Move(Point new_position)
        {
            Position = new_position;
        }

        public abstract void Print();
    }
}
