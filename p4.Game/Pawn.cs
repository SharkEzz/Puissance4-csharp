using SFML.Graphics;

namespace p4.Game
{
    public class Pawn
    {
        private Color color;

        public Color PawnColor
        {
            get => this.color;
            set => this.color = value;
        }

        public Pawn(Color color)
        {
            this.color = color;
        }
    }
}