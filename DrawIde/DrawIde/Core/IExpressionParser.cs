namespace DrawIde.Core
{
    interface IExpressionParser
    {
        IDrawable Parse(string[] expressions, ref int index);
        bool MatchesExpression(string expression);
    }
}
