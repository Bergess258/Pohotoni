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
            ((System.ComponentModel.ISupportInitialize)(this.pB)).BeginInit();
            this.SuspendLayout();
            // 
            // pB
            // 
            this.pB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB.Location = new System.Drawing.Point(0, 0);
            this.pB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(600, 366);
            this.pB.TabIndex = 0;
            this.pB.TabStop = false;
            this.pB.SizeModeChanged += new System.EventHandler(this.pictureBox1_SizeModeChanged);
            this.pB.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pB.Paint += new System.Windows.Forms.PaintEventHandler(this.pB_Paint);
            this.pB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pB_MouseUp);
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.pB);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DrawForm";
            this.Text = "DrawForm";
            this.Load += new System.EventHandler(this.DrawForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pB;
    }
}