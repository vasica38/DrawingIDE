using System;
using System.Collections.Generic;

namespace DrawIde.Core.ExpressionParsers
{
    class ExpressionParser : IExpressionParser
    {
        private readonly List<IExpressionParser> expressionParsers;

        public ExpressionParser()
        {
            this.expressionParsers = new List<IExpressionParser>();
            this.expressionParsers.Add(new GraphicsSizeParser());
            this.expressionParsers.Add(new BackgroundColorParser());
            this.expressionParsers.Add(new ColorSetterParser());
            this.expressionParsers.Add(new CircleDrawerParser());
            this.expressionParsers.Add(new EllipseDrawerParser());
            this.expressionParsers.Add(new FontStyleParser());
            this.expressionParsers.Add(new ForExpressionParser());
            this.expressionParsers.Add(new ImageParser());
            this.expressionParsers.Add(new FunctionDrawerParser());  
            this.expressionParsers.Add(new LineDrawerParser());
            this.expressionParsers.Add(new RectangleDrawerParser());
            this.expressionParsers.Add(new StrokeSizeParser());
            this.expressionParsers.Add(new TextDrawerParser());
            this.expressionParsers.Add(new TextSizeSetterParser());
        }

        public bool MatchesExpression(string expression)
        {
            return true;
        }

        public IDrawable Parse(string[] expressions, ref int index)
        {
            foreach (var expressionParser in this.expressionParsers)
            {
                if (expressionParser.MatchesExpression(expressions[index]))
                {
                    return expressionParser.Parse(expressions, ref index);
                }
            }

            return null;
        }
    }
}
