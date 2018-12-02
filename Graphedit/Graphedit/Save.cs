using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphedit
{
    public partial class Save : Form
    {
        string p;
        Form1 par;
        Bitmap bmp;
        int f;
        public Save()
        {
            InitializeComponent();
        }
        public Save(string path,int i,int num,Form1 kek,Bitmap c)
        {
            InitializeComponent();
            label1.Text += " " + (num+1);
            p = path;
            f = i;
            par = kek;
            bmp = (Bitmap)c.Clone();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p == "")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Сохранить";
                save.Filter = "Bitmap (*.bmp)|*.bmp| Jpeg (*.jpeg)|*.jpeg| PNG (*.png)|*.png| Все файлы (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    bmp.Save(save.FileName);
                }
            }
            else
            {
                bmp.Save(p, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            Close();
        }

        private void Save_FormClosing(object sender, FormClosingEventArgs e)
        {
            par.RemoveForm(f);
        }
    }
}
