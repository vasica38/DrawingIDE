using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawIde.Core.Drawables
{
    class TextFontDrawer : IDrawable
    {
        private readonly string style;

        public TextFontDrawer(string style)
        {
            this.style = style;
        }

        public void Draw(IDrawingContext context)
        {
            context.FontStyle = style;
        }
    }
}
