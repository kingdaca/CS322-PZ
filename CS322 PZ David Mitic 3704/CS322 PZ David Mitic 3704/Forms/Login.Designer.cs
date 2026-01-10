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
            email.Location = new Point(161, 74);
            email.Name = "email";
            email.PlaceholderText = "Unesite email";
            email.Size = new Size(168, 23);
            email.TabIndex = 0;
            // 
            // pass
            // 
            pass.Location = new Point(162, 104);
            pass.Name = "pass";
            pass.PlaceholderText = "Unesite sifrue";
            pass.Size = new Size(168, 23);
            pass.TabIndex = 1;
            pass.UseSystemPasswordChar = true;
            // 
            // loginbtn
            // 
            loginbtn.Location = new Point(188, 142);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(106, 23);
            loginbtn.TabIndex = 2;
            loginbtn.Text = "Login";
            loginbtn.UseVisualStyleBackColor = true;
            loginbtn.Click += loginbtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 230);
            Controls.Add(loginbtn);
            Controls.Add(pass);
            Controls.Add(email);
            Name = "Login";
            Text = "Login";
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