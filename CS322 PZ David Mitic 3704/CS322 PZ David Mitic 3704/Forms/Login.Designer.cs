namespace CS322_PZ_David_Mitic_3704.Forms
{
    partial class Login
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
            email = new TextBox();
            pass = new TextBox();
            loginbtn = new Button();
            SuspendLayout();
            // 
            // email
            // 
            email.Location = new Point(184, 99);
            email.Margin = new Padding(3, 4, 3, 4);
            email.Name = "email";
            email.PlaceholderText = "Unesite email";
            email.Size = new Size(191, 27);
            email.TabIndex = 0;
            // 
            // pass
            // 
            pass.Location = new Point(185, 139);
            pass.Margin = new Padding(3, 4, 3, 4);
            pass.Name = "pass";
            pass.PlaceholderText = "Unesite sifrue";
            pass.Size = new Size(191, 27);
            pass.TabIndex = 1;
            pass.UseSystemPasswordChar = true;
            // 
            // loginbtn
            // 
            loginbtn.Location = new Point(215, 189);
            loginbtn.Margin = new Padding(3, 4, 3, 4);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(121, 31);
            loginbtn.TabIndex = 2;
            loginbtn.Text = "Login";
            loginbtn.UseVisualStyleBackColor = true;
            loginbtn.Click += loginbtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 307);
            Controls.Add(loginbtn);
            Controls.Add(pass);
            Controls.Add(email);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Login";
            Text = "Login";
            FormClosing += Login_FormClosing;
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox email;
        private TextBox pass;
        private Button loginbtn;
    }
}