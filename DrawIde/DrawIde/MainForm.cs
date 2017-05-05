using DrawIde.Core;
using DrawIde.Core.ExpressionParsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawIde
{
    public partial class MainForm : Form
    {
        private readonly DrawingForm drawingForm;
        private readonly IExpressionParser expressionParser;
        private readonly IDrawingContext drawingContext;

        public MainForm()
        {
            InitializeComponent();
            this.drawingForm = new DrawingForm();
            this.expressionParser = new ExpressionParser();
            this.drawingContext = new DrawingContext(this.drawingForm);
            Init();
        }

        private void Init()
        {
            drawingForm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void textEditor_TextChanged(object sender, EventArgs e)
        {
            this.drawingForm.Graphics.Clear(Color.White);
            statusTextBox.Text = string.Empty;
            var expressions = textEditor.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var expression in expressions)
            {
                var drawable = this.expressionParser.Parse(expression);
                if (drawable != null)
                {
                    drawable.Draw(this.drawingContext);
                }
                else
                {
                    statusTextBox.Text = string.Format("Invalid expression '{0}'", expression);
                    break;
                }
            }
        }
    }
}
