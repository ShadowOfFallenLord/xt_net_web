using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11.Entities.Implementation
{
    public class DefaultImage
    {
        public static byte[] Image { get; private set; }

        static DefaultImage()
        {
            int Width = 165;
            int Height = 50;
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
                    Image = (byte[])converter.ConvertTo(img, typeof(byte[]));
                }
            }
        }
    }
}
