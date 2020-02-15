using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Task_6.Interfaces;

namespace Task_6.DAL.Awards
{
    public class Award : IAward
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public Award(int id, string title)
        {
            ID = id;
            Title = title;
        }
    }
}
