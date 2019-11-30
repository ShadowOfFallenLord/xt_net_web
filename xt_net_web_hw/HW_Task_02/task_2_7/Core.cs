using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_7
{
    class Core
    {
        private List<Figure> figures;

        public Core()
        {
            figures = new List<Figure>();
        }

        public void AddFigure(Figure figure)
        {
            figures.Add(figure);
        }

        public void Print()
        {
            if (figures.Count < 1)
            {
                Console.WriteLine("No figures.");
                return;
            }

            foreach(Figure i in figures)
            {
                i.Print();
            }            
        }
    }
}
