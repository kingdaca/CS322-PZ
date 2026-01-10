using CS322_PZ_David_Mitic_3704.DataBase;
using CS322_PZ_David_Mitic_3704.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS322_PZ_David_Mitic_3704.Forms
{
    public partial class Login : Form
    {

        private DBHelper dbHelper;
        public Login()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = dbHelper.Login(email.Text, pass.Text);

            MessageBox.Show(korisnik != null ? "Uspesno ste se ulogovali!" : "Pogresan email ili lozinka!");
        }
    }
}
