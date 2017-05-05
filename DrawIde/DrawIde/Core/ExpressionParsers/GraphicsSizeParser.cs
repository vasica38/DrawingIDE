using DrawIde.Core.Drawables;
using System;
using System.Text.RegularExpressions;

namespace DrawIde.Core.ExpressionParsers
{
    class GraphicsSizeParser : IExpressionParser
    {
        private static readonly string MATCH = @"^DRAW (?<height>[0-9]+)[,][ ]*(?<width>[0-9]+)$";

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

            var height = Convert.ToInt32(match.Groups["height"].Value);
            var width = Convert.ToInt32(match.Groups["width"].Value);
            return new GraphicsSizeDrawer(height, width);
        }

        public IDrawable Parse(string[] expressions, ref int index)
        {
            index++;
            return Parse(expressions[index - 1]);
        }
    }
}
