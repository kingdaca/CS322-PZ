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
            ((System.ComponentModel.ISupportInitialize)projekcijaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // projekcijaBindingSource
            // 
            projekcijaBindingSource.DataSource = typeof(Models.Projekcija);
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(21, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(498, 188);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(618, 349);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(94, 29);
            logoutBtn.TabIndex = 1;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // reservdBtn
            // 
            reservdBtn.Location = new Point(21, 244);
            reservdBtn.Name = "reservdBtn";
            reservdBtn.Size = new Size(94, 29);
            reservdBtn.TabIndex = 2;
            reservdBtn.Text = "Rezervisi";
            reservdBtn.UseVisualStyleBackColor = true;
            reservdBtn.Click += reservdBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 390);
            Controls.Add(reservdBtn);
            Controls.Add(logoutBtn);
            Controls.Add(dataGridView1);
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)projekcijaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource projekcijaBindingSource;
        private DataGridView dataGridView1;
        private Button logoutBtn;
        private Button reservdBtn;
    }
}