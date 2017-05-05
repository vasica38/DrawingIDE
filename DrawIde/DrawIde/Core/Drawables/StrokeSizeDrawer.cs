using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawIde.Core.Drawables
{
    class StrokeSizeDrawer : IDrawable
    {
        private readonly int strokeSize;

        public StrokeSizeDrawer(int strokeSize)
        {
            this.strokeSize = strokeSize;
        }

        public void Draw(IDrawingContext context)
        {
            context.Stroke = strokeSize;
        }
    }
}
