using System.Drawing;
using System;

namespace DrawingBoardApp
{
    class DrawingBoard
    {
        private int tick;
		private int scrWidth, scrHeight;

        public DrawingBoard(MainForm mainForm)
        {
            scrWidth = mainForm.ClientSize.Width;
            scrHeight = mainForm.ClientSize.Height;
			tick = 0;
        }

        public void Draw(Graphics g)
        {
            // Clear the screen - for this frame
            g.Clear(Color.FromArgb(228, 228, 228));

            g.DrawEllipse(Pens.Red, 400, 200, 20, 20);
        }

        public void Tick()
        {
            tick += 1;
            Console.WriteLine("Tick {0}", tick);
        }
    }
}
