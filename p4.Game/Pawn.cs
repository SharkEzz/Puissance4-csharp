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

        public enum AvailablePawnColor {
            Red,
            Yellow
        }

        public Color GetPawnColor(AvailablePawnColor color)
        {
            switch(color)
            {
                case AvailablePawnColor.Red:
                    return Color.Red;
                case AvailablePawnColor.Yellow:
                    return Color.Yellow;
                default:
                    return Color.Black;
            }
        }

        public Pawn(AvailablePawnColor color)
        {
            this.color = this.GetPawnColor(color);
        }
    }
}