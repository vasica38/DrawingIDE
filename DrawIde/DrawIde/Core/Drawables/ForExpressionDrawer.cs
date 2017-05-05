using DrawIde.Core.ExpressionParsers;
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
        private readonly IExpressionParser expressionParser;

        public ForExpressionDrawer(string variable, int startValue, int endValue, int stepValue, string body)
        {
            this.variable = variable;
            this.startValue = startValue;
            this.endValue = endValue;
            this.stepValue = stepValue;
            this.body = body;
            this.expressionParser = new ExpressionParser();
        }

        public void Draw(IDrawingContext context)
        {
            for (var index = this.startValue; index <= this.endValue; index += this.stepValue)
            {
                var runtimeBody = this.body.Replace(string.Format("@{0}", this.variable), index.ToString());
                var expressions = runtimeBody.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                var idx = 0;
                while (idx < expressions.Length)
                {
                    var drawable = this.expressionParser.Parse(expressions, ref idx);
                    if (drawable != null)
                    {
                        drawable.Draw(context);
                    }
                    else
                    {
                        throw new Exception(string.Format("Invalid expression '{0}'", expressions[idx]));
                    }
                }
            }
        }
    }
}
