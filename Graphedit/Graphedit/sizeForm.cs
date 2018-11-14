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
    public partial class sizeForm : Form
    {
        Form1 parent;
        public sizeForm(Form1 par)
        {
            InitializeComponent();
            parent = par;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Widthe, Heighte;
            bool ok = int.TryParse(textBox1.Text, out Widthe), ok2 = int.TryParse(textBox2.Text, out Heighte);
            if (ok == true && ok2 == true)
            {
                parent.ShowForm(Widthe, Heighte);
                Close();
            }
            else
            {
                MessageBox.Show("Неверно введен размер создаваемого окна");
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] temp = comboBox1.SelectedItem.ToString().Split(' ');
            int f=0,c=0;
            int.TryParse(temp[0], out f);
            int.TryParse(temp[1], out c);
            textBox1.Text = f.ToString();
            textBox2.Text = c.ToString();
        }
    }
}
