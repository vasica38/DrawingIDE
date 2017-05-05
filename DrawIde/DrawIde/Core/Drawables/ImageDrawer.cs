using System;
using System.Drawing;

namespace DrawIde.Core.Drawables
{
    class ImageDrawer : IDrawable
    {
        private readonly int x;
        private readonly int y;
        private readonly string path;

        public ImageDrawer(int x, int y, string path)
        {
            this.x = x;
            this.y = y;
            this.path = path;
        }

        public void Draw(IDrawingContext context)
        {
            var image = Image.FromFile(this.path);
            context.Graphics.DrawImage(image, this.x, this.y);
        }
    }
}
