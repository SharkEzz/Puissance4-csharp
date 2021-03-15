using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;

namespace p4.Game
{
    public class Grid
    {
        public readonly uint cX = 7;
        public readonly uint cY = 6;
        private List<List<Box>> board;

        public List<List<Box>> Board
        {
            get => this.board;
            set => this.board = value;
        }

        public Grid()
        {
            this.board = new List<List<Box>>();

            for(uint y = 0; y < this.cY; y++)
            {
                this.board.Add(new List<Box>());
                for(uint x = 0; x < this.cX; x++)
                {
                    this.board[(int)y].Add(new Box(x, y, x * (Box.radius * 2), y * (Box.radius * 2)));
                }
            }
        }

        public bool CheckWinner(uint startX, uint startY)
        {
            for(int tempY = -1; tempY <= 1; tempY++)
            {
                for(int tempX = -1; tempX <= 1; tempX++)
                {
                    if(tempX == 0 && tempY == 0)
                        continue;
                    
                    if(this.CheckIFThereIsAWinnerInThePuissance4Game(new Vector2i((int)startX, (int)startY), new Vector2i(tempX, tempY)))
                        return true;
                }
            }

            return false;
        }

        public Box GetBottomColumnBox(uint x, uint y)
        {
            uint newY = y;

            for(uint i = newY ; newY + 1 < this.cY && this.GetBoxAtPos(x, newY + 1).IsEmpty; i++)
            {
                newY = i;
            }

            return this.GetBoxAtPos(x, newY);
        }

        public Box GetBoxAtPos(uint x, uint y)
        {
            return this.board[(int)y][(int)x];
        }

        private bool CheckIFThereIsAWinnerInThePuissance4Game(Vector2i start, Vector2i stop)
        {
            Color currentColor = this.GetBoxAtPos((uint)start.X, (uint)start.Y).Shape.FillColor;

            for(uint i = 0; i < 4; i++)
            {
                long x = start.X + stop.X * i;
                long y = start.Y + stop.Y * i;

                if(x < 0 || y < 0 || x >= this.cX || y >= this.cY)
                    return false;

                if(this.GetBoxAtPos((uint)(x), (uint)(y)).Shape.FillColor != currentColor)
                    return false;
            }

            return true;
        }
    }
}