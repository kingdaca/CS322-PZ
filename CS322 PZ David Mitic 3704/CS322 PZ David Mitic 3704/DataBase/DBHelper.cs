using CS322_PZ_David_Mitic_3704.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CS322_PZ_David_Mitic_3704.DataBase
{
    internal class DBHelper
    {
        private string connectionString;

        public DBHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BioskopConnection"].ConnectionString;
        }


        public Korisnik Login(string email, string lozinka)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Korisnici WHERE Email=@Email AND Lozinka=@Lozinka";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Lozinka", lozinka);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Korisnik
                        {
                            KorisnikID = (int)reader["KorisnikID"],
                            Ime = reader["Ime"].ToString(),
                            Prezime = reader["Prezime"].ToString(),
                            Email = reader["Email"].ToString(),
                            JeAdmin = (bool)reader["JeAdmin"]
                        };
                    }
                }

                conn.Close();
            }

            return null;
        }

        public List<Projekcija> GetProjekcije()
        {
            List<Projekcija> projekcije = new List<Projekcija>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT p.*, f.Naslov as FilmNaslov, s.Naziv as SalaNaziv
                               FROM Projekcije p
                               JOIN Filmovi f ON p.FilmID = f.FilmID
                               JOIN Sale s ON p.SalaID = s.SalaID
                               ORDER BY p.DatumVreme";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    projekcije.Add(new Projekcija
                    {
                        ProjekcijaID = (int)reader["ProjekcijaID"],
                        FilmID = (int)reader["FilmID"],
                        SalaID = (int)reader["SalaID"],
                        DatumVreme = (DateTime)reader["DatumVreme"],
                        CenaKarte = (decimal)reader["CenaKarte"],
                        FilmNaslov = reader["FilmNaslov"].ToString(),
                        SalaNaziv = reader["SalaNaziv"].ToString()
                    });
                }
            }

            return projekcije;
        }
    }
}
