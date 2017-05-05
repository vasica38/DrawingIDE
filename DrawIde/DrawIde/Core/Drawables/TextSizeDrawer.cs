using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawIde.Core.Drawables
{
    class TextSizeDrawer : IDrawable
    {
        private readonly int size;
        public TextSizeDrawer(int size)
        {
            this.size = size;
        }

        public void Draw(IDrawingContext context)
        {
            context.FontSize = size;
        }
    }
}
