using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawIde.Core.Drawables
{
    class FunctionDrawer : IDrawable
    {
        private string function;
        private string dFunction;
        private int pointer;
        private List<PointF> listP;
        public FunctionDrawer(string function)
        {
            this.pointer = 0;
            listP = new List<PointF>();
            this.function = function;
        }


        public void Draw(IDrawingContext context)
        {
            function = function.Replace("'", "");

            for (int i = 0; i < context.Width / 2; ++i)
            {
                pointer = 0;
                dFunction = function;
                string nr = (i).ToString();
                dFunction = function.Replace("x", nr);
                dFunction = dFunction.Replace("x", nr);
                double result = Evaluate();
                if (result > context.Heigth) break;
                result = result * -1;
                listP.Add(new PointF((float)(i + context.Heigth / 2), (float)(result) + context.Width / 2));
            }

            Graphics graphics = context.Graphics;
            var array = listP.ToArray();

            Pen pen = new Pen(System.Drawing.Color.FromName(context.Color), context.Stroke);
            graphics.DrawLines(pen, array);

            Pen penForAxis = new Pen(Color.Red, 3);
            penForAxis.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            graphics.DrawLine(penForAxis, 0, context.Width / 2, context.Heigth - 20, context.Width / 2);
            graphics.DrawLine(penForAxis, context.Heigth / 2, context.Width, context.Heigth / 2, +20);
        }
        private double Evaluate()
        {
            double value = check();
            return value;
        }

        private double Term()
        {
            double val = Factor();
            while (pointer < dFunction.Length && (dFunction[pointer] == '*' || dFunction[pointer] == '/' || dFunction[pointer] == '^'))
            {
                if (dFunction[pointer] == '*')
                {
                    ++pointer;
                    val *= Factor();
                }
                if (!(pointer < dFunction.Length))
                {
                    break;
                }
                if (dFunction[pointer] == '/')
                {
                    ++pointer;
                    val /= Factor();
                }
                if (!(pointer < dFunction.Length))
                {
                    break;
                }
                if (dFunction[pointer] == '^')
                {
                    ++pointer;
                    val = IntPow(val, Factor());
                }
                if (!(pointer < dFunction.Length))
                {
                    break;
                }
            }
            return val;
        }

        private int Factor()
        {
            int val = 0;
            while (pointer < dFunction.Length && dFunction[pointer] >= '0' && dFunction[pointer] <= '9')
            {
                val = val * 10 + dFunction[pointer++] - '0';
            }
            return val;
        }

        private double check()
        {
            double val = Term();
            while (pointer < dFunction.Length && (dFunction[pointer] == '+' || dFunction[pointer] == '-'))
            {
                if (dFunction[pointer] == '+')
                {
                    ++pointer;
                    val += Term();
                }
                else
                {
                    ++pointer;
                    val -= Term();
                }
            }
            return val;
        }

        private double IntPow(double x, int pow)
        {
            double y = 1;
            while (pow > 1)
            {
                if ((pow & 1) != 0)
                {
                    y = (y * x);
                    x = (x * x);
                    pow = (pow - 1) / 2;
                }
                else
                {
                    x = (x * x);
                    pow = pow / 2;
                }
            }
            return x * y;
        }
    }
}
