namespace Graphedit
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рисунокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Pencil = new System.Windows.Forms.ToolStripButton();
            this.Eraser = new System.Windows.Forms.ToolStripButton();
            this.Forms = new System.Windows.Forms.ToolStripSplitButton();
            this.rectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.Line = new System.Windows.Forms.ToolStripMenuItem();
            this.Ellipse = new System.Windows.Forms.ToolStripMenuItem();
            this.Star = new System.Windows.Forms.ToolStripMenuItem();
            this.plus = new System.Windows.Forms.ToolStripButton();
            this.minus = new System.Windows.Forms.ToolStripButton();
            this.Help = new System.Windows.Forms.ToolStripButton();
            this.BackSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Siz = new System.Windows.Forms.ToolStripLabel();
            this.Pero = new System.Windows.Forms.ToolStripLabel();
            this.Strenght = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.рисунокToolStripMenuItem,
            this.окноToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(771, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // рисунокToolStripMenuItem
            // 
            this.рисунокToolStripMenuItem.Name = "рисунокToolStripMenuItem";
            this.рисунокToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.рисунокToolStripMenuItem.Text = "Рисунок";
            // 
            // окноToolStripMenuItem
            // 
            this.окноToolStripMenuItem.Name = "окноToolStripMenuItem";
            this.окноToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.окноToolStripMenuItem.Text = "Окно";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Pencil,
            this.Eraser,
            this.Forms,
            this.plus,
            this.minus,
            this.BackSize,
            this.Help,
            this.toolStripSeparator1,
            this.Siz,
            this.Pero,
            this.Strenght,
            this.toolStripLabel1,
            this.toolStripButton3,
            this.toolStripLabel3});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(33, 435);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "leftTools";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // Pencil
            // 
            this.Pencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Pencil.Image = ((System.Drawing.Image)(resources.GetObject("Pencil.Image")));
            this.Pencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pencil.Name = "Pencil";
            this.Pencil.Size = new System.Drawing.Size(23, 20);
            this.Pencil.Text = "pen";
            this.Pencil.Click += new System.EventHandler(this.Pencil_Click);
            // 
            // Eraser
            // 
            this.Eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Eraser.Image = ((System.Drawing.Image)(resources.GetObject("Eraser.Image")));
            this.Eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Eraser.Name = "Eraser";
            this.Eraser.Size = new System.Drawing.Size(23, 20);
            this.Eraser.Text = "eraser";
            this.Eraser.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Forms
            // 
            this.Forms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Forms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangle,
            this.Line,
            this.Ellipse,
            this.Star});
            this.Forms.Image = ((System.Drawing.Image)(resources.GetObject("Forms.Image")));
            this.Forms.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Forms.Name = "Forms";
            this.Forms.Size = new System.Drawing.Size(32, 20);
            this.Forms.Text = "toolStripSplitButton1";
            this.Forms.ButtonClick += new System.EventHandler(this.Forms_ButtonClick);
            // 
            // rectangle
            // 
            this.rectangle.Image = ((System.Drawing.Image)(resources.GetObject("rectangle.Image")));
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(129, 22);
            this.rectangle.Text = " Rectangle";
            this.rectangle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.rectangle.Click += new System.EventHandler(this.rectangle_Click);
            // 
            // Line
            // 
            this.Line.Image = ((System.Drawing.Image)(resources.GetObject("Line.Image")));
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(129, 22);
            this.Line.Text = "Line";
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // Ellipse
            // 
            this.Ellipse.Image = ((System.Drawing.Image)(resources.GetObject("Ellipse.Image")));
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.Size = new System.Drawing.Size(129, 22);
            this.Ellipse.Text = "Ellipse";
            this.Ellipse.Click += new System.EventHandler(this.Ellipse_Click);
            // 
            // Star
            // 
            this.Star.Image = ((System.Drawing.Image)(resources.GetObject("Star.Image")));
            this.Star.Name = "Star";
            this.Star.Size = new System.Drawing.Size(129, 22);
            this.Star.Text = "Star";
            this.Star.Click += new System.EventHandler(this.Star_Click);
            // 
            // plus
            // 
            this.plus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.plus.Image = ((System.Drawing.Image)(resources.GetObject("plus.Image")));
            this.plus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(23, 20);
            this.plus.Text = "toolStripButton4";
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // minus
            // 
            this.minus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.minus.Image = ((System.Drawing.Image)(resources.GetObject("minus.Image")));
            this.minus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(23, 20);
            this.minus.Text = "toolStripButton1";
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // Help
            // 
            this.Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Help.Image = ((System.Drawing.Image)(resources.GetObject("Help.Image")));
            this.Help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(23, 20);
            this.Help.Text = "toolStripButton1";
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // BackSize
            // 
            this.BackSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BackSize.Image = ((System.Drawing.Image)(resources.GetObject("BackSize.Image")));
            this.BackSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackSize.Name = "BackSize";
            this.BackSize.Size = new System.Drawing.Size(23, 20);
            this.BackSize.Text = "toolStripButton2";
            this.BackSize.Click += new System.EventHandler(this.BackSize_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // Siz
            // 
            this.Siz.Name = "Siz";
            this.Siz.Size = new System.Drawing.Size(27, 15);
            this.Siz.Text = "Size";
            // 
            // Pero
            // 
            this.Pero.Name = "Pero";
            this.Pero.Size = new System.Drawing.Size(33, 15);
            this.Pero.Text = "пера";
            // 
            // Strenght
            // 
            this.Strenght.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Strenght.Name = "Strenght";
            this.Strenght.Size = new System.Drawing.Size(30, 23);
            this.Strenght.Text = "2";
            this.Strenght.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            this.Strenght.TextChanged += new System.EventHandler(this.Strenght_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 15);
            this.toolStripLabel1.Text = "Цвет";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.toolStripLabel3.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripLabel3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(30, 46);
            this.toolStripLabel3.Text = "!";
            this.toolStripLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripLabel3.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 459);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Топ редактор изображений";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Pencil;
        private System.Windows.Forms.ToolStripButton Eraser;
        private System.Windows.Forms.ToolStripSplitButton Forms;
        private System.Windows.Forms.ToolStripMenuItem rectangle;
        private System.Windows.Forms.ToolStripButton plus;
        private System.Windows.Forms.ToolStripButton minus;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рисунокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Line;
        private System.Windows.Forms.ToolStripMenuItem Ellipse;
        private System.Windows.Forms.ToolStripMenuItem Star;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel Siz;
        private System.Windows.Forms.ToolStripLabel Pero;
        private System.Windows.Forms.ToolStripTextBox Strenght;
        private System.Windows.Forms.ToolStripButton Help;
        private System.Windows.Forms.ToolStripButton BackSize;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}

