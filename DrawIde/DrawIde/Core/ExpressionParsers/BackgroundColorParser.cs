﻿using DrawIde.Core.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawIde.Core.ExpressionParsers
{
    class BackgroundColorParser : IExpressionParser
    {
        private static readonly string MATCH = @"^BACKGROUND (?<color>((white)|(red)|(black)|(green)|(blue)|(grey)|(pink)))$";

        public bool MatchesExpression(string expression)
        {
            return false;
            //return Regex.Match(expression, MATCH, RegexOptions.IgnoreCase).Success;
        }

        public IDrawable Parse(string expression)
        {
            var match = Regex.Match(expression, MATCH, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return null;
            }

            var color = match.Groups["color"].Value;
            return new BackgroundColorDrawer(color);
        }

        public IDrawable Parse(string[] expressions, ref int index)
        {
            index++;
            return Parse(expressions[index - 1]);
        }
    }
}
