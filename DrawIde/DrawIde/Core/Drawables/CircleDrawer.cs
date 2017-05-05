using System;
using System.Drawing;

namespace DrawIde.Core.Drawables
{
    class CircleDrawer : IDrawable
    {
        private readonly int x;
        private readonly int y;
        private readonly int radius;
        private readonly bool fill;

        public CircleDrawer(int x, int y, int radius, bool fill)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.fill = fill;
        }

        public void Draw(IDrawingContext context)
        {
            if (fill)
            {
                var brush = new SolidBrush(Color.FromName(context.Color));
                context.Graphics.FillEllipse(brush, x - radius, y - radius, radius + radius, radius + radius);
            }
            else
            {
                var pen = new Pen(Color.FromName(context.Color), context.Stroke);
                context.Graphics.DrawEllipse(pen, x - radius, y - radius, radius + radius, radius + radius);
            }
        }
    }
}
