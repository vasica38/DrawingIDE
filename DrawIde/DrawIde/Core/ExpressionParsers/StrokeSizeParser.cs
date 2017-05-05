using DrawIde.Core.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawIde.Core.ExpressionParsers
{
    class StrokeSizeParser : IExpressionParser
    {
        private static readonly string MATCH = @"^STROKE (?<stroke>[0-9]+)$";

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

            var strokeSize = Convert.ToInt32(match.Groups["stroke"].Value);

            return new StrokeSizeDrawer(strokeSize);
        }

        public IDrawable Parse(string[] expressions, ref int index)
        {
            index++;
            return Parse(expressions[index - 1]);
        }
    }
}
