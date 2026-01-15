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
    public partial class ProjekcijeForm : Form
    {
        private DBHelper dBHelper;
        private MainForm mainForm;
        public ProjekcijeForm()
        {
            InitializeComponent();
            dBHelper = new DBHelper();
            loadComboBox();
        }

        public ProjekcijeForm(MainForm mf) : this()
        {
           mainForm = mf;
        }

        private void ProjekcijeForm_Load(object sender, EventArgs e)
        {

        }

        private void filmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loadComboBox()
        {
            List<string> filmoviNazivi = new List<string>();
            List<Film> filmovi = dBHelper.GetFilmovi();

            filmovi.ForEach(f => filmoviNazivi.Add(f.Naslov));

            filmComboBox.DataSource = filmoviNazivi;

            List<Sala> sale = dBHelper.GetSale();
            List<string> saleNazivi = new List<string>();
            sale.ForEach(s => saleNazivi.Add(s.Naziv));
            salaComboBox.DataSource = saleNazivi;

            List<string> vreme = new List<string>();

            for (int hour = 0; hour < 24; hour++)
            {
                for (int minute = 0; minute < 60; minute += 30)
                {
                    string time = $"{hour:D2}:{minute:D2}";
                    vreme.Add(time);
                }
            }

            vremeComboBox.DataSource = vreme;

        }

        private void dodajProjekciju_Click(object sender, EventArgs e)
        {
            if (filmComboBox.SelectedItem == null || salaComboBox.SelectedItem == null || vremeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Nisu uneti svi podaci");
                return;
            }
            else
            {
                string izabraniFilm = filmComboBox.SelectedItem.ToString();
                string izabranaSala = salaComboBox.SelectedItem.ToString();
                Film film = dBHelper.GetFilmByNaslov(izabraniFilm);
                Sala sala = dBHelper.GetSalaByNaziv(izabranaSala);
                if (film == null || sala == null)
                {
                    MessageBox.Show("Doslo je do greske prilikom dohvatanja filma ili sale.");
                    return;
                }
                Projekcija novaProjekcija = new Projekcija
                {
                    FilmID = film.FilmID,
                    SalaID = sala.SalaID,
                    DatumVreme = dateTimePicker1.Value.Date + TimeSpan.Parse(vremeComboBox.SelectedItem.ToString()),
                    CenaKarte = decimal.Parse(cenaTextBox.Text),

                };
                dBHelper.addProjekcija(novaProjekcija);
                MessageBox.Show("Uspesno dodata projekcija.");
                mainForm.refreshProjekcije();
                this.Close();

            }
        }

        private void cenaTextBox_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cenaTextBox.Text))
            {
                if (!decimal.TryParse(cenaTextBox.Text, out _))
                {
                    MessageBox.Show("Cena mora biti broj.");
                    cenaTextBox.Text = string.Empty;
                }
            }
        }
    }
}
