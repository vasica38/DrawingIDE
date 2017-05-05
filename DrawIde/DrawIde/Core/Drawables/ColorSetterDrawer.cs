using System;

namespace DrawIde.Core.Drawables
{
    class ColorSetterDrawer : IDrawable
    {
        private readonly string color;

        public ColorSetterDrawer(string color)
        {
            this.color = color;
        }

        public void Draw(IDrawingContext context)
        {
            context.Color = this.color;
        }
    }
}
