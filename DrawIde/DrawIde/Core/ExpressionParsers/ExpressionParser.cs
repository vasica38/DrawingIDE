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
        }

        public bool MatchesExpression(string expression)
        {
            return true;
        }

        public IDrawable Parse(string expression)
        {
            foreach (var expressionParser in this.expressionParsers)
            {
                if (expressionParser.MatchesExpression(expression))
                {
                    return expressionParser.Parse(expression);
                }
            }

            return null;
        }
    }
}
