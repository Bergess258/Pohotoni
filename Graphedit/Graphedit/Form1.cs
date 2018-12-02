using System;
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
    public partial class Form1 : Form
    {
        string selectedTool = "Pencil";
        int valueP=2,valueM=200,value=2;
        Color color = Color.Black;
        int lastform = 0;
        public List<DrawForm> drawForms = new List<DrawForm>();
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
            sizeForm n = new sizeForm(this);
            n.Show();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count > 0)
            {
                if (drawForms[lastform].fileName == "")
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Title = "Сохранить";
                    save.Filter = "Bitmap (*.bmp)|*.bmp| Jpeg (*.jpeg)|*.jpeg| Все файлы (*.*)|*.*";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        drawForms[lastform].Save(save.FileName);
                    }
                }
                else
                    drawForms[lastform].Save();
            }
            else
                MessageBox.Show("Нечего сохранять");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Открыть";
            open.Filter= "Bitmap (*.bmp)|*.bmp| Jpeg (*.jpeg)|*.jpeg| PNG (*.png)|*.png| Все файлы (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                DrawForm subform = new DrawForm(this, drawForms.Count);
                lastform = drawForms.Count;
                drawForms.Add(subform);
                subform.Show();
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
            drawForms[lastform].SizeBack();
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

        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(drawForms.Count > 0)
            drawForms[lastform].SetFilter(Color.Red);
        }

        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count>0)
                drawForms[lastform].SetFilter(Color.Blue);
        }

        private void желтыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count > 0)
                drawForms[lastform].SetFilter(Color.Yellow);
        }

        private void фиолетовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count > 0)
                drawForms[lastform].SetFilter(Color.Violet);
        }

        private void произвольныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count > 0)
            {
                ColorDialog MyDialog = new ColorDialog();
                MyDialog.ShowHelp = true;
                if (MyDialog.ShowDialog() == DialogResult.OK)
                    drawForms[lastform].SetFilter(MyDialog.Color);
            }  
        }

        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int c = 0;
            for (int i = 0; i < drawForms.Count; i++)
            {
                if (drawForms[i] != null)
                {
                    drawForms[i].Location = new Point(c,c);
                    c += 30;
                }
            }
        }

        private void слеваНаправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int allWidth = 0;
            for (int i = 0; i < drawForms.Count; i++)
            {
                allWidth += drawForms[i].Width;
            }
            if(allWidth> Screen.PrimaryScreen.Bounds.Width)
            {
                int c = Screen.PrimaryScreen.Bounds.Width / (drawForms.Count+1);
                for (int i = 0, g = 0; i < drawForms.Count; ++i, g += c)
                {
                    drawForms[i].Location = new Point(g,0);
                }
            }
            else
            {
                for (int i = 0, g = 0; i < drawForms.Count; g += drawForms[i].Width,++i)
                {
                    drawForms[i].Location = new Point(g, 0);
                }
            }
        }

        private void снизуВверхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int allWidth = 0;
            for (int i = 0; i < drawForms.Count; i++)
            {
                allWidth += drawForms[i].Height;
            }
            if (allWidth > Screen.PrimaryScreen.Bounds.Width)
            {
                int c = Screen.PrimaryScreen.Bounds.Height / (drawForms.Count + 2);
                for (int i = 0, g = 0; i < drawForms.Count; ++i, g += c)
                {
                    drawForms[i].Location = new Point(0, g);
                }
            }
            else
            {
                for (int i = 0, g = 0; i < drawForms.Count; g += drawForms[i].Height, ++i)
                {
                    drawForms[i].Location = new Point(0, g);
                }
            }
        }

        private void упорядочитьЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            
        }
        public void lastWind(int numb)
        {
            lastform = numb;
        }

        private void function1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count > 0)
                drawForms[lastform].Func1();
        }

        private void функция2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count > 0)
                drawForms[lastform].Func2();
        }

        private void function3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count > 0)
                drawForms[lastform].Func3();
        }

        private void diffuseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count > 0)
                drawForms[lastform].Func4();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Сохранить";
                save.Filter = "Bitmap (*.bmp)|*.bmp| Jpeg (*.jpeg)|*.jpeg| Все файлы (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    drawForms[lastform].Save(save.FileName);
                }
            }
            else
                MessageBox.Show("Нечего сохранять");
        }

        private void rotateLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(drawForms.Count>0)
                drawForms[lastform].RotateLeft();
        }

        private void rotateRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count > 0)
                drawForms[lastform].RotateRight();
        }

        private void flipHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count > 0)
                drawForms[lastform].FlipH();
        }

        private void flipVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawForms.Count > 0)
                drawForms[lastform].FlipV();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (drawForms.Count == 0) kk = true;
            for (int i = 0; i < drawForms.Count;++i)
            {
                drawForms[i].Close();
            }
            if(!kk)
            e.Cancel = true;
            kk = true;
        }
        static bool kk = false;
        public void RemoveForm(int num)
        {
            drawForms.RemoveAt(num);
            if (kk == true && drawForms.Count == 0) Close();
            for (int i = num; i < drawForms.Count; i++)
            {
                --drawForms[num].realnumb;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        public void ShowForm(int Width,int Height)
        {
            DrawForm subform = new DrawForm(this, drawForms.Count,Width,Height);
            lastform = drawForms.Count;
            subform.setTool(selectedTool,value,color);
            drawForms.Add(subform);
            subform.Show();
        }
    }
}
