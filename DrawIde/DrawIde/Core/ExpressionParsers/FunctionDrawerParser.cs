using DrawIde.Core.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawIde.Core.ExpressionParsers
{
    class FunctionDrawerParser : IExpressionParser
    {
        private static readonly string MATCH = @"^FUNCTION (?<function>'[xX\-\+\*\/\(\)0123456789\^]+')$";

        public bool MatchesExpression(string expression)
        {
            return Regex.Match(expression, MATCH, RegexOptions.IgnoreCase).Success;
        }

        public IDrawable Parse(string expression)
        {
            var match = Regex.Match(expression, MATCH, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return null;
            }

            var function = match.Groups["function"].Value;

            return new FunctionDrawer(function);
        }

        public IDrawable Parse(string[] expressions, ref int index)
        {
            index++;
            return Parse(expressions[index - 1]);
        }
    }
}
