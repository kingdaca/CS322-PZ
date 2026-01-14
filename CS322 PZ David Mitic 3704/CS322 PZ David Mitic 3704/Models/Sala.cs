using CS322_PZ_David_Mitic_3704.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS322_PZ_David_Mitic_3704.Models
{
    public class Sala
    {
        public int SalaID { get; set; }
        public string Naziv { get; set; }
        public int BrojSedista { get; set; }
        public int Redovi { get; set; }
        public int Kolone { get; set; }

        // Metoda za proveru validnosti sedišta
        public bool IsValidSediste(int red, int kolona)
        {
            return red >= 1 && red <= Redovi && kolona >= 1 && kolona <= Kolone;
        }

        //// Metoda za dobijanje broja slobodnih mesta (treba projekcijaID za proveru)
        //public int GetBrojSlobodnihMesta(int projekcijaID, DBHelper dbHelper)
        //{
        //    var zauzetaMesta = dbHelper.GetZauzetaMesta(projekcijaID);
        //    return BrojSedista - zauzetaMesta.Count;
        //}
    }
}
