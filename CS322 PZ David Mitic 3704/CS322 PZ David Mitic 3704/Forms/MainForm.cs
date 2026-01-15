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
    public partial class MainForm : Form
    {

        private Korisnik trenutniKorisnik;
        private DBHelper dBHelper;
        public MainForm()
        {
            InitializeComponent();
            dBHelper = new DBHelper();
            LoadProjekcije();
        }

        public MainForm(Korisnik korisnik) : this()
        {
            trenutniKorisnik = korisnik;
            if (trenutniKorisnik.JeAdmin)
            {
                upaToolStripMenuItem.Visible = true;
                ObrisiBtn.Visible = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadProjekcije()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("ProjekcijaID", "ID");
            dataGridView1.Columns.Add("FilmNaslov", "Film");
            dataGridView1.Columns.Add("DatumVreme", "Datum i vreme");
            dataGridView1.Columns.Add("SalaNaziv", "Sala");
            dataGridView1.Columns.Add("CenaKarte", "Cena");

            dataGridView1.Columns[0].Visible = false; // Sakrij ID

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[1].FillWeight = 60;
            dataGridView1.Columns[2].FillWeight = 60;
            dataGridView1.Columns[3].FillWeight = 40;
            dataGridView1.Columns[4].FillWeight = 30;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;

            // Učitaj podatke
            List<Projekcija> projekcije = dBHelper.GetProjekcije();
            if (projekcije == null) return;

            foreach (var p in projekcije)
            {
                dataGridView1.Rows.Add(
                    p.ProjekcijaID,
                    p.FilmNaslov ?? "Nepoznato",
                    p.DatumVreme.ToString("dd.MM.yyyy HH:mm"),
                    p.SalaNaziv ?? "Nepoznato",
                    p.CenaKarte.ToString("0.00") + " RSD"
                );
            }

            // Podesi visinu
            int headerHeight = dataGridView1.ColumnHeadersHeight;
            int rowHeight = dataGridView1.RowTemplate.Height;
            int rowsToShow = Math.Min(5, dataGridView1.Rows.Count);
            dataGridView1.Height = headerHeight + (rowHeight * rowsToShow) + 2;
        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            trenutniKorisnik = null;
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void reservdBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite projekciju!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int projekcijaID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            RezervacijeForm rezervacijaForm = new RezervacijeForm(projekcijaID, trenutniKorisnik);
            if (rezervacijaForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Uspešno ste rezervisali kartu!", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void filoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilmForm filmForm = new FilmForm();
            filmForm.Show();
        }

        private void projekcijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjekcijeForm projekcijeForm = new ProjekcijeForm(this);
            projekcijeForm.Show();
        }

        private void MainForm_Enter(object sender, EventArgs e)
        {

        }

        public void refreshProjekcije()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // 2. Daj vremena sistemu
            Application.DoEvents();

            // 3. Ponovo učitaj sve od početka
            LoadProjekcije();

            // 4. Osveži
            dataGridView1.Refresh();
            dataGridView1.Invalidate();
        }

        private void ObrisiBtn_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite projekciju za brisanje!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else
            {
                int projekcijaID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                var confirmResult = MessageBox.Show("Da li ste sigurni da želite da obrišete ovu projekciju?", 
                    "Potvrda brisanja", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    bool success = dBHelper.deleteProjekcija(projekcijaID);
                    if (success)
                    {
                        MessageBox.Show("Projekcija je uspešno obrisana.", "Uspeh",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshProjekcije();
                    }
                    else
                    {
                        MessageBox.Show("Došlo je do greške prilikom brisanja projekcije.", "Greška",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
