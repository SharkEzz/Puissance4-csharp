using System;
using System.Collections.Generic;

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
    }
}