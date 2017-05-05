using System;
using System.Drawing;

namespace DrawIde.Core
{
    class DrawingContext : IDrawingContext
    {
        public int Heigth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BackgroundColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int FontSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Stroke { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Graphics Graphics => throw new NotImplementedException();
    }
}
