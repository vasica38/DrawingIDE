using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawIde.Core.ExpressionParsers
{
    class ColorSetterParser : IExpressionParser
    {
        private static readonly string MATCH = @"^COLOR (?<color>((red)|(black)|(green)|(blue)|(grey)|(pink)))$";


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

            var color = match.Groups["color"].Value;
            //return new GraphicsColorSetter(color);
            return null;
        }
    }
}
