namespace CS322_PZ_David_Mitic_3704.Forms
{
    partial class RezervacijeForm
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
            flpSala = new FlowLayoutPanel();
            lblIzabranaSedista = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // flpSala
            // 
            flpSala.AutoScroll = true;
            flpSala.Location = new Point(198, 47);
            flpSala.Margin = new Padding(3, 2, 3, 2);
            flpSala.Name = "flpSala";
            flpSala.Size = new Size(372, 281);
            flpSala.TabIndex = 0;
            // 
            // lblIzabranaSedista
            // 
            lblIzabranaSedista.AutoSize = true;
            lblIzabranaSedista.Location = new Point(198, 16);
            lblIzabranaSedista.Name = "lblIzabranaSedista";
            lblIzabranaSedista.Size = new Size(96, 15);
            lblIzabranaSedista.TabIndex = 0;
            lblIzabranaSedista.Text = "Izaberite sedišta :";
            // 
            // button1
            // 
            button1.Location = new Point(198, 353);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 1;
            button1.Text = "Rezervisi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // RezervacijeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 414);
            Controls.Add(button1);
            Controls.Add(lblIzabranaSedista);
            Controls.Add(flpSala);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RezervacijeForm";
            Text = "RezervacijeForm";
            Load += RezervacijeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpSala;
        private Label lblIzabranaSedista;
        private Button button1;
    }
}