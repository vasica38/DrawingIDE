namespace DrawIde
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textEditor = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textEditor
            // 
            this.textEditor.Location = new System.Drawing.Point(15, 40);
            this.textEditor.Name = "textEditor";
            this.textEditor.Size = new System.Drawing.Size(750, 500);
            this.textEditor.TabIndex = 0;
            this.textEditor.Text = "";
            this.textEditor.TextChanged += new System.EventHandler(this.textEditor_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.statusTextBox.ForeColor = System.Drawing.Color.Red;
            this.statusTextBox.Location = new System.Drawing.Point(15, 547);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(750, 74);
            this.statusTextBox.TabIndex = 2;
            this.statusTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 624);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textEditor);
            this.Name = "MainForm";
            this.Text = "Draw IDE";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textEditor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox statusTextBox;
    }
}

