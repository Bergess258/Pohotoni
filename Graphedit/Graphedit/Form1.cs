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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawForm subform = new DrawForm();
            subform.Show();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawForm subform = (DrawForm)this.ActiveMdiChild;
            if (subform.fileName != "")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Сохранить";
                save.Filter = "Bitmap (*.bmp)|*.bmp| Jpeg (*.jpeg)|*.jpeg| Все файлы (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    ((DrawForm)this.ActiveMdiChild).Save(save.FileName);
                }
            }
            else
                subform.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawForm subform = new DrawForm();
            subform.Show();
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Открыть";
            open.Filter= "Bitmap (*.bmp)|*.bmp| Jpeg (*.jpeg)|*.jpeg| PNG (*.png)|*.png| Все файлы (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                subform.Open(open.FileName);
            }
        }
    }
}
