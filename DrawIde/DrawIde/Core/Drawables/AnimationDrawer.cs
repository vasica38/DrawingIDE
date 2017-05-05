using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawIde.Core.Drawables
{
    class AnimationDrawer : IDrawable
    {
        public void Draw(IDrawingContext context)
        {

            var graphics = context.Graphics;
            Rectangle rect = new Rectangle(0, 0, 100, 100);
            Rectangle toDelete = new Rectangle(0, 0, 100, 100);
            var pen = new Pen(Color.FromName(context.Color), context.Stroke);
            var penToDelete = new Pen(Color.White, context.Stroke);
            graphics.DrawRectangle(pen, rect);

            int xRandomPrev = 0;
            int yRandomPrev = 0;

            for (int i = 0; i < 10; ++i)
            {
                Random r = new Random();
                int xRandom = r.Next(0, context.Width);
                int yRandom = r.Next(0, context.Heigth);

                rect.Location = new Point(xRandom, yRandom);
                graphics.DrawRectangle(pen, rect);

                toDelete.Location = new Point(xRandomPrev, yRandomPrev);

                xRandomPrev = xRandom;
                yRandomPrev = yRandom;

                System.Threading.Thread.Sleep(600);

                graphics.DrawRectangle(penToDelete, toDelete);
            }
        }
    }
}
