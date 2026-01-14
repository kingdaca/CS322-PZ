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
            button2 = new Button();
            SuspendLayout();
            // 
            // flpSala
            // 
            flpSala.AutoScroll = true;
            flpSala.Location = new Point(226, 63);
            flpSala.Name = "flpSala";
            flpSala.Size = new Size(487, 375);
            flpSala.TabIndex = 0;
            // 
            // lblIzabranaSedista
            // 
            lblIzabranaSedista.AutoSize = true;
            lblIzabranaSedista.Location = new Point(226, 21);
            lblIzabranaSedista.Name = "lblIzabranaSedista";
            lblIzabranaSedista.Size = new Size(124, 20);
            lblIzabranaSedista.TabIndex = 0;
            lblIzabranaSedista.Text = "Izaberite sedišta :";
            // 
            // button1
            // 
            button1.Location = new Point(226, 471);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Rezervisi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(619, 471);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "Odustani";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // RezervacijeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 552);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lblIzabranaSedista);
            Controls.Add(flpSala);
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
        private Button button2;
    }
}