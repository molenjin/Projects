using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ColorLinkSolver
{
    public class Board
    {      
        public Field[,] grid;

        protected int boardSizeX;
        protected int boardSizeY;

        public virtual void SetBoard(int boardSizeX, int boardSizeY)
        {
            this.boardSizeX = boardSizeX;
            this.boardSizeY = boardSizeY;

            grid = new Field[boardSizeX + 1, boardSizeY + 1];
            for (int x = 1; x <= boardSizeX; x++) for (int y = 1; y <= boardSizeY; y++)
                {
                    grid[x, y] = new Field();
                }
        }

        public void SetEndPoint(int x, int y, Color color)
        {
            grid[x, y].color = color;
            grid[x, y].endpoint = true;
            grid[x, y].turtle = true;
        }
    }
}