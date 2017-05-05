using System;

namespace DrawIde.Core.Drawables
{
    class ForExpressionDrawer : IDrawable
    {
        private readonly string variable;
        private readonly int startValue;
        private readonly int endValue;
        private readonly int stepValue;
        private readonly string body;

        public ForExpressionDrawer(string variable, int startValue, int endValue, int stepValue, string body)
        {
            this.variable = variable;
            this.startValue = startValue;
            this.endValue = endValue;
            this.stepValue = stepValue;
            this.body = body;
        }

        public void Draw(IDrawingContext context)
        {
            
        }
    }
}
