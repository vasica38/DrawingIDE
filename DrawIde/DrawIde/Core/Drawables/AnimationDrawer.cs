using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace DrawIde.Core.Drawables
{
    class AnimationDrawer : IDrawable
    {
        public void Draw(IDrawingContext context)
        {
            var task = Task.Run(() =>
            {
                DoDraw(context);
            });
        }

        private void DoDraw(IDrawingContext context)
        {
            var graphics = context.Graphics;
            var brush = new SolidBrush(Color.FromName(context.Color));
            var brushToDelete = new SolidBrush(Color.FromName(context.BackgroundColor));
            var random = new Random(DateTime.Now.Millisecond);
            var radius = 20;
            int prevX = 20, prevY = 20;
            for (var i = 0; i < 10; i++)
            {
                int x = random.Next(0, context.Width);
                int y = random.Next(0, context.Heigth);
                context.Graphics.FillEllipse(brush, x - radius, y - radius, radius + radius, radius + radius);
                context.Graphics.FillEllipse(brushToDelete, prevX - radius, prevY - radius, radius + radius, radius + radius);
                prevX = x;
                prevY = y;
                Thread.Sleep(200);
            }
        }
    }
}
