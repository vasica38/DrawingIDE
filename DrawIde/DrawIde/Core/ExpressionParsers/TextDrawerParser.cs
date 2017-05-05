using DrawIde.Core.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawIde.Core.ExpressionParsers
{
    class TextDrawerParser : IExpressionParser
    {
        private static readonly string MATCH = @"^TEXT (?<text>['].+['])[,]?[ ]*(?<x>[0-9]+)[,][ ]*(?<y>[0-9]+)$";

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

            var text = (match.Groups["text"].Value);
            var x = Convert.ToInt32(match.Groups["x"].Value);
            var y = Convert.ToInt32(match.Groups["y"].Value);

            return new TextDrawer(text, x, y);
        }
    }
}
