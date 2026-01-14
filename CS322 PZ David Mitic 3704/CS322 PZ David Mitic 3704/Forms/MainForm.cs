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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadProjekcije()
        {
            // Ako DataGridView još nema kolone, dodajemo ih
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("ProjekcijaID", "ID");
                dataGridView1.Columns.Add("FilmNaslov", "Film");
                dataGridView1.Columns.Add("DatumVreme", "Datum i vreme");
                dataGridView1.Columns.Add("SalaNaziv", "Sala");
                dataGridView1.Columns.Add("CenaKarte", "Cena");

                // Redovi rastu po visini
                dataGridView1.RowTemplate.Height = 40;

                // Automatski rasporedi širinu kolona da popune kontrolu
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Odredi proporcionalnu širinu svake kolone
                dataGridView1.Columns[0].FillWeight = 20;  // ID
                dataGridView1.Columns[1].FillWeight = 60;  // Film
                dataGridView1.Columns[2].FillWeight = 60;  // Datum i vreme
                dataGridView1.Columns[3].FillWeight = 40;  // Sala
                dataGridView1.Columns[4].FillWeight = 30;  // Cena

                // Dozvoli scroll ako ima više od 5 redova
                dataGridView1.ScrollBars = ScrollBars.Vertical;
            }

            // Očisti postojeće redove
            dataGridView1.Rows.Clear();

            List<Projekcija> projekcije = dBHelper.GetProjekcije();
            if (projekcije == null) return;

            // Dodaj sve redove (neograničeno)
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

            // Podesi visinu DataGridView-a da stane maksimalno 5 redova bez scroll-a
            int headerHeight = dataGridView1.ColumnHeadersHeight;
            int rowHeight = dataGridView1.RowTemplate.Height;
            int rowsToShowWithoutScroll = Math.Min(5, dataGridView1.Rows.Count);
            dataGridView1.Height = headerHeight + (rowHeight * rowsToShowWithoutScroll) + 2;

            // Onemogući dodavanje/redigovanje redova od strane korisnika
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
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
    }
}
