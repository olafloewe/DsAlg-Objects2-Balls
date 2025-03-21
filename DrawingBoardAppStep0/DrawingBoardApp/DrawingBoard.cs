using System.Drawing;
using System;
using System.Threading;

namespace DrawingBoardApp {
    class DrawingBoard {
        private int tick;
        private int scrWidth, scrHeight;

        private int absWidth, absHeight;
        private bool right, down = true;
        private int tickRate = 21;

        public DrawingBoard(MainForm mainForm) {
            scrWidth = mainForm.ClientSize.Width;
            scrHeight = mainForm.ClientSize.Height;
            tick = 0;
        }

        public void Draw(Graphics g) {
            // Clear the screen - for this frame
            g.Clear(Color.FromArgb(228, 228, 228));

            // counts up from 0 to max screen parameters along side tick
            absWidth = tick % (scrWidth + tickRate);
            absHeight = tick % (scrHeight + tickRate);

            // direction switch once exceeded border
            if (absWidth > scrWidth-1 || scrWidth - (absWidth) < 1) right = !right;
            if (absHeight > scrHeight-1 || scrHeight - (absHeight) < 1) down = !down;

            // new position based on direction headed and tickrate based incrementing
            g.DrawEllipse(Pens.Red, right? absWidth:(scrWidth - absWidth), down? absHeight:(scrHeight - absHeight), 20, 20);
        }

        public void Tick() {
            tick += tickRate;

            Console.WriteLine($"Tick {tick}");
        }

        private bool Flip(bool side) {
            side = !side;
            return side;
        }
    }
}