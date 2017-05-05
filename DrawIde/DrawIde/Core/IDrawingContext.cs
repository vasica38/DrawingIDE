using System.Drawing;

namespace DrawIde.Core
{
    interface IDrawingContext
    {
        int Heigth { get; set; }
        int Width { get; set; }
        string BackgroundColor { get; set; }
        string Color { get; set; }
        int FontSize { get; set; }
        int Stroke { get; set; }
        Graphics Graphics { get; }
    }
}
