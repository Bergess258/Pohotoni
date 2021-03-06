﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphedit
{
    public partial class DrawForm : Form
    {
        int old_x,old_Y,curW,curH,bmpW,bmpH;
        Point curPos = new Point(0,0);
        float currentScale = 1,sizeChangedW=1,sizeChangedH=1;
        static Color foreColor = Color.Black;
        static float lineWidth = 2;
        string selectedTool = "Pencil";
        public string fileName="";
        Pen pen = new Pen(foreColor, lineWidth);
        Pen er = new Pen(Color.White,lineWidth);
        public Bitmap bmp,tempBmp;
        Graphics g;
        public int WindowNumb,realnumb;

        private Form1 parental;
        public DrawForm(Form1 par,int numb,int w,int h)
        {
            parental = par;
            WindowNumb = numb;
            realnumb = numb;
            InitializeComponent();
            Text += " "+(numb+1);
            Width = w;
            Height = h;
        }
        public DrawForm(Form1 par, int numb)
        {
            parental = par;
            WindowNumb = numb;
            realnumb = numb;
            InitializeComponent();
            Text += " " + (numb + 1);
        }
        private void DrawForm_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(Width, Height);
            tempBmp = new Bitmap(bmp);
            pB.Image = bmp;
            g = Graphics.FromImage(bmp);
            curH = Height;
            curW = Width;
            bmpH = Height;
            bmpW = Width;
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0x00A1;
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCLBUTTONDOWN:
                    parental.lastWind(WindowNumb);
                    return;
            }
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
            tempBmp = (Bitmap)bmp.Clone();
            if (selectedTool == "plus")
            {
                currentScale *= (float)2;
                pen = new Pen(foreColor, lineWidth*currentScale);
                er = new Pen(Color.White, lineWidth* currentScale);
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
                currentScale /= 2;
                pen = new Pen(foreColor, lineWidth * currentScale);
                er = new Pen(Color.White, lineWidth * currentScale);
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
            parental.lastWind(WindowNumb);
        }

        private void pB_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pB_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            //if (bmp != null&&(curH!=Height||curW!=Width))
            //{
            //    bmp = new Bitmap(tempBmp, new Size((int)(Width * currentScale), (int)(Height * currentScale)));
            //    pB.Image = bmp;
            //    pB.Refresh();
            //}
        }

        private void DrawForm_StyleChanged(object sender, EventArgs e)
        {
            //if (WindowState == System.Windows.Forms.FormWindowState.Maximized)
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
            parental.lastWind(WindowNumb);
        }

        public void Save(string _path)
        {
            bmp.Save(_path);
            fileName = _path;
        }

        private void DrawForm_Enter(object sender, EventArgs e)
        {
            parental.lastWind(WindowNumb);
        }

        private void DrawForm_Resize(object sender, EventArgs e)
        {
            int z = (int)(Width * currentScale), f = (int)(Screen.PrimaryScreen.Bounds.Width * currentScale), z2 = (int)(Height * currentScale), f2 = (int)(Screen.PrimaryScreen.Bounds.Height * currentScale);
            if (bmp!=null&&(z>f|| z2>f2||curW>f))
            {
                bmp = new Bitmap(bmp, new Size((int)(Width * currentScale), (int)(Height * currentScale)));
                pB.Image = bmp;
                pB.Refresh();
                g = Graphics.FromImage(bmp);
                curH = Height;
                curW = Width;
            }
        }

        private void DrawForm_ResizeEnd(object sender, EventArgs e)
        {
            if (bmp != null && (curH != Height || curW != Width))
            {
                bmp = new Bitmap(tempBmp, new Size((int)(Width * currentScale), (int)(Height * currentScale)));
                pB.Image = bmp;
                pB.Refresh();
                sizeChangedW = (float)(1.0*Width / curW);
                sizeChangedH = (float)(1.0 * Height / curH);
                updateTool();
                g = Graphics.FromImage(bmp);
                curH = Height;
                curW = Width;
            }
        }

        private void DrawForm_ResizeBegin(object sender, EventArgs e)
        {
            tempBmp = (Bitmap)bmp.Clone();
            parental.lastWind(realnumb);
            curH = Height;
            curW = Width;
        }

        public void DrawForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save save = new Save(fileName,realnumb,WindowNumb, parental,bmp);
            bmp.Dispose();
            tempBmp.Dispose();
            save.Show();
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
            tempBmp = new Bitmap(bmp);
            Width = tmp.Width+20;
            Height = tmp.Height+20;
            g = Graphics.FromImage(bmp);
            pB.Image = bmp;
            pB.Refresh();
        }
        public void setTool(string str,int stre,Color col)
        {
            selectedTool = str;
            lineWidth = stre;
            foreColor = col;
            updateTool();
        }
        private void updateTool()
        {
            pen = new Pen(foreColor, lineWidth * currentScale*sizeChangedW* sizeChangedH);
            er = new Pen(Color.White, lineWidth * currentScale * sizeChangedW* sizeChangedH);
        }
        public void SizeBack()
        {
            currentScale = 1;
            bmp = new Bitmap(bmp, new Size(Width,Height));
            pB.Image = bmp;
            pB.Refresh();
        }
        public void SetFilter(Color Set)
        {
            //Bitmap temp = new Bitmap(bmpW, bmpH);
            g.FillRectangle(new SolidBrush(Color.FromArgb(100, Set)), 0, 0, bmpW, bmpH);
            pB.Refresh();
        }
        public void ChangeNumb(int num)
        {
            WindowNumb = num;
        }
        public void Func1()
        {
            int red, green, blue, DispX = 1, DispY=1;
            Color pixel1, pixel2;
            for (int i = 0; i < bmp.Height-2; ++i)
            {
                for (int j = 0; j < bmp.Width-2; ++j)
                {
                    pixel1 = bmp.GetPixel(j, i);
                    pixel2 = bmp.GetPixel(j + DispX, i + DispY);
                    red = Math.Min(Math.Abs(Convert.ToInt32(pixel1.R) - Convert.ToInt32(pixel2.R)) + 128, 255);
                    green = Math.Min(Math.Abs(Convert.ToInt32(pixel1.G) - Convert.ToInt32(pixel2.G)) + 128, 255);
                    blue = Math.Min(Math.Abs(Convert.ToInt32(pixel1.B) - Convert.ToInt32(pixel2.B)) + 128, 255);
                    bmp.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
            }
            pB.Image = bmp;
            pB.Refresh();
        }
        public void Func2()
        {
            int red, green, blue, DX = 1, DY = 1;
            Bitmap t = (Bitmap)bmp.Clone();
            for (int i = DX; i < bmp.Height - 1-DX; ++i)
            {
                for (int j = DY; j < bmp.Width - 1-DY; ++j)
                {
                    red = (int)(Convert.ToInt32(t.GetPixel(j, i).R) + 0.5 * Convert.ToInt32((t.GetPixel(j, i).R) - Convert.ToInt32(t.GetPixel(j - DX, i - DY).R)));
                    green = (int)(Convert.ToInt32(t.GetPixel(j, i).G) + 0.7 * Convert.ToInt32((t.GetPixel(j, i).G) - Convert.ToInt32(t.GetPixel(j - DX, i - DY).G)));
                    blue = (int)(Convert.ToInt32(t.GetPixel(j, i).B) + 0.5 * Convert.ToInt32((t.GetPixel(j, i).B - Convert.ToInt32(t.GetPixel(j - DX, i - DY).B))));
                    red = Math.Min(Math.Max(red, 0), 255);
                    green = Math.Min(Math.Max(green, 0), 255);
                    blue = Math.Min(Math.Max(blue, 0), 255);
                    bmp.SetPixel(j, i, Color.FromArgb(red, green, blue));

                }
            }
            pB.Image = bmp;
            pB.Refresh();
        }
        public void Func3()
        {
            int red, green, blue, DX = 1, DY = 1;
            for (int i = DX; i < bmp.Height - 1 - DX; ++i)
            {
                for (int j = DY; j < bmp.Width - 1 - DY; ++j)
                {
                    red = Convert.ToInt32((Convert.ToInt32(bmp.GetPixel(j - 1, i - 1).R) + 
                            Convert.ToInt32(bmp.GetPixel(j - 1, i).R) + 
                            Convert.ToInt32(bmp.GetPixel(j - 1, i + 1).R) + 
                            Convert.ToInt32(bmp.GetPixel(j, i - 1).R) + 
                            Convert.ToInt32(bmp.GetPixel(j, i).R) + 
                            Convert.ToInt32(bmp.GetPixel(j, i + 1).R) + 
                            Convert.ToInt32(bmp.GetPixel(j + 1, i - 1).R) + 
                            Convert.ToInt32(bmp.GetPixel(j + 1, i).R) + 
                            Convert.ToInt32(bmp.GetPixel(j + 1, i + 1).R)) / 9);

                    green = Convert.ToInt32((Convert.ToInt32(bmp.GetPixel(j - 1, i - 1).G) +
                            Convert.ToInt32(bmp.GetPixel(j - 1, i).G) +
                            Convert.ToInt32(bmp.GetPixel(j - 1, i + 1).G) +
                            Convert.ToInt32(bmp.GetPixel(j, i - 1).G) +
                            Convert.ToInt32(bmp.GetPixel(j, i).G) +
                            Convert.ToInt32(bmp.GetPixel(j, i + 1).G) +
                            Convert.ToInt32(bmp.GetPixel(j + 1, i - 1).G) +
                            Convert.ToInt32(bmp.GetPixel(j + 1, i).G) +
                            Convert.ToInt32(bmp.GetPixel(j + 1, i + 1).G)) / 9);

                    blue = Convert.ToInt32((Convert.ToInt32(bmp.GetPixel(j - 1, i - 1).B) +
                            Convert.ToInt32(bmp.GetPixel(j - 1, i).B) +
                            Convert.ToInt32(bmp.GetPixel(j - 1, i + 1).B) +
                            Convert.ToInt32(bmp.GetPixel(j, i - 1).B) +
                            Convert.ToInt32(bmp.GetPixel(j, i).B) +
                            Convert.ToInt32(bmp.GetPixel(j, i + 1).B) +
                            Convert.ToInt32(bmp.GetPixel(j + 1, i - 1).B) +
                            Convert.ToInt32(bmp.GetPixel(j + 1, i).B) +
                            Convert.ToInt32(bmp.GetPixel(j + 1, i + 1).B)) / 9);
                    red = Math.Min(Math.Max(red, 0), 255);
                    green = Math.Min(Math.Max(green, 0), 255);
                    blue = Math.Min(Math.Max(blue, 0), 255);
                    bmp.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
            }
            pB.Image = bmp;
            pB.Refresh();
        }
        public void Func4()
        {
            int red, green, blue, DX, DY;
            Random rand = new Random();
            for (int i = 3; i < bmp.Height - 3; ++i)
            {
                for (int j = 3; j < bmp.Width - 3; ++j)
                {
                    DX = rand.Next((bmp.Width-j)/4) * 4 - 2;
                    DY = rand.Next((bmp.Height - i) / 4) * 4 - 2;
                    red = bmp.GetPixel(j + DX, i + DY).R;
                    green = bmp.GetPixel(j + DX, i + DY).G;
                    blue = bmp.GetPixel(j + DX, i + DY).B;
                    bmp.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
            }
            pB.Image = bmp;
            pB.Refresh();
        }
        public void RotateLeft()
        {
            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            bmp = new Bitmap(bmp, new Size(pB.Height * pB.Image.Width / pB.Image.Height, bmp.Height));
            pB.Image = bmp;
            pB.Refresh();
            g = Graphics.FromImage(bmp);
        }
        public void RotateRight()
        {
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            bmp = new Bitmap(bmp, new Size(pB.Height * pB.Image.Width / pB.Image.Height, bmp.Height));
            pB.Image = bmp;
            pB.Refresh();
            g = Graphics.FromImage(bmp);
        }
        public void FlipH()
        {
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pB.Image = bmp;
            pB.Refresh();
            g = Graphics.FromImage(bmp);
        }
        public void FlipV()
        {
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pB.Image = bmp;
            pB.Refresh();
            g = Graphics.FromImage(bmp);
        }
    }
}
