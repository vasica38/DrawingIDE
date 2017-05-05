using DrawIde.Core.Drawables;
using System.Text.RegularExpressions;

namespace DrawIde.Core.ExpressionParsers
{
    class AnimationDrawerParser : IExpressionParser
    {
        private static readonly string MATCH = @"^ANIMATE$";

        public bool MatchesExpression(string expression)
        {
            return Regex.Match(expression, MATCH, RegexOptions.IgnoreCase).Success;
        }

        public IDrawable Parse(string[] expressions, ref int index)
        {
            index++;
            return Parse(expressions[index - 1]);
        }

        public IDrawable Parse(string expression)
        {
            var match = Regex.Match(expression, MATCH, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return null;
            }

            return new AnimationDrawer();
        }
    }
}
