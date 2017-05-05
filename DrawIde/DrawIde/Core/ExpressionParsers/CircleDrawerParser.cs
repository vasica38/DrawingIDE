using DrawIde.Core.Drawables;
using System;
using System.Text.RegularExpressions;

namespace DrawIde.Core.ExpressionParsers
{
    class CircleDrawerParser : IExpressionParser
    {
        private static readonly string MATCH = @"^CIRCLE (?<x>[0-9]+)[,][ ]*(?<y>[0-9]+)[,][ ]*(?<radius>[0-9]+)[,][ ]*(?<fill>((true)|(false)))$";

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

            var x = Convert.ToInt32(match.Groups["x"].Value);
            var y = Convert.ToInt32(match.Groups["y"].Value);
            var radius = Convert.ToInt32(match.Groups["radius"].Value);
            var fill = Convert.ToBoolean(match.Groups["fill"].Value);
            return new CircleDrawer(x, y, radius, fill);
        }

        public IDrawable Parse(string[] expressions, ref int index)
        {
            index++;
            return Parse(expressions[index - 1]);
        }
    }
}
