﻿using DrawIde.Core;
using DrawIde.Core.Drawables;
using DrawIde.Core.ExpressionParsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawIde
{
    public partial class MainForm : Form
    {
        private readonly DrawingForm drawingForm;
        private readonly IExpressionParser expressionParser;
        private readonly IDrawingContext drawingContext;
        private readonly MouseMoveDrawer mouserMoveDrawer;

        public MainForm()
        {
            InitializeComponent();
            this.drawingForm = new DrawingForm();
            this.expressionParser = new ExpressionParser();
            this.drawingContext = new DrawingContext(this.drawingForm);
            this.mouserMoveDrawer = new MouseMoveDrawer();
            Init();
        }

        private void Init()
        {
            drawingForm.Show();
            this.mouserMoveDrawer.Draw(this.drawingContext);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, textEditor.Text);
            }
        }

        private void btnOpenFromFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    textEditor.Text = File.ReadAllText(openFileDialog.FileName);
                }
            }
        }

        private void btnExportDrawing_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "bmp files (*.bmp)|*.bmp|png files (*.png)|*.png";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var bitmap = this.drawingForm.Export();
                var imageFormat = saveFileDialog.FileName.EndsWith("bmp", StringComparison.OrdinalIgnoreCase) ? ImageFormat.Bmp : ImageFormat.Png;
                bitmap.Save(saveFileDialog.FileName, imageFormat);
            }
        }

        private void textEditor_TextChanged(object sender, EventArgs e)
        {
            this.drawingContext.Reset();
            statusTextBox.Text = string.Empty;
            var expressions = textEditor.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var index = 0;
            while (index < expressions.Length)
            {
                var drawable = this.expressionParser.Parse(expressions, ref index);
                if (drawable != null)
                {
                    try
                    {
                        drawable.Draw(this.drawingContext);
                    }
                    catch (Exception exception)
                    {
                        if (index >= expressions.Length)
                        {
                            statusTextBox.Text = string.Format("Invalid expression \nException: '{0}'", exception.Message);
                        }
                        else
                        {
                            statusTextBox.Text = string.Format("Invalid expression '{0}'\nException: '{1}'", expressions[index], exception.Message);
                        }

                        break;
                    }
                }
                else
                {
                    statusTextBox.Text = string.Format("Invalid expression '{0}'", expressions[index]);
                    break;
                }
            }
        }
    }
}
