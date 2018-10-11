using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphedit
{
    public partial class DrawForm : Form
    {
        int old_x,old_Y;
        Color foreColor;
        int lineWidth;
        string selectedTool;
        Bitmap bmp,tempBmp;
        Graphics g;
        bool pressed = false;
        public DrawForm()
        {
            InitializeComponent();
        }

        
        private void DrawForm_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pB.Width, pB.Height);
            pB.Image = bmp;
            g = Graphics.FromImage(bmp);
            foreColor = Color.Black;
            lineWidth = 2;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //g.DrawLine(new Pen(Color.Black, 10), old_x, old_Y, e.X, e.Y);
                old_x = e.X;
                old_Y = e.Y;
                //g.FillEllipse(Brushes.Violet, e.X, e.Y, 3, 3);
                pB.Refresh();
            }
        }

        private void pictureBox1_SizeModeChanged(object sender, EventArgs e)
        {
            
        }

        private void pB_MouseUp(object sender, MouseEventArgs e)
        {
            pressed = false;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            old_x = e.X;
            old_Y = e.Y;
            pressed = true;
        }

        private void pB_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                bmp = new Bitmap(bmp, new Size(Math.Max(Width, bmp.Width), Math.Max(Height, bmp.Height)));
                pB.Image = bmp;
                pB.Refresh();
                g = Graphics.FromImage(bmp);
            }
                
        }

        public void Save(string _path)
        {
            bmp.Save(_path);
        }
    }
}
