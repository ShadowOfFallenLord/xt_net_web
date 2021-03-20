using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6.DAL
{
    static class DefaultImageKeeper
    {
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public static byte[] DefaultImage { get; private set; }
        public static ImageKeeper Keeper { get; private set; }

        static DefaultImageKeeper()
        {
            Width = 165;
            Height = 50;
            using (Bitmap img = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.Clear(Color.Black);
                    using (Font font = new Font(FontFamily.GenericSansSerif, 25))
                    {
                        g.DrawString("No Image", font, Brushes.Red, 5, 8);
                    }
                    ImageConverter converter = new ImageConverter();
                    DefaultImage = (byte[])converter.ConvertTo(img, typeof(byte[]));
                }
            }
            Keeper = new ImageKeeper(Width, Height, DefaultImage);
        }
    }
}
