using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawIde
{
    public partial class DrawingForm : Form
    {
        private readonly Graphics graphics;

        public Graphics Graphics
        {
            get
            {
                return this.graphics;
            }
        }

        public Bitmap Export()
        {
            this.BringToFront();
            var size = new Size(this.Width - 20 > 0 ? this.Width - 20 : 1, this.Height - 60 > 0 ? this.Height - 60 : 1);
            var memoryImage = new Bitmap(size.Width, size.Height, this.Graphics);
            var memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X + 10, this.Location.Y + 30, 0, 0, size);
            return memoryImage;
        }

        public DrawingForm()
        {
            InitializeComponent();
            this.graphics = this.CreateGraphics();
        }
    }
}
