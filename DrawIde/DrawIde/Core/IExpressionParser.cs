namespace DrawIde.Core
{
    interface IExpressionParser
    {
        IDrawable Parse(string expression);
        bool MatchesExpression(string expression);
    }
}
