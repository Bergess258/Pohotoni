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
        int old_x,old_Y,curW,curH,bmpW,bmpH;
        Point curPos = new Point(0,0);
        float currentScale = 1;
        static Color foreColor = Color.Black;
        static int lineWidth = 2;
        string selectedTool = "Pencil";
        public string fileName="";
        Pen pen = new Pen(foreColor, lineWidth);
        Pen er = new Pen(Color.White,lineWidth);
        Bitmap bmp,tempBmp,sizeChanged;
        Graphics g;
        bool ok = false;

        private Form1 parental;
        public DrawForm(Form1 par)
        {
            parental = par;
            InitializeComponent();
        }
        
        private void DrawForm_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pB.Width, pB.Height);
            pB.Image = bmp;
            g = Graphics.FromImage(bmp);
            selectedTool = parental.selectedTool;
            curH = Height;
            curW = Width;
            bmpH = Height;
            bmpW = Width;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedTool == "Pencil")
                {
                    g.DrawLine(pen, old_x, old_Y, e.X, e.Y);
                    old_x = e.X;
                    old_Y = e.Y;
                    pB.Refresh();
                }
                else
                if (selectedTool == "Eraser")
                {
                    g.DrawLine(er, old_x, old_Y, e.X, e.Y);
                    old_x = e.X;
                    old_Y = e.Y;
                    pB.Refresh();
                }
                else
                {
                    pB.Refresh();
                    bmp = (Bitmap)tempBmp.Clone();
                    g = Graphics.FromImage(bmp);
                    pB.Image = bmp;
                    switch (selectedTool)
                    {
                        case "Rectangle":
                            DrawRectangle(e);
                            break;
                        case "Line":
                            g.DrawLine(pen, old_x, old_Y, e.X, e.Y);
                            break;
                        case "Ellipse":
                            DrawEllipse(e);
                            break;
                        case "Star":
                            DrawStar(e);
                            break;
                    }
                }
            }
        }

        private void DrawStar(MouseEventArgs e)
        {
            double R,r;   // радиусы
            double alpha = 60;// поворот
            double x0, y0; // центр
            if (old_x < e.X)
                x0 = e.X-(e.X - old_x)/2;
            else
                if (old_x != e.X)
                x0 = old_x-(old_x - e.X)/2;
            else
                x0 = old_x;
            if (old_Y < e.Y)
                y0 = e.Y-(e.Y - old_Y)/2;
            else
                if (old_Y != e.Y)
                y0 = old_Y - (old_Y - e.Y)/2;
            else
                y0 = old_Y;
            R = Math.Abs(old_x - e.X) / 4;
            r = Math.Abs(old_Y - e.Y) / 2;
            if (R > r)
            {
                alpha = 180; r = R / 2;
            }
            else
                R = r / 2;
            PointF[] points = new PointF[11];
            double a = alpha, da = Math.PI / 5, l;
            for (int k = 0; k < 11; ++k)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(x0 + l * Math.Cos(a)), (float)(y0 + l * Math.Sin(a)));
                a += da;
            }
            g.DrawPolygon(pen, points);
        }

        private void DrawEllipse(MouseEventArgs e)
        {
            float x, y, X, Y;
            if (old_x <= e.X)
            {
                x = old_x;
                X = e.X - old_x;
            }
            else
            {
                x = e.X;
                X = old_x - e.X;
            }
            if (old_Y <= e.Y)
            {
                y = old_Y;
                Y = e.Y - old_Y;
            }
            else
            {
                y = e.Y;
                Y = old_Y - e.Y;
            }
            g.DrawEllipse(pen, x, y, X, Y);
        }

        private void pictureBox1_SizeModeChanged(object sender, EventArgs e)
        {
            
        }

        private void pB_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedTool != "plus" && selectedTool != "minus")
            {
                if (selectedTool == "Pencil")
                {
                    g.DrawLine(pen, old_x, old_Y, e.X, e.Y);
                    old_x = e.X;
                    old_Y = e.Y;
                }
                if (selectedTool == "Eraser")
                {
                    g.DrawLine(er, old_x, old_Y, e.X, e.Y);
                    old_x = e.X;
                    old_Y = e.Y;
                }
                else
                {
                    switch (selectedTool)
                    {
                        case "Rectangle":
                            DrawRectangle(e);
                            break;
                        case "Line":
                            g.DrawLine(pen, old_x, old_Y, e.X, e.Y);
                            break;
                        case "Ellipse":
                            DrawEllipse(e);
                            break;
                        case "Star":
                            DrawStar(e);
                            break;
                    }
                }
                pB.Refresh();
            }
            else
            {
                bmp = new Bitmap(tempBmp, new Size(bmpW, bmpH));
                pB.Image = bmp;
                pB.Refresh();
                g = Graphics.FromImage(bmp);
            }
        }

        private void DrawRectangle(MouseEventArgs e)
        {
            float x, y, X, Y;
            if (old_x <= e.X)
            {
                x = old_x;
                X = e.X - old_x;
            }
            else
            {
                x = e.X;
                X = old_x - e.X;
            }
            if (old_Y <= e.Y)
            {
                y = old_Y;
                Y = e.Y - old_Y;
            }
            else
            {
                y = e.Y;
                Y = old_Y - e.Y;
            }
            g.DrawRectangle(pen, x, y, X, Y);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int z = (int)(Width * currentScale), f = (int)(Screen.PrimaryScreen.Bounds.Width * currentScale);
            tempBmp = (Bitmap)bmp.Clone();
            if (selectedTool == "plus")
            {
                sizeChanged = (Bitmap)bmp.Clone();
                currentScale *= (float)2;
                bmpH = (int)(Height * currentScale);
                bmpW = (int)(Width * currentScale);
                bmp = new Bitmap(tempBmp, new Size(bmpW,bmpH));
                pB.Image = bmp;
                pB.Refresh();
                g = Graphics.FromImage(bmp);
            }
            else
            if (selectedTool == "minus")
            {
                sizeChanged = (Bitmap)bmp.Clone();
                currentScale *= (float)0.5;
                bmpH = (int)(Height * currentScale);
                bmpW = (int)(Width * currentScale);
                bmp = new Bitmap(tempBmp, new Size(bmpW, bmpH));
                pB.Image = bmp;
                g = Graphics.FromImage(bmp);
                pB.Refresh();
            }
            else
            {
                old_x = e.X;
                old_Y = e.Y;
            }
        }

        private void pB_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pB_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            if (bmp != null&&(curH!=Height||curW!=Width))
            {
                bmp = new Bitmap(tempBmp, new Size((int)(Width * currentScale), (int)(Height * currentScale)));
                pB.Image = bmp;
                pB.Refresh();
            }
        }

        private void DrawForm_StyleChanged(object sender, EventArgs e)
        {
            //if(WindowState== System.Windows.Forms.FormWindowState.Maximized)
            //{
            //    ok = true;
            //    bmp = new Bitmap(bmp, new Size((int)(Width * currentScale), (int)(Height * currentScale)));
            //    pB.Image = bmp;
            //    pB.Refresh();
            //}
            //else
            //{
            //    if (ok == true)
            //    {
            //        ok = false;
            //        bmp = new Bitmap(bmp, new Size((int)(Width * currentScale), (int)(Height * currentScale)));
            //        pB.Image = bmp;
            //        pB.Refresh();
            //    }
            //}
        }

        public void Save(string _path)
        {
            bmp.Save(_path);
            fileName = _path;
        }

        private void DrawForm_Enter(object sender, EventArgs e)
        {

        }

        private void DrawForm_ResizeEnd(object sender, EventArgs e)
        {
            if (bmp != null && (curH != Height || curW != Width))
            {
                bmp = new Bitmap(tempBmp, new Size((int)(Width * currentScale), (int)(Height * currentScale)));
                pB.Image = bmp;
                pB.Refresh();
                g = Graphics.FromImage(bmp);
                curH = Height;
                curW = Width;
            }
        }

        private void DrawForm_ResizeBegin(object sender, EventArgs e)
        {
            tempBmp = (Bitmap)bmp.Clone();
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
        public void setTool(string str,int stre,Color col)
        {
            selectedTool = str;
            lineWidth = stre;
            foreColor = col;
            pen = new Pen(foreColor, lineWidth);
            er = new Pen(Color.White, lineWidth);
        }
        public void SizeBack()
        {
            currentScale = 1;
            bmp = new Bitmap(bmp, new Size(Width,Height));
            pB.Image = bmp;
            pB.Refresh();
        }
    }
}
