using System.Drawing;
using System.Windows.Forms;

namespace DrawIde.Core
{
    interface IDrawingContext
    {
        int Heigth { get; set; }
        int Width { get; set; }
        string BackgroundColor { get; set; }
        string Color { get; set; }
        int FontSize { get; set; }
        string FontStyle { get; set; }
        int Stroke { get; set; }
        Graphics Graphics { get; }
        event MouseEventHandler MouseMove;

        void Reset();
    }
}
