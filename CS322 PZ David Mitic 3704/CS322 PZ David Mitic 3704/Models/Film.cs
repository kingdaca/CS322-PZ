using System;
using System.Collections.Generic;
using System.Text;

namespace CS322_PZ_David_Mitic_3704.Models
{
        public class Film
        {
            public int FilmID { get; set; }
            public string Naslov { get; set; }
            public string Zanr { get; set; }
            public int Trajanje { get; set; }
            public string Opis { get; set; }
            public string SlikaURL { get; set; }
        }
 
}
