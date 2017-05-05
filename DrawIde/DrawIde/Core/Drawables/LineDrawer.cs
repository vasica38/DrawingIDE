using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawIde.Core.Drawables
{
    class LineDrawer : IDrawable
    {
        private readonly int x1, y1;
        private readonly int x2, y2;

        public LineDrawer(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public void Draw(IDrawingContext context)
        {
            var graphics = context.Graphics;
            var pen = new Pen(Color.FromName(context.Color), context.Stroke);
            graphics.DrawLine(pen, x1, y1, x2, y2);
        }
    }
}
