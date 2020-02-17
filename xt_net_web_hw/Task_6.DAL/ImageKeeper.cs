using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_6.Interfaces;

namespace Task_6.DAL
{
    [JsonObject]
    public class ImageKeeper : IImageKeeper
    {
        [JsonProperty("Width")]
        public int Width { get; set; }
        [JsonProperty("Height")]
        public int Height { get; set; }
        [JsonProperty("ImageBytes")]
        public byte[] Content { get; set; }

        public ImageKeeper(int w, int h, byte[] content)
        {
            Width = w;
            Height = h;
            Content = content;
        }

        public ImageKeeper Copy()
        {
            return new ImageKeeper(Width, Height, Content);
        }
    }
}
