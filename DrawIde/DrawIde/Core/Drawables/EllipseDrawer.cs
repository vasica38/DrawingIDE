using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawIde.Core.Drawables
{
    class EllipseDrawer : IDrawable
    {
        private readonly int x1;
        private readonly int y1;
        private readonly int x2;
        private readonly int y2;
        private readonly bool fill;

        public EllipseDrawer(int x1, int y1, int x2, int y2, bool fill)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.fill = fill;
        }

        public void Draw(IDrawingContext context)
        {
            if (this.fill)
            {
                var brush = new SolidBrush(Color.FromName(context.Color));
                context.Graphics.FillEllipse(brush, x1, y1, x2, y2);
            }
            else
            {
                var pen = new Pen(Color.FromName(context.Color), context.Stroke);
                context.Graphics.DrawEllipse(pen, x1, y1, x2, y2);
            }
        }
    }
}
