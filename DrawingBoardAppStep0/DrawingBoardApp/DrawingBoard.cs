using System.Drawing;
using System;
using System.Threading;

namespace DrawingBoardApp {
    class DrawingBoard {
        private int tick;
        private int scrWidth, scrHeight;
        private bool right, down = true;

        public DrawingBoard(MainForm mainForm) {
            scrWidth = mainForm.ClientSize.Width;
            scrHeight = mainForm.ClientSize.Height;
            tick = 0;
        }

        public void Draw(Graphics g) {
            // Clear the screen - for this frame
            g.Clear(Color.FromArgb(228, 228, 228));

            if (tick % (scrWidth + 20) >= scrWidth - 1) right = false;
            if (tick % (scrWidth) <= 20) right = true; 
            if (tick % (scrHeight + 20)>= scrHeight - 1) down = false;
            if (tick % (scrHeight ) <= 20) down = true;

            g.DrawEllipse(Pens.Red, (right)? tick % scrWidth : scrWidth - (tick % scrWidth), (down) ? tick % scrHeight : scrHeight - (tick % scrHeight), 20, 20);
        }

        public void Tick() {
            tick += 10;

            Console.WriteLine($"right: {right} down: {down}");
            Console.WriteLine("Tick {0}", tick);
        }

        private bool Flip(bool side) {
            side = !side;
            return side;
        }
    }
}