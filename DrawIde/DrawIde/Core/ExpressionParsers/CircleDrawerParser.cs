using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawIde.Core.ExpressionParsers
{
    class CircleDrawerParser : IExpressionParser
    {
        private static readonly string MATCH = @"^CIRCLE (?<x>[0-9]+)[,][ ]+(?<y>[0-9]+)[,][ ]+(?<radius>[0-9]+)[ ]?$";

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
            //return new GraphicsRectangleDrawer(x1,y1,x2,y2);
            return null;
        }
    }
}
