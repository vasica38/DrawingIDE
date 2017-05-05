using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawIde.Core.ExpressionParsers
{
    class ForInstructionParser : IExpressionParser
    {
        private static readonly string MATCH = @"FOR (?<index>(i[ ]*=[0-9]+))[ ]+(TO)[ ]+(?<limit>([0-9]+))[ ]+DO[ ]*$";

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

            var index = Convert.ToInt32(match.Groups["index"].Value);
            var limit = Convert.ToInt32(match.Groups["limit"].Value);
            //??
            return null;
        }
    }
}
