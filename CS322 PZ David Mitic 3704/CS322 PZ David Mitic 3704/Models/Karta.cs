using System;
using System.Collections.Generic;
using System.Text;

namespace CS322_PZ_David_Mitic_3704.Models
{
    public class Karta
    {
        public int KartaID { get; set; }
        public int ProjekcijaID { get; set; }
        public int KorisnikID { get; set; }
        public int Red { get; set; }
        public int Kolona { get; set; }
        public DateTime DatumKupovine { get; set; }
        public string Status { get; set; }
        public string FilmNaslov { get; set; }
        public DateTime DatumProjekcije { get; set; }
        public string SalaNaziv { get; set; }
    }
}
