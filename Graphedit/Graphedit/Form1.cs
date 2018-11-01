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
        public string selectedTool = "Pencil";
        int valueP=2,valueM=200,value=2;
        Color color = Color.Black;
        List<DrawForm> drawForms = new List<DrawForm>();
        public Form1()
        {
            InitializeComponent();
            Pencil.Checked = true;
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawForm subform = new DrawForm(this);
            drawForms.Add(subform);
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
            DrawForm subform = new DrawForm(this);
            drawForms.Add(subform);
            subform.MdiParent = this;
            subform.Show();
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Открыть";
            open.Filter= "Bitmap (*.bmp)|*.bmp| Jpeg (*.jpeg)|*.jpeg| PNG (*.png)|*.png| Все файлы (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                subform.Open(open.FileName);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            selectedTool = "Eraser";
            Eraser.Checked = true;
            Pencil.Checked = false;
            plus.Checked = false;
            minus.Checked = false;
            ForTools();
        }

        private void ForTools()
        {
            value = valueP;
            updateTool();
            Strenght.Text = valueP.ToString();
            Siz.Text = "Size";
            Pero.Text = "пера";
        }

        private void Forms_ButtonClick(object sender, EventArgs e)
        {

        }

        private void rectangle_Click(object sender, EventArgs e)
        {
            selectedTool = "Rectangle";
            Eraser.Checked = false;
            Pencil.Checked = false;
            plus.Checked = false;
            minus.Checked = false;
            ForTools();
        }

        private void Pencil_Click(object sender, EventArgs e)
        {
            selectedTool = "Pencil";
            Eraser.Checked = false;
            Pencil.Checked = true;
            plus.Checked = false;
            minus.Checked = false;
            ForTools();
        }

        private void Line_Click(object sender, EventArgs e)
        {
            selectedTool = "Line";
            Eraser.Checked = false;
            Pencil.Checked = false;
            plus.Checked = false;
            minus.Checked = false;
            ForTools();
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            selectedTool = "Ellipse";
            Eraser.Checked = false;
            Pencil.Checked = false;
            plus.Checked = false;
            minus.Checked = false;
            ForTools();
        }

        private void Star_Click(object sender, EventArgs e)
        {
            selectedTool = "Star";
            Eraser.Checked = false;
            Pencil.Checked = false;
            plus.Checked = false;
            minus.Checked = false;
            ForTools();
        }

        private void plus_Click(object sender, EventArgs e)
        {
            selectedTool = "plus";
            Eraser.Checked = false;
            Pencil.Checked = false;
            plus.Checked = true;
            minus.Checked = false;
            value = valueM;
            updateTool();
            Strenght.Text = valueM.ToString();
            Siz.Text = "Увели";
            Pero.Text = "чение";
        }

        private void minus_Click(object sender, EventArgs e)
        {
            selectedTool = "minus";
            Eraser.Checked = false;
            Pencil.Checked = false;
            plus.Checked = false;
            minus.Checked = true;
            value = valueM;
            updateTool();
            Strenght.Text = valueM.ToString();
            Siz.Text = "Отда";
            Pero.Text = "лить";
        }

        private void Strenght_TextChanged(object sender, EventArgs e)
        {
            bool ok = int.TryParse(Strenght.Text, out value);
            if (ok)
            {
                toolStripLabel3.Visible = false;
                if (selectedTool == "plus" || selectedTool == "minus")
                {
                    valueM = value;
                }
                else
                {
                    valueP = value;
                }
                updateTool();
            }
            else
            {
                toolStripLabel3.Visible = true;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowHelp = true;
            MyDialog.Color = color;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                color = MyDialog.Color;
            updateTool();
        }

        private void BackSize_Click(object sender, EventArgs e)
        {
            DrawForm subform = (DrawForm)this.ActiveMdiChild;
            subform.SizeBack();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            HelperForm heh = new HelperForm();
            heh.Show();
        }

        private void updateTool()
        {
            for (int i = 0; i < drawForms.Count; ++i)
            {
                if (drawForms[i] != null)
                    drawForms[i].setTool(selectedTool,value,color);
                else
                    drawForms.RemoveAt(i--);
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
