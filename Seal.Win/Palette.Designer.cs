namespace Seal.Win
{
    partial class Palette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Palette));
            this.BlueShades = new System.Windows.Forms.PictureBox();
            this.Blue = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.B = new System.Windows.Forms.Label();
            this.Bvalue = new System.Windows.Forms.TextBox();
            this.G = new System.Windows.Forms.Label();
            this.Gvalue = new System.Windows.Forms.TextBox();
            this.R = new System.Windows.Forms.Label();
            this.Rvalue = new System.Windows.Forms.TextBox();
            this.SelectedColor = new System.Windows.Forms.Label();
            this.Colors = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BlueShades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Colors)).BeginInit();
            this.SuspendLayout();
            // 
            // BlueShades
            // 
            this.BlueShades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BlueShades.Image = ((System.Drawing.Image)(resources.GetObject("BlueShades.Image")));
            this.BlueShades.Location = new System.Drawing.Point(273, 2);
            this.BlueShades.Name = "BlueShades";
            this.BlueShades.Size = new System.Drawing.Size(10, 256);
            this.BlueShades.TabIndex = 2;
            this.BlueShades.TabStop = false;
            // 
            // Blue
            // 
            this.Blue.Cursor = System.Windows.Forms.Cursors.Default;
            this.Blue.Location = new System.Drawing.Point(289, -7);
            this.Blue.Maximum = 255;
            this.Blue.Name = "Blue";
            this.Blue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Blue.Size = new System.Drawing.Size(45, 277);
            this.Blue.TabIndex = 3;
            this.Blue.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.Blue.Value = 127;
            this.Blue.Scroll += new System.EventHandler(this.Blue_Scroll);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(453, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(366, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // B
            // 
            this.B.AutoSize = true;
            this.B.Location = new System.Drawing.Point(363, 152);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(14, 13);
            this.B.TabIndex = 18;
            this.B.Text = "B";
            // 
            // Bvalue
            // 
            this.Bvalue.Enabled = false;
            this.Bvalue.Location = new System.Drawing.Point(384, 149);
            this.Bvalue.Name = "Bvalue";
            this.Bvalue.Size = new System.Drawing.Size(38, 20);
            this.Bvalue.TabIndex = 17;
            this.Bvalue.TextChanged += new System.EventHandler(this.Rvalue_TextChanged);
            // 
            // G
            // 
            this.G.AutoSize = true;
            this.G.Location = new System.Drawing.Point(363, 112);
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(15, 13);
            this.G.TabIndex = 16;
            this.G.Text = "G";
            // 
            // Gvalue
            // 
            this.Gvalue.Enabled = false;
            this.Gvalue.Location = new System.Drawing.Point(384, 109);
            this.Gvalue.Name = "Gvalue";
            this.Gvalue.Size = new System.Drawing.Size(38, 20);
            this.Gvalue.TabIndex = 15;
            this.Gvalue.TextChanged += new System.EventHandler(this.Rvalue_TextChanged);
            // 
            // R
            // 
            this.R.AutoSize = true;
            this.R.Location = new System.Drawing.Point(363, 72);
            this.R.Name = "R";
            this.R.Size = new System.Drawing.Size(15, 13);
            this.R.TabIndex = 14;
            this.R.Text = "R";
            // 
            // Rvalue
            // 
            this.Rvalue.Enabled = false;
            this.Rvalue.Location = new System.Drawing.Point(384, 69);
            this.Rvalue.Name = "Rvalue";
            this.Rvalue.Size = new System.Drawing.Size(38, 20);
            this.Rvalue.TabIndex = 13;
            this.Rvalue.TextChanged += new System.EventHandler(this.Rvalue_TextChanged);
            // 
            // SelectedColor
            // 
            this.SelectedColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SelectedColor.Location = new System.Drawing.Point(428, 69);
            this.SelectedColor.Name = "SelectedColor";
            this.SelectedColor.Size = new System.Drawing.Size(100, 100);
            this.SelectedColor.TabIndex = 12;
            // 
            // Colors
            // 
            this.Colors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Colors.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Colors.Image = ((System.Drawing.Image)(resources.GetObject("Colors.Image")));
            this.Colors.Location = new System.Drawing.Point(12, 3);
            this.Colors.Name = "Colors";
            this.Colors.Size = new System.Drawing.Size(255, 255);
            this.Colors.TabIndex = 21;
            this.Colors.TabStop = false;
            this.Colors.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Colors_MouseClick);
            this.Colors.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Colors_MouseMove);
            // 
            // Palette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 270);
            this.ControlBox = false;
            this.Controls.Add(this.Colors);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.B);
            this.Controls.Add(this.Bvalue);
            this.Controls.Add(this.G);
            this.Controls.Add(this.Gvalue);
            this.Controls.Add(this.R);
            this.Controls.Add(this.Rvalue);
            this.Controls.Add(this.SelectedColor);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.BlueShades);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Palette";
            this.Text = "Palette";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Palette_FormClosed);
            this.Load += new System.EventHandler(this.Palette_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BlueShades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Colors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BlueShades;
        private System.Windows.Forms.TrackBar Blue;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label B;
        private System.Windows.Forms.TextBox Bvalue;
        private System.Windows.Forms.Label G;
        private System.Windows.Forms.TextBox Gvalue;
        private System.Windows.Forms.Label R;
        private System.Windows.Forms.TextBox Rvalue;
        private System.Windows.Forms.Label SelectedColor;
        private System.Windows.Forms.PictureBox Colors;
    }
}