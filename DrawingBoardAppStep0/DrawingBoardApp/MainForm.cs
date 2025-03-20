using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DrawingBoardApp
{
    public partial class MainForm : Form
    {
        private readonly DrawingBoard drawingBoard;
        public MainForm()
        {
            InitializeComponent();
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true);
            this.UpdateStyles();
            drawingBoard = new(this);
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public void Draw(object sender, PaintEventArgs e)
        {
            // called by Paint
            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            drawingBoard.Draw(e.Graphics);
        }

        public void Refresh(object sender, EventArgs e)
        {
            // called by Timer Tick
            drawingBoard.Tick();
            this.Refresh();
        }
    }
}
