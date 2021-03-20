using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.Entities.Interfaces;

namespace Task_11.Entities.Implementation
{
    public class Award : IAward
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
    }
}
