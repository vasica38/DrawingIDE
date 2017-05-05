using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawIde.Core.Drawables
{
    class TextDrawer : IDrawable
    {
        private readonly string text;
        private readonly int x;
        private readonly int y;

        public TextDrawer(string text, int x, int y)
        {
            this.text = text;
            this.x = x;
            this.y = y;
        }

        public void Draw(IDrawingContext context)
        {
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromName(context.Color));
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            System.Drawing.Font drawFont = new System.Drawing.Font(context.FontStyle, context.FontSize);

            var graphics = context.Graphics;
            graphics.DrawString(text, drawFont, drawBrush, x, y, drawFormat);
        }
    }
}
