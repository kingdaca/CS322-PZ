using System;
using System.Collections.Generic;
using System.Text;

namespace CS322_PZ_David_Mitic_3704.Models
{
    public class Projekcija
    {
        public int ProjekcijaID { get; set; }
        public int FilmID { get; set; }
        public int SalaID { get; set; }
        public DateTime DatumVreme { get; set; }
        public decimal CenaKarte { get; set; }
        public string FilmNaslov { get; set; }
        public string SalaNaziv { get; set; }
        public int BrojSlobodnihMesta { get; set; }
    }
}
