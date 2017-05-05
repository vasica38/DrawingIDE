using DrawIde.Core.Drawables;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DrawIde.Core.ExpressionParsers
{
    class ForExpressionParser : IExpressionParser
    {
        private static readonly string MATCH_HEADER = @"^FOR (?<variable>\w+)=(?<startValue>\d+) TO (?<endValue>\d+) STEP (?<stepValue>\d+) DO$";
        private static readonly string MATCH_FULL = @"^FOR (?<variable>\w+)=(?<startValue>\d+) TO (?<endValue>\d+) STEP (?<stepValue>\d+) DO[\s]*\{[\s]*(?<body>[\s\S]+)[\s]*\}";

        public bool MatchesExpression(string expression)
        {
            return Regex.Match(expression, MATCH_HEADER, RegexOptions.IgnoreCase).Success;
        }

        public IDrawable Parse(string[] expressions, ref int index)
        {
            var code = string.Join("\n", expressions.Skip(index));
            var match = Regex.Match(code, MATCH_FULL, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return null;
            }

            var variable = match.Groups["variable"].Value;
            var startValue = Convert.ToInt32(match.Groups["startValue"].Value);
            var endValue = Convert.ToInt32(match.Groups["endValue"].Value);
            var stepValue = Convert.ToInt32(match.Groups["stepValue"].Value);
            var body = match.Groups["body"].Value;
            var lines = match.Value.Count(c => c == '\n');
            index += lines + 1;
            return new ForExpressionDrawer(variable, startValue, endValue, stepValue, body);
        }
    }
}
