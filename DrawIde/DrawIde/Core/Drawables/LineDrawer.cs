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
        int x, y;
        int x1, y1;

        public LineDrawer(int x, int y, int x1, int y1)
        {
            this.x = x;
            this.y = y;
            this.x1 = x1;
            this.y1 = y1;
        }

        public void Draw(IDrawingContext context)
        {
            var graphics = context.Graphics;
            Pen pen = new Pen(System.Drawing.Color.FromName(context.Color));
            graphics.DrawLine(pen,x, y, x1, y1);
        }
    }
}
