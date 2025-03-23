using System.Drawing;
using System;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace DrawingBoardApp {
    class DrawingBoard {
        private int tick;
        private int scrWidth, scrHeight;
        private int tickRate = 10;
        private Circle circle;

        public DrawingBoard(MainForm mainForm) {
            scrWidth = mainForm.ClientSize.Width;
            scrHeight = mainForm.ClientSize.Height;
            tick = 0;

            circle = new Circle(5, 5);
        }

        public void Draw(Graphics g) {
            // Clear the screen - for this frame
            g.Clear(Color.FromArgb(228, 228, 228));

            circle.CalcPos(tick, tickRate, scrWidth, scrHeight);
            circle.Draw(g);
        }

        // increase tick by tickrate
        public void Tick() {
            tick += tickRate;
            Console.WriteLine($"Tick {tick}");
        }
    }

    class Circle {
        private int width, height, absWidth, absHeight, newPosX, newPosY;
        private bool right, down = true;

        public Circle(int width, int height) {
            this.width = width;
            this.height = height;
        }

        public void CalcPos(int tick, int tickRate, int scrWidth, int scrHeight) {

            // counts up from 0 to max screen parameters along side tick
            absWidth = tick % (scrWidth + tickRate);
            absHeight = tick % (scrHeight + tickRate);

            // direction switch once exceeded border
            if (absWidth > scrWidth - 1 || (scrWidth - absWidth) < 1) right = !right;
            if (absHeight > scrHeight - 1 || (scrHeight - absHeight) < 1) down = !down;
            newPosX = right ? absWidth : (scrWidth - absWidth);
            newPosY = down ? absHeight : (scrHeight - absHeight);
        }

        public void Draw(Graphics g) {

            // new position based on direction headed and tickrate based incrementing
            g.DrawEllipse(Pens.Red, newPosX, newPosY, width, height);
        }
    }
}