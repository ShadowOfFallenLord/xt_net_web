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
        public static byte[] DefaultImage { get; private set; }

        static DefaultImageKeeper()
        {
            using (Bitmap img = new Bitmap(165, 50))
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
        }
    }
}
