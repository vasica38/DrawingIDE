using DrawIde.Core.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawIde.Core.ExpressionParsers
{
    class EllipseDrawerParser : IExpressionParser
    {
        private static readonly string MATCH = @"^ELLIPSE (?<x1>[0-9]+)[,][ ]*(?<y1>[0-9]+)[,][ ]*(?<x2>[0-9]+)[,][ ]*(?<y2>[0-9]+)[,][ ]*(?<fill>((true)|(false)))$";

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

            var x1 = Convert.ToInt32(match.Groups["x1"].Value);
            var y1 = Convert.ToInt32(match.Groups["y1"].Value);
            var x2 = Convert.ToInt32(match.Groups["x2"].Value);
            var y2 = Convert.ToInt32(match.Groups["y2"].Value);
            var fill = Convert.ToBoolean(match.Groups["fill"].Value);

            return new EllipseDrawer(x1, y1, x2, y2, fill);
        }
    }
}
