using DrawIde.Core.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawIde.Core.ExpressionParsers
{
    class TextSizeSetterParser : IExpressionParser
    {
        private static readonly string MATCH = @"^TEXT SIZE (?<textSize>[0-9]+)$";

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

            var textSize = Convert.ToInt32(match.Groups["textSize"].Value);

            return new TextSizeDrawer(textSize);
        }
    }
}
