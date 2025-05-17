using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorLinkSolver
{
    public class AppSettings
    {
        public List<Task> Tasks { get; set; }

        public class Task
        {
            public string Name { get; set; }
            public int BoardSizeX { get; set; }
            public int BoardSizeY { get; set; }
            public List<Point> Points { get; set; }
            public class Point
            {
                public int X { get; set; }
                public int Y { get; set; }
                public string Color { get; set; }
            }
        }
    }
}
