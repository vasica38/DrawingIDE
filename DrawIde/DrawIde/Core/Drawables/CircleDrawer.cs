using System;
using System.Drawing;

namespace DrawIde.Core.Drawables
{
    class CircleDrawer : IDrawable
    {
        private readonly int x;
        private readonly int y;
        private readonly int radius;

        public CircleDrawer(int x, int y, int radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public void Draw(IDrawingContext context)
        {
            var pen = new Pen(Color.FromName(context.Color), context.Stroke);
            context.Graphics.DrawEllipse(pen, x - radius, y - radius, radius + radius, radius + radius);
        }
    }
}
