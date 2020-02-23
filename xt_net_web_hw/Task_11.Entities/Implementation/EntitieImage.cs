using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.Entities.Interfaces;

namespace Task_11.Entities.Implementation
{
    public class EntitieImage : IEntitieImage
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public byte[] Content { get; set; }
    }
}
