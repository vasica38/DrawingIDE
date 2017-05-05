using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawIde.Core.Drawables
{
    class BackgroundColorDrawer : IDrawable
    {
        private readonly string color;

        public BackgroundColorDrawer(string color)
        {
            this.color = color;
        }

        public void Draw(IDrawingContext context)
        {
            context.BackgroundColor = color;
        }
    }
}
