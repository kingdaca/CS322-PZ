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
    public partial class RezervacijeForm : Form
    {

        private int projekcijaID;
        private int korisnikID;
        private DBHelper dbHelper;
        private List<Button> sedistaButtons;
        private List<Tuple<int, int>> izabranaSedista;
        private Sala sala;

        public RezervacijeForm()
        {
            InitializeComponent();
        }

        public RezervacijeForm(int projekcijaID, Korisnik korisnik) : this()
        {
            this.projekcijaID = projekcijaID;
            this.korisnikID = korisnik.KorisnikID;
            dbHelper = new DBHelper();
            sedistaButtons = new List<Button>();
            izabranaSedista = new List<Tuple<int, int>>();
            this.sala = dbHelper.GetSalaByProjekcijaID(projekcijaID);

            InitSala();
            LoadZauzetaSedista();
        }

        private void RezervacijeForm_Load(object sender, EventArgs e)
        {

        }

        private void InitSala()
        {
            flpSala.Controls.Clear();
            sedistaButtons.Clear();

            int buttonWidth = 42;
            int margin = 2;

            // širina = (širina dugmeta + lijeva + desna margina) * broj kolona
            flpSala.Width = sala.Kolone * (buttonWidth + margin * 4);

            // opciono: spriječi automatsko lomljenje reda
            flpSala.WrapContents = true;
            flpSala.AutoScroll = true;

            for (int red = 1; red <= sala.Redovi; red++)
            {
                for (int kolona = 1; kolona <= sala.Kolone; kolona++)
                {
                    Button btnSediste = new Button
                    {
                        Text = $"{red}-{kolona}",
                        Tag = new Tuple<int, int>(red, kolona),
                        Size = new Size(buttonWidth, 42),
                        Margin = new Padding(margin),
                        BackColor = Color.LightGray,
                        Font = new Font("Arial", 8)
                    };

                    btnSediste.Click += BtnSediste_Click;
                    flpSala.Controls.Add(btnSediste);
                    sedistaButtons.Add(btnSediste);
                }
            }
        }


        private void LoadZauzetaSedista()
        {
            var zauzetaMesta = dbHelper.GetZauzetaMesta(projekcijaID);

            foreach (var sediste in sedistaButtons)
            {
                var pozicija = (Tuple<int, int>)sediste.Tag;

                if (zauzetaMesta.Contains(pozicija))
                {
                    sediste.BackColor = Color.Red;
                    sediste.Enabled = false;
                    sediste.Text = "X";
                }
            }
        }

        private void BtnSediste_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var pozicija = (Tuple<int, int>)btn.Tag;

            if (btn.BackColor == Color.Green)
            {
                // Deselekcija
                btn.BackColor = Color.LightGray;
                izabranaSedista.Remove(pozicija);
            }
            else
            {
                // Selekcija
                if (izabranaSedista.Count >= 6)
                {
                    MessageBox.Show("Maksimalno možete izabrati 6 sedišta!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                btn.BackColor = Color.Green;
                izabranaSedista.Add(pozicija);
            }

            UpdateIzabranaSedistaLabel();
        }

        private void UpdateIzabranaSedistaLabel()
        {
            if (izabranaSedista.Count == 0)
            {
                lblIzabranaSedista.Text = "Izaberite sedišta";
                return;
            }

            string text = "Izabrana sedišta: ";
            foreach (var sediste in izabranaSedista)
            {
                text += $"{sediste.Item1}-{sediste.Item2}, ";
            }
            lblIzabranaSedista.Text = text.TrimEnd(',', ' ');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (izabranaSedista.Count == 0)
            {
                MessageBox.Show("Izaberite bar jedno sedište!", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = true;
            List<int> rezervisaneKarte = new List<int>();

            foreach (var sediste in izabranaSedista)
            {
                int kartaID = dbHelper.RezervisiKartu(
                    projekcijaID, korisnikID, sediste.Item1, sediste.Item2);

                if (kartaID == -1)
                {
                    success = false;
                    MessageBox.Show($"Sedište {sediste.Item1}-{sediste.Item2} je već zauzeto!",
                        "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                rezervisaneKarte.Add(kartaID);
            }

            if (success)
            {
                MessageBox.Show($"Uspešno ste rezervisali {izabranaSedista.Count} karata!",
                    "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Generisanje PDF karte (simulirano)
                GenerisiPDFKartu(rezervisaneKarte);

                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void GenerisiPDFKartu(List<int> karteIDs)
        {
            // Simulacija generisanja PDF-a
            string poruka = "PDF karta je generisana!\n\n";
            poruka += $"Korisnik: {korisnikID}\n";
            poruka += $"Broj karata: {karteIDs.Count}\n";
            poruka += $"Datum: {DateTime.Now:dd.MM.yyyy HH:mm}\n";

            MessageBox.Show(poruka, "PDF Karta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();   
        }
    }
}


