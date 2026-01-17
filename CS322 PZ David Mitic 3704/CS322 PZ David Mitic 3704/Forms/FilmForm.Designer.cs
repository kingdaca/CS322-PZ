namespace CS322_PZ_David_Mitic_3704.Forms
{
    partial class FilmForm
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
            filmoviDataGridView = new DataGridView();
            naslovTextBox = new TextBox();
            zanrTextBox = new TextBox();
            trajanjeTextBox = new TextBox();
            opisTextBox = new TextBox();
            urlTxtBox = new TextBox();
            addOrUpdateBtn = new Button();
            deleteBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)filmoviDataGridView).BeginInit();
            SuspendLayout();
            // 
            // filmoviDataGridView
            // 
            filmoviDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            filmoviDataGridView.Location = new Point(12, 12);
            filmoviDataGridView.Name = "filmoviDataGridView";
            filmoviDataGridView.Size = new Size(643, 150);
            filmoviDataGridView.TabIndex = 0;
            filmoviDataGridView.CellContentClick += filmoviDataGridView_CellContentClick;
            filmoviDataGridView.RowHeaderMouseClick += filmoviDataGridView_RowHeaderMouseClick;
            filmoviDataGridView.MouseClick += filmoviDataGridView_MouseClick;
            // 
            // naslovTextBox
            // 
            naslovTextBox.Location = new Point(12, 209);
            naslovTextBox.Name = "naslovTextBox";
            naslovTextBox.PlaceholderText = "Naslov";
            naslovTextBox.Size = new Size(185, 23);
            naslovTextBox.TabIndex = 1;
            // 
            // zanrTextBox
            // 
            zanrTextBox.Location = new Point(12, 249);
            zanrTextBox.Name = "zanrTextBox";
            zanrTextBox.PlaceholderText = "Zanr";
            zanrTextBox.Size = new Size(185, 23);
            zanrTextBox.TabIndex = 2;
            // 
            // trajanjeTextBox
            // 
            trajanjeTextBox.Location = new Point(12, 293);
            trajanjeTextBox.Name = "trajanjeTextBox";
            trajanjeTextBox.PlaceholderText = "Trajanje";
            trajanjeTextBox.Size = new Size(185, 23);
            trajanjeTextBox.TabIndex = 3;
            trajanjeTextBox.TextChanged += trajanjeTextBox_TextChanged;
            // 
            // opisTextBox
            // 
            opisTextBox.Location = new Point(12, 338);
            opisTextBox.Multiline = true;
            opisTextBox.Name = "opisTextBox";
            opisTextBox.PlaceholderText = "Opis";
            opisTextBox.Size = new Size(185, 49);
            opisTextBox.TabIndex = 4;
            // 
            // urlTxtBox
            // 
            urlTxtBox.Location = new Point(12, 404);
            urlTxtBox.Name = "urlTxtBox";
            urlTxtBox.PlaceholderText = "Url slike";
            urlTxtBox.Size = new Size(185, 23);
            urlTxtBox.TabIndex = 5;
            // 
            // addOrUpdateBtn
            // 
            addOrUpdateBtn.Location = new Point(12, 451);
            addOrUpdateBtn.Name = "addOrUpdateBtn";
            addOrUpdateBtn.Size = new Size(185, 23);
            addOrUpdateBtn.TabIndex = 6;
            addOrUpdateBtn.Text = "Dodaj";
            addOrUpdateBtn.UseVisualStyleBackColor = true;
            addOrUpdateBtn.Click += addOrUpdateBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(580, 451);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(75, 23);
            deleteBtn.TabIndex = 7;
            deleteBtn.Text = "Obrisi";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // FilmForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 492);
            Controls.Add(deleteBtn);
            Controls.Add(addOrUpdateBtn);
            Controls.Add(urlTxtBox);
            Controls.Add(opisTextBox);
            Controls.Add(trajanjeTextBox);
            Controls.Add(zanrTextBox);
            Controls.Add(naslovTextBox);
            Controls.Add(filmoviDataGridView);
            Name = "FilmForm";
            Text = "FilmForm";
            Load += FilmForm_Load;
            ((System.ComponentModel.ISupportInitialize)filmoviDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView filmoviDataGridView;
        private TextBox naslovTextBox;
        private TextBox zanrTextBox;
        private TextBox trajanjeTextBox;
        private TextBox opisTextBox;
        private TextBox urlTxtBox;
        private Button addOrUpdateBtn;
        private Button deleteBtn;
    }
}