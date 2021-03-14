using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

using p4.Game;

namespace p4
{
    public class GameLoop
    {
        private bool shouldRender = true;
        private Grid grid;
        private RenderWindow window;
        private uint turn = 0;

        public GameLoop()
        {
            this.window = new RenderWindow(new VideoMode(800, 800), "P4");
            this.window.SetVerticalSyncEnabled(true);
            this.window.SetFramerateLimit(60);
            this.window.MouseButtonPressed += this.HandleClick;
            this.window.KeyPressed += this.HandleKeyPress;
            this.window.Closed += (object sender, EventArgs e) => ((RenderWindow)sender).Close();
            this.grid = new Grid();
        }

        public void Loop()
        {
            while(this.window.IsOpen)
            {
                this.window.DispatchEvents();

                if(this.shouldRender)
                {
                    this.window.Clear();

                    for(uint y = 0; y < this.grid.cY; y++)
                    {
                        for(uint x = 0; x < this.grid.cX; x++)
                        {
                            this.window.Draw(this.grid.GetBoxAtPos(x, y).Shape);
                        }
                    }

                    this.window.Display();
                    this.shouldRender = false;
                }
            }
        }

        private void HandleClick(object sender, MouseButtonEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;

            if(e.Button == Mouse.Button.Left)
            {
                Box b = this.GetBoxAtPos((uint)e.X, (uint)e.Y);
                if(b.IsEmpty)
                {
                    b = this.grid.GetBottomColumnBox(b.iX, b.iY);
                    b.Fill(new Pawn(this.GetColorByTurn()));
                    this.shouldRender = true;
                    this.turn++;
                }
                else
                {
                    Console.WriteLine("Box at x:{0} y:{1} not empty", b.iX, b.iY);
                }
            }
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;

            if(e.Code == Keyboard.Key.Escape)
                window.Close();
        }

        private Box GetBoxAtPos(uint pX, uint pY)
        {
            uint posX = pX / (Box.radius * 2);
            uint posY = pY / (Box.radius * 2);
            return this.grid.GetBoxAtPos(posX, posY);
        }

        private Pawn.AvailablePawnColor GetColorByTurn()
        {
            if(this.turn % 2 == 0)
            {
                return Pawn.AvailablePawnColor.Red;
            }
            else
            {
                return Pawn.AvailablePawnColor.Yellow;
            }
        }
    }
}