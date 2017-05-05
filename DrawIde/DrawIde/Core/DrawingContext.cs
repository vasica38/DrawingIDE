using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawIde.Core
{
    class DrawingContext : IDrawingContext
    {
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

        public string BackgroundColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int FontSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Stroke { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Graphics Graphics
        {
            get
            {
                return this.drawingForm.Graphics;
            }
        }

        private readonly DrawingForm drawingForm;

        public DrawingContext(DrawingForm drawingForm)
        {
            this.drawingForm = drawingForm;
        }
    }
}
