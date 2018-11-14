namespace Graphedit
{
    partial class DrawForm
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
            this.pB = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pB)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pB
            // 
            this.pB.BackColor = System.Drawing.Color.White;
            this.pB.Location = new System.Drawing.Point(0, 0);
            this.pB.Margin = new System.Windows.Forms.Padding(2);
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(600, 366);
            this.pB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pB.TabIndex = 0;
            this.pB.TabStop = false;
            this.pB.SizeModeChanged += new System.EventHandler(this.pictureBox1_SizeModeChanged);
            this.pB.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pB.Click += new System.EventHandler(this.pB_Click);
            this.pB.Paint += new System.Windows.Forms.PaintEventHandler(this.pB_Paint);
            this.pB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pB_MouseUp);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 366);
            this.panel1.TabIndex = 1;
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DrawForm";
            this.Text = "Окно редактирования";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DrawForm_FormClosing);
            this.Load += new System.EventHandler(this.DrawForm_Load);
            this.ResizeBegin += new System.EventHandler(this.DrawForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.DrawForm_ResizeEnd);
            this.Enter += new System.EventHandler(this.DrawForm_Enter);
            this.Resize += new System.EventHandler(this.DrawForm_Resize);
            this.StyleChanged += new System.EventHandler(this.DrawForm_StyleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pB)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pB;
        private System.Windows.Forms.Panel panel1;
    }
}