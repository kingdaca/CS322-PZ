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
            }

            return null;
        }
    }
}
