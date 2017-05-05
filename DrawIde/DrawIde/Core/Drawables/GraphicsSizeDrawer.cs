using System;

namespace DrawIde.Core.Drawables
{
    class GraphicsSizeDrawer : IDrawable
    {
        private readonly int height;
        private readonly int width;

        public GraphicsSizeDrawer(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public void Draw(IDrawingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
