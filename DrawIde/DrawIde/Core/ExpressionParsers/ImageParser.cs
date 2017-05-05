using DrawIde.Core.Drawables;
using System;
using System.Text.RegularExpressions;

namespace DrawIde.Core.ExpressionParsers
{
    class ImageParser : IExpressionParser
    {
        private static readonly string MATCH = @"^IMAGE (?<x>\d+)[,][ ]*(?<y>\d+)[,][ ]*'(?<path>[\s\S]+)'$";

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
            var path = match.Groups["path"].Value;
            return new ImageDrawer(x, y, path);
        }
    }
}
