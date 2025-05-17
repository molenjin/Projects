using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorLinkSolver
{ 
    public enum Direction { None, Left, Right, Up, Down };

    public class Field
    {
        public Color color;
        public bool endpoint;        
        public bool turtle;
        public Direction turtleDirection;
        public Direction linkDirection;

        public Field()
        {
            color = Color.Empty;
            endpoint = false;            
            turtle = false;
            turtleDirection = Direction.None;
            linkDirection = Direction.None;
        }
    }
}