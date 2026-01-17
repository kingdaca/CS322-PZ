using System;
using System.Collections.Generic;
using System.Text;

namespace CS322_PZ_David_Mitic_3704.Models
{
    public class Korisnik
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Lozinka { get; set; }
        public bool JeAdmin { get; set; }

        public override string ToString()
        {
            return $"{Ime} {Prezime} ({Username}) - Admin: {JeAdmin}";
        }
    }
}
