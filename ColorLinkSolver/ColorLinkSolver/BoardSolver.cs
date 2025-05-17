using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorLinkSolver
{
    public enum BoardStatus { Regular, Solved, Failed };

    public class BoardSolver : Board
    {
        private int PlayableFieldsAround(int x, int y, Color color)
        {
            int result = 0;
            if ((x > 1 && (grid[x-1, y].color.IsEmpty || (grid[x-1, y].turtle && grid[x-1, y].color == color)))) result++;
            if ((x < boardSizeX && (grid[x+1, y].color.IsEmpty || (grid[x+1, y].turtle && grid[x+1, y].color == color)))) result++;
            if ((y > 1 && (grid[x, y-1].color.IsEmpty || (grid[x, y-1].turtle && grid[x, y-1].color == color)))) result++;
            if ((y < boardSizeY && (grid[x, y+1].color.IsEmpty || (grid[x, y+1].turtle && grid[x, y+1].color == color)))) result++;
            return result;
        }

        private BoardStatus GetBoardStatus()
        {
            int emptyFields = 0;
            int turtles = 0;

            for (int x = 1; x <= boardSizeX; x++) for (int y = 1; y <= boardSizeY; y++)
                {
                    if (grid[x, y].color.IsEmpty)
                    {
                        if (!(
                                (x > 1 && (grid[x - 1, y].color.IsEmpty || grid[x - 1, y].turtle)) ||
                                (x < boardSizeX && (grid[x + 1, y].color.IsEmpty || grid[x + 1, y].turtle)) ||
                                (y > 1 && (grid[x, y - 1].color.IsEmpty || grid[x, y - 1].turtle)) ||
                                (y < boardSizeY && (grid[x, y + 1].color.IsEmpty || grid[x, y + 1].turtle))
                            ))
                            return BoardStatus.Failed;

                        emptyFields++;
                    }
                    else
                    {
                        if (grid[x, y].turtle)
                        {
                            if (PlayableFieldsAround(x, y, grid[x, y].color) == 0)
                                return BoardStatus.Failed;

                            turtles++;
                        }
                    }
                }

            if (emptyFields != 0 && turtles == 0) return BoardStatus.Failed;
            if (emptyFields == 0 && turtles == 0) return BoardStatus.Solved;

            return BoardStatus.Regular;
        }
        public void Prepare()
        {
            for (int x1 = 1; x1 <= boardSizeX; x1++) for (int y1 = 1; y1 <= boardSizeY; y1++)
                {
                    if (grid[x1, y1].turtle && grid[x1, y1].turtleDirection == Direction.None)
                    {
                        for (int x2 = 1; x2 <= boardSizeX; x2++) for (int y2 = 1; y2 <= boardSizeY; y2++)
                            {
                                if (grid[x2, y2].turtle && grid[x2, y2].color == grid[x1, y1].color && !(x2 == x1 && y2 == y1))
                                {
                                    int distanceX = x2 - x1;
                                    int distanceY = y2 - y1;

                                    if (Math.Abs(distanceX) > Math.Abs(distanceY))
                                    {
                                        if (distanceX > 0)
                                            grid[x1, y1].turtleDirection = Direction.Right;
                                        else
                                            grid[x1, y1].turtleDirection = Direction.Left;                                        
                                    }
                                    else
                                    {
                                        if (distanceY > 0)
                                            grid[x1, y1].turtleDirection = Direction.Down;
                                        else
                                            grid[x1, y1].turtleDirection = Direction.Up;
                                    }
                                }
                            }
                    }
                }
        }

        public BoardStatus Solve()
        {
            int minPlayableFields = 4;
            int turtleX = 0;
            int turtleY = 0;
            int playableFieldsAround;

            for (int x = 1; x <= boardSizeX; x++) for (int y = 1; y <= boardSizeY; y++)
                {
                    if (grid[x, y].turtle)
                    {
                        playableFieldsAround = PlayableFieldsAround(x, y, grid[x, y].color);
                        if (playableFieldsAround < minPlayableFields)
                        {
                            turtleX = x;
                            turtleY = y;

                            if (playableFieldsAround == 1) goto Next; else minPlayableFields = playableFieldsAround;
                        }
                    }                        
                }

            Next:

            int newTurtleX;
            int newTurtleY;
            Direction linkDirection = Direction.None;

            for (int j = 1; j <= 2; j++)
            {
                for (int i = 1; i <= 4; i++)
                {
                    newTurtleX = turtleX;
                    newTurtleY = turtleY;

                    if (i == 1) { newTurtleX--; linkDirection = Direction.Left; }
                    if (i == 2) { newTurtleX++; linkDirection = Direction.Right; }
                    if (i == 3) { newTurtleY--; linkDirection = Direction.Up; }
                    if (i == 4) { newTurtleY++; linkDirection = Direction.Down; }

                    if (j == 1 ^ grid[turtleX, turtleY].turtleDirection == linkDirection)
                    {
                        if (newTurtleX > 0 && newTurtleX <= boardSizeX && newTurtleY > 0 && newTurtleY <= boardSizeY)
                        {
                            if (grid[newTurtleX, newTurtleY].color.IsEmpty)
                            {
                                grid[newTurtleX, newTurtleY].color = grid[turtleX, turtleY].color;
                                grid[newTurtleX, newTurtleY].turtle = true;
                                grid[newTurtleX, newTurtleY].turtleDirection = grid[turtleX, turtleY].turtleDirection;
                                grid[turtleX, turtleY].turtle = false;                                
                                grid[turtleX, turtleY].linkDirection = linkDirection;
                                if (Solve() == BoardStatus.Solved) return BoardStatus.Solved;
                                grid[newTurtleX, newTurtleY].color = Color.Empty;
                                grid[newTurtleX, newTurtleY].turtle = false;
                                grid[turtleX, turtleY].turtle = true;
                                grid[turtleX, turtleY].linkDirection = Direction.None;
                            }
                            else
                            {
                                if (grid[newTurtleX, newTurtleY].turtle && grid[newTurtleX, newTurtleY].color == grid[turtleX, turtleY].color)
                                {
                                    grid[newTurtleX, newTurtleY].turtle = false;
                                    grid[turtleX, turtleY].turtle = false;
                                    grid[turtleX, turtleY].linkDirection = linkDirection;
                                    BoardStatus status = GetBoardStatus();
                                    if (status == BoardStatus.Solved) return BoardStatus.Solved;
                                    if (status == BoardStatus.Regular)
                                    {
                                        if (Solve() == BoardStatus.Solved) return BoardStatus.Solved;
                                    }
                                    grid[newTurtleX, newTurtleY].turtle = true;
                                    grid[turtleX, turtleY].turtle = true;
                                    grid[turtleX, turtleY].linkDirection = Direction.None;
                                }
                            }
                        }
                    }
                }
            }

            return BoardStatus.Failed;
        }
    }
}