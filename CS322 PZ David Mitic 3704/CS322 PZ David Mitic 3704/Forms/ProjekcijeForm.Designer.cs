namespace CS322_PZ_David_Mitic_3704.Forms
{
    partial class ProjekcijeForm
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
            filmComboBox = new ComboBox();
            salaComboBox = new ComboBox();
            dodajProjekciju = new Button();
            dateTimePicker1 = new DateTimePicker();
            vremeComboBox = new ComboBox();
            cenaTextBox = new TextBox();
            SuspendLayout();
            // 
            // filmComboBox
            // 
            filmComboBox.FormattingEnabled = true;
            filmComboBox.Location = new Point(70, 44);
            filmComboBox.Name = "filmComboBox";
            filmComboBox.Size = new Size(200, 23);
            filmComboBox.TabIndex = 0;
            filmComboBox.SelectedIndexChanged += filmComboBox_SelectedIndexChanged;
            // 
            // salaComboBox
            // 
            salaComboBox.FormattingEnabled = true;
            salaComboBox.Location = new Point(70, 92);
            salaComboBox.Name = "salaComboBox";
            salaComboBox.Size = new Size(200, 23);
            salaComboBox.TabIndex = 1;
            // 
            // dodajProjekciju
            // 
            dodajProjekciju.Location = new Point(105, 267);
            dodajProjekciju.Name = "dodajProjekciju";
            dodajProjekciju.Size = new Size(121, 23);
            dodajProjekciju.TabIndex = 2;
            dodajProjekciju.Text = "Dodaj";
            dodajProjekciju.UseVisualStyleBackColor = true;
            dodajProjekciju.Click += dodajProjekciju_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(70, 140);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // vremeComboBox
            // 
            vremeComboBox.FormattingEnabled = true;
            vremeComboBox.Location = new Point(70, 181);
            vremeComboBox.Name = "vremeComboBox";
            vremeComboBox.Size = new Size(200, 23);
            vremeComboBox.TabIndex = 4;
            // 
            // cenaTextBox
            // 
            cenaTextBox.Location = new Point(70, 223);
            cenaTextBox.Name = "cenaTextBox";
            cenaTextBox.PlaceholderText = "Cena";
            cenaTextBox.Size = new Size(200, 23);
            cenaTextBox.TabIndex = 5;
            cenaTextBox.TextChanged += cenaTextBox_TextChanged;
            // 
            // ProjekcijeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 302);
            Controls.Add(cenaTextBox);
            Controls.Add(vremeComboBox);
            Controls.Add(dateTimePicker1);
            Controls.Add(dodajProjekciju);
            Controls.Add(salaComboBox);
            Controls.Add(filmComboBox);
            Name = "ProjekcijeForm";
            Text = "ProjekcijeForm";
            Load += ProjekcijeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox filmComboBox;
        private ComboBox salaComboBox;
        private Button dodajProjekciju;
        private DateTimePicker dateTimePicker1;
        private ComboBox vremeComboBox;
        private TextBox cenaTextBox;
    }
}