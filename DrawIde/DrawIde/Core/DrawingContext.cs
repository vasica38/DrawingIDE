using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawIde.Core
{
    class DrawingContext : IDrawingContext
    {
        private readonly DrawingForm drawingForm;
        private string color;
        private int fontSize;
        private int stroke;

        public int Heigth
        {
            get
            {
                return this.drawingForm.Height;
            }
            set
            {
                this.drawingForm.Height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.drawingForm.Width;
            }
            set
            {
                this.drawingForm.Width = value;
            }
        }

        public string BackgroundColor
        {
            get
            {
                return this.drawingForm.BackColor.Name;
            }
            set
            {
                this.drawingForm.BackColor = System.Drawing.Color.FromName(value);
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public int FontSize
        {
            get
            {
                return this.fontSize;
            }
            set
            {
                this.fontSize = value;
            }
        }

        public int Stroke
        {
            get
            {
                return this.stroke;
            }
            set
            {
                this.stroke = value;
            }
        }

        public Graphics Graphics
        {
            get
            {
                return this.drawingForm.Graphics;
            }
        }

        public DrawingContext(DrawingForm drawingForm)
        {
            this.drawingForm = drawingForm;
        }
    }
}
