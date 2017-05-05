using System;

namespace DrawIde.Core.ExpressionParsers
{
    class ExpressionParser : IExpressionParser
    {

        public bool MatchesExpression(string expression)
        {
            return true;
        }

        public IDrawable Parse(string expression)
        {
            throw new NotImplementedException();
        }
    }
}
