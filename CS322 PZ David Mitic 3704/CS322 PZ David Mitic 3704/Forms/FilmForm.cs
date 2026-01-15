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
    public partial class FilmForm : Form
    {
        private DBHelper dBHelper;
        private List<Film> films;

        public FilmForm()
        {
            InitializeComponent();
            dBHelper = new DBHelper();
            loadFilmovi();
        }

        private void FilmForm_Load(object sender, EventArgs e)
        {
        }

        private void loadFilmovi()
        {
            films = dBHelper.GetFilmovi();
            filmoviDataGridView.DataSource = films;
            filmoviDataGridView.Refresh();
            AdjustDataGridViewHeight();
        }

        private void AdjustDataGridViewHeight()
        {
            filmoviDataGridView.PerformLayout();

            if (filmoviDataGridView.Rows.Count == 0)
            {
                filmoviDataGridView.Height = filmoviDataGridView.ColumnHeadersHeight + 50;
                return;
            }

            int rowsToShow = Math.Min(filmoviDataGridView.Rows.Count, 5);

            var previousAutoSizeMode = filmoviDataGridView.AutoSizeRowsMode;
            filmoviDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            int rowHeight = 0;
            if (filmoviDataGridView.Rows[0].Height > 0)
            {
                rowHeight = filmoviDataGridView.Rows[0].Height;
            }
            else
            {
                rowHeight = filmoviDataGridView.RowTemplate.Height > 0 ?
                           filmoviDataGridView.RowTemplate.Height : 22;
            }

            int totalHeight = filmoviDataGridView.ColumnHeadersHeight;

            for (int i = 0; i < rowsToShow; i++)
            {
                totalHeight += rowHeight;
            }

            totalHeight += 2;

            if (filmoviDataGridView.Rows.Count > 5)
            {
                totalHeight += SystemInformation.HorizontalScrollBarHeight;
                filmoviDataGridView.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                filmoviDataGridView.ScrollBars = ScrollBars.None;
            }

            filmoviDataGridView.Height = totalHeight;
            filmoviDataGridView.AutoSizeRowsMode = previousAutoSizeMode;
        }

        private void filmoviDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void filmoviDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void filmoviDataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (filmoviDataGridView.SelectedRows.Count > 0)
            {
                var selectedFilm = filmoviDataGridView.SelectedRows[0].DataBoundItem as Film;
                addOrUpdateBtn.Text = "Azuriraj";
                if (selectedFilm != null)
                {
                    naslovTextBox.Text = selectedFilm.Naslov;
                    zanrTextBox.Text = selectedFilm.Zanr;
                    trajanjeTextBox.Text = selectedFilm.Trajanje.ToString();
                    opisTextBox.Text = selectedFilm.Opis;
                    urlTxtBox.Text = selectedFilm.SlikaURL;
                    addOrUpdateBtn.Text = "Azuriraj";
                }
            }
            else
            {
                naslovTextBox.Clear();
                zanrTextBox.Clear();
                trajanjeTextBox.Clear();
                opisTextBox.Clear();
                urlTxtBox.Clear();
                addOrUpdateBtn.Text = "Dodaj";
            }
        }

        private void addOrUpdateBtn_Click(object sender, EventArgs e)
        {
            if (filmoviDataGridView.SelectedRows.Count > 0)
            {
                var selectedFilm = filmoviDataGridView.SelectedRows[0].DataBoundItem as Film;
                if (selectedFilm != null)
                {
                    selectedFilm.Naslov = naslovTextBox.Text;
                    selectedFilm.Zanr = zanrTextBox.Text;
                    selectedFilm.Trajanje = int.Parse(trajanjeTextBox.Text);
                    selectedFilm.Opis = opisTextBox.Text;
                    selectedFilm.SlikaURL = urlTxtBox.Text;
                    dBHelper.UpdateFilm(selectedFilm);
                }
            }
            else
            {
                Film newFilm = new Film
                {
                    Naslov = naslovTextBox.Text,
                    Zanr = zanrTextBox.Text,
                    Trajanje = int.Parse(trajanjeTextBox.Text),
                    Opis = opisTextBox.Text,
                    SlikaURL = urlTxtBox.Text
                };
                dBHelper.AddFilm(newFilm);
            }

            filmoviDataGridView.DataSource = null; 
            filmoviDataGridView.Refresh();
            loadFilmovi();
        }

        private void trajanjeTextBox_TextChanged(object sender, EventArgs e)
        {
            if(trajanjeTextBox.TextLength > 0)
            {
                if(!int.TryParse(trajanjeTextBox.Text, out _))
                {
                    MessageBox.Show("Molimo unesite validan broj za trajanje filma.", "Nevalidan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    trajanjeTextBox.Clear();
                }
            }
        }
    }
}