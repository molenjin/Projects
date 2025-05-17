using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace ColorLinkSolver
{
    public class BoardGraphic : BoardSolver
    {
        private Graphics graphics;

        private Size size;

        Pen pThin = new Pen(Color.Black, 1);
        Pen pThick = new Pen(Color.Black, 2);

        SolidBrush boardBrush = new SolidBrush(Color.White);

        private int boardStartX;
        private int boardStartY;

        private const int fieldSize = 50;

        public BoardGraphic(Graphics graphics, Size size)
        {
            this.graphics = graphics;
            this.size = size;
        }

        public override void SetBoard(int boardSizeX, int boardSizeY)
        {
            base.SetBoard(boardSizeX, boardSizeY);

            boardStartX = (size.Width - boardSizeX * fieldSize) / 2;
            boardStartY = (size.Height - boardSizeY * fieldSize) / 2;
        }

        private void CleanBoard()
        {
            graphics.FillRectangle(boardBrush, 0, 0, size.Width, size.Height);
        }

        private void DrawFrame()
        {
            for (int x = 1; x < boardSizeX; x++)
            {
                graphics.DrawLine(pThin, boardStartX + fieldSize * x, boardStartY, boardStartX + fieldSize * x, boardStartY + boardSizeY * fieldSize);
            }

            for (int y = 1; y < boardSizeY; y++)
            {
                graphics.DrawLine(pThin, boardStartX, boardStartY + fieldSize * y, boardStartX + boardSizeX * fieldSize, boardStartY + fieldSize * y);
            }

            graphics.DrawRectangle(pThick, boardStartX, boardStartY, boardSizeX * fieldSize, boardSizeY * fieldSize);
        }

        private void DrawField(int x, int y)
        {
            SolidBrush brush = new SolidBrush(grid[x, y].color);
            if (grid[x, y].endpoint)
            {
                graphics.FillEllipse(brush, boardStartX + (x - 1) * fieldSize + 5, boardStartY + (y - 1) * fieldSize + 5, fieldSize - 10, fieldSize - 10);
                graphics.DrawEllipse(pThin, boardStartX + (x - 1) * fieldSize + 5, boardStartY + (y - 1) * fieldSize + 5, fieldSize - 10, fieldSize - 10);
            }
            else
            {
                graphics.FillEllipse(brush, boardStartX + (x - 1) * fieldSize + 15, boardStartY + (y - 1) * fieldSize + 15, fieldSize - 31, fieldSize - 31);
            }
        }

        private void DrawLink(int x, int y)
        {
            Pen pLink = new Pen(grid[x, y].color, 20);

            int startX = boardStartX + (x - 1) * fieldSize + (fieldSize / 2);
            int startY = boardStartY + (y - 1) * fieldSize + (fieldSize / 2);

            switch (grid[x, y].linkDirection)
            {
                case Direction.Left:
                    graphics.DrawLine(pLink, startX, startY, startX - fieldSize, startY);
                    break;
                case Direction.Right:
                    graphics.DrawLine(pLink, startX, startY, startX + fieldSize, startY);
                    break;
                case Direction.Up:
                    graphics.DrawLine(pLink, startX, startY, startX, startY - fieldSize);
                    break;
                case Direction.Down:
                    graphics.DrawLine(pLink, startX, startY, startX, startY + fieldSize);
                    break;
            }
        }

        private void DrawFields()
        {
            for (int x = 1; x <= boardSizeX; x++) for (int y = 1; y <= boardSizeY; y++)
            {
                if (!grid[x, y].color.IsEmpty)
                {
                    DrawLink(x, y);
                    DrawField(x, y);                        
                }
            }
        }

        public void DrawBoard()
        {
            CleanBoard();
            DrawFrame();
            DrawFields();
        }
    }
}