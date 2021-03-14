using SFML.Graphics;
using SFML.System;

namespace p4.Game
{
    public class Box
    {
        private bool isEmpty = true;
        public readonly uint posX;
        public readonly uint posY;
        public readonly uint iX;
        public readonly uint iY;
        private Pawn pawn;
        private CircleShape shape;
        public const uint radius = 50;

        public bool IsEmpty
        {
            get => this.isEmpty;
        }

        public CircleShape Shape
        {
            get => this.shape;
        }

        public Pawn Pawn
        {
            get => this.pawn;
            set => this.pawn = value;
        }

        public Box(uint iX, uint iY,uint posX, uint posY)
        {
            this.iX = iX;
            this.iY = iY;
            this.posX = posX;
            this.posY = posY;
            this.shape = new CircleShape(Box.radius)
            {
                OutlineColor = Color.Blue,
                Position = new Vector2f(posX, posY)
            };
        }

        public void Fill(Pawn pawn)
        {
            this.pawn = pawn;
            this.shape.FillColor = pawn.PawnColor;
            this.isEmpty = false;
        }
        
    }
}