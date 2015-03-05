namespace Seal2D.Win
{
    partial class Form1
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
            this.seal2DCanvas1 = new Seal2D.Control.Seal2DCanvas();
            this.SuspendLayout();
            // 
            // seal2DCanvas1
            // 
            this.seal2DCanvas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seal2DCanvas1.Location = new System.Drawing.Point(0, 0);
            this.seal2DCanvas1.Name = "seal2DCanvas1";
            this.seal2DCanvas1.Size = new System.Drawing.Size(513, 453);
            this.seal2DCanvas1.TabIndex = 0;
            this.seal2DCanvas1.Text = "seal2DCanvas1";
            this.seal2DCanvas1.Click += new System.EventHandler(this.seal2DCanvas1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 453);
            this.Controls.Add(this.seal2DCanvas1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Control.Seal2DCanvas seal2DCanvas1;
    }
}

