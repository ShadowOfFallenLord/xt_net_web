using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_7
{
    struct Color
    {
        public byte A { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public Color(uint argb)
        {
            A = (byte)((argb & 0xFF000000) >> 6);
            R = (byte)((argb & 0x00FF0000) >> 4);
            G = (byte)((argb & 0x0000FF00) >> 2);
            B = (byte)(argb & 0x000000FF);
        }

        public Color(int argb) : this((uint)argb)
        {
            //
        }

        public Color(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public Color(byte r, byte g, byte b) : this((byte)0xFF, r, g, b)
        {
            //
        }

        public static Color Black => new Color(0xFF, 0xFF, 0xFF);

        public override string ToString()
        {
            return $"({A}, {R}, {G}, {B})";
        }
    }
}
