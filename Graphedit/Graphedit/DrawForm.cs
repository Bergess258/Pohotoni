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
        public string fileName="";
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
                g.DrawLine(new Pen(Color.Black, 10), old_x, old_Y, e.X, e.Y);
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
            //bmp = (Bitmap)tempBmp.Clone();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            old_x = e.X;
            old_Y = e.Y;
            pressed = true;
            tempBmp = (Bitmap)bmp.Clone();
        }

        private void pB_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pB_Click(object sender, EventArgs e)
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
            fileName = _path;
        }
        public void Save()
        {
            bmp.Save(fileName);
        }
        public void Open(string _path)
        {
            fileName = _path;
            bmp = (Bitmap)System.Drawing.Image.FromFile(_path, true);
            Bitmap tmp = new Bitmap(bmp.Width, bmp.Height);
            Graphics ddos = Graphics.FromImage(tmp);
            ddos.DrawImage(bmp,new Rectangle(0,0,tmp.Width,tmp.Height),0,0,tmp.Width,tmp.Height,GraphicsUnit.Pixel);
            bmp = tmp;
            pB.Image = bmp;
            pB.Refresh();
            g = Graphics.FromImage(bmp);
        }
    }
}
