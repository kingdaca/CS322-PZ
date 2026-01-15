namespace CS322_PZ_David_Mitic_3704.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            projekcijaBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            logoutBtn = new Button();
            reservdBtn = new Button();
            menuStrip1 = new MenuStrip();
            upaToolStripMenuItem = new ToolStripMenuItem();
            filoviToolStripMenuItem = new ToolStripMenuItem();
            projekcijeToolStripMenuItem = new ToolStripMenuItem();
            ObrisiBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)projekcijaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // projekcijaBindingSource
            // 
            projekcijaBindingSource.DataSource = typeof(Models.Projekcija);
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 37);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(436, 141);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(540, 299);
            logoutBtn.Margin = new Padding(3, 2, 3, 2);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(82, 22);
            logoutBtn.TabIndex = 1;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // reservdBtn
            // 
            reservdBtn.Location = new Point(12, 299);
            reservdBtn.Margin = new Padding(3, 2, 3, 2);
            reservdBtn.Name = "reservdBtn";
            reservdBtn.Size = new Size(82, 22);
            reservdBtn.TabIndex = 2;
            reservdBtn.Text = "Rezervisi";
            reservdBtn.UseVisualStyleBackColor = true;
            reservdBtn.Click += reservdBtn_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { upaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(634, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // upaToolStripMenuItem
            // 
            upaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filoviToolStripMenuItem, projekcijeToolStripMenuItem });
            upaToolStripMenuItem.Name = "upaToolStripMenuItem";
            upaToolStripMenuItem.Size = new Size(49, 20);
            upaToolStripMenuItem.Text = "Edituj";
            upaToolStripMenuItem.Visible = false;
            // 
            // filoviToolStripMenuItem
            // 
            filoviToolStripMenuItem.Name = "filoviToolStripMenuItem";
            filoviToolStripMenuItem.Size = new Size(125, 22);
            filoviToolStripMenuItem.Text = "Filovi";
            filoviToolStripMenuItem.Click += filoviToolStripMenuItem_Click;
            // 
            // projekcijeToolStripMenuItem
            // 
            projekcijeToolStripMenuItem.Name = "projekcijeToolStripMenuItem";
            projekcijeToolStripMenuItem.Size = new Size(125, 22);
            projekcijeToolStripMenuItem.Text = "Projekcije";
            projekcijeToolStripMenuItem.Click += projekcijeToolStripMenuItem_Click;
            // 
            // ObrisiBtn
            // 
            ObrisiBtn.Location = new Point(540, 37);
            ObrisiBtn.Name = "ObrisiBtn";
            ObrisiBtn.Size = new Size(75, 23);
            ObrisiBtn.TabIndex = 4;
            ObrisiBtn.Text = "Obrisi";
            ObrisiBtn.UseVisualStyleBackColor = true;
            ObrisiBtn.Visible = false;
            ObrisiBtn.Click += ObrisiBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 344);
            Controls.Add(ObrisiBtn);
            Controls.Add(reservdBtn);
            Controls.Add(logoutBtn);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            Enter += MainForm_Enter;
            ((System.ComponentModel.ISupportInitialize)projekcijaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource projekcijaBindingSource;
        private DataGridView dataGridView1;
        private Button logoutBtn;
        private Button reservdBtn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem upaToolStripMenuItem;
        private ToolStripMenuItem filoviToolStripMenuItem;
        private ToolStripMenuItem projekcijeToolStripMenuItem;
        private Button ObrisiBtn;
    }
}