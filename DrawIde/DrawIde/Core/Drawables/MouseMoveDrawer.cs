using System;
using System.Drawing;

namespace DrawIde.Core.Drawables
{
    class MouseMoveDrawer : IDrawable
    {
        private Point lastPosition = Point.Empty;
        private IDrawingContext context;

        public void Draw(IDrawingContext context)
        {
            this.context = context;
            context.MouseMove += Context_MouseMove;
        }

        private void Context_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.None)
            {
                lastPosition = Point.Empty;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (lastPosition == Point.Empty)
                {
                    lastPosition = e.Location;
                }
                else
                {
                    var lineDrawer = new LineDrawer(lastPosition.X, lastPosition.Y, e.X, e.Y);
                    lineDrawer.Draw(this.context);
                    lastPosition.X = e.X;
                    lastPosition.Y = e.Y;
                }
            }
        }
    }
}
