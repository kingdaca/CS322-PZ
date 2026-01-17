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

        // CRUD za Filmove
        public List<Film> GetFilmovi()
        {
            List<Film> filmovi = new List<Film>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Filmovi";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    filmovi.Add(new Film
                    {
                        FilmID = Convert.ToInt32(reader["FilmID"]),
                        Naslov = reader["Naslov"].ToString(),
                        Zanr = reader["Zanr"].ToString(),
                        Trajanje = Convert.ToInt32(reader["Trajanje"]),
                        Opis = reader["Opis"].ToString(),
                        SlikaURL = reader["SlikaURL"]?.ToString()
                    });
                }
            }

            return filmovi;
        }

        public int AddFilm(Film film)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"INSERT INTO Filmovi (Naslov, Zanr, Trajanje, Opis, SlikaURL)
                             VALUES (@Naslov, @Zanr, @Trajanje, @Opis, @SlikaURL);
                             SELECT LAST_INSERT_ID();";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Naslov", film.Naslov);
                cmd.Parameters.AddWithValue("@Zanr", film.Zanr);
                cmd.Parameters.AddWithValue("@Trajanje", film.Trajanje);
                cmd.Parameters.AddWithValue("@Opis", film.Opis);
                cmd.Parameters.AddWithValue("@SlikaURL", film.SlikaURL ?? (object)DBNull.Value);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool UpdateFilm(Film film)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"UPDATE Filmovi 
                             SET Naslov=@Naslov, Zanr=@Zanr, Trajanje=@Trajanje,
                                 Opis=@Opis, SlikaURL=@SlikaURL
                             WHERE FilmID=@FilmID";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FilmID", film.FilmID);
                cmd.Parameters.AddWithValue("@Naslov", film.Naslov);
                cmd.Parameters.AddWithValue("@Zanr", film.Zanr);
                cmd.Parameters.AddWithValue("@Trajanje", film.Trajanje);
                cmd.Parameters.AddWithValue("@Opis", film.Opis);
                cmd.Parameters.AddWithValue("@SlikaURL", film.SlikaURL ?? (object)DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteFilm(int filmID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Filmovi WHERE FilmID=@FilmID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FilmID", filmID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // CRUD za Projekcije
        public List<Projekcija> GetProjekcije()
        {
            List<Projekcija> projekcije = new List<Projekcija>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT p.*, f.Naslov AS FilmNaslov, s.Naziv AS SalaNaziv
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
                        ProjekcijaID = Convert.ToInt32(reader["ProjekcijaID"]),
                        FilmID = Convert.ToInt32(reader["FilmID"]),
                        SalaID = Convert.ToInt32(reader["SalaID"]),
                        DatumVreme = Convert.ToDateTime(reader["DatumVreme"]),
                        CenaKarte = Convert.ToDecimal(reader["CenaKarte"]),
                        FilmNaslov = reader["FilmNaslov"].ToString(),
                        SalaNaziv = reader["SalaNaziv"].ToString()
                    });
                }
            }

            return projekcije;
        }

        // Login
        public Korisnik Login(string username, string lozinka)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Korisnici 
                             WHERE Username=@Username AND Lozinka=@Lozinka";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Lozinka", lozinka);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Korisnik
                    {
                        KorisnikID = Convert.ToInt32(reader["KorisnikID"]),
                        Ime = reader["Ime"].ToString(),
                        Prezime = reader["Prezime"].ToString(),
                        Username = reader["Username"].ToString(),
                        JeAdmin = Convert.ToBoolean(reader["JeAdmin"])
                    };
                }
            }

            return null;
        }

        // Rezervacija karte
        public int RezervisiKartu(int projekcijaID, int korisnikID, int red, int kolona)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string checkQuery = @"SELECT COUNT(*) FROM Karte
                                  WHERE ProjekcijaID=@ProjekcijaID
                                  AND Red=@Red AND Kolona=@Kolona
                                  AND Status IN ('rezervisano','placeno')";

                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@ProjekcijaID", projekcijaID);
                checkCmd.Parameters.AddWithValue("@Red", red);
                checkCmd.Parameters.AddWithValue("@Kolona", kolona);

                conn.Open();
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                    return -1;

                string insertQuery = @"INSERT INTO Karte (ProjekcijaID, KorisnikID, Red, Kolona, Status)
                                   VALUES (@ProjekcijaID, @KorisnikID, @Red, @Kolona, 'rezervisano');
                                   SELECT LAST_INSERT_ID();";

                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@ProjekcijaID", projekcijaID);
                cmd.Parameters.AddWithValue("@KorisnikID", korisnikID);
                cmd.Parameters.AddWithValue("@Red", red);
                cmd.Parameters.AddWithValue("@Kolona", kolona);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Zauzeta mesta
        public List<Tuple<int, int>> GetZauzetaMesta(int projekcijaID)
        {
            List<Tuple<int, int>> zauzetaMesta = new List<Tuple<int, int>>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT Red, Kolona FROM Karte
                             WHERE ProjekcijaID=@ProjekcijaID
                             AND Status IN ('rezervisano','placeno')";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProjekcijaID", projekcijaID);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    zauzetaMesta.Add(new Tuple<int, int>(
                        Convert.ToInt32(reader["Red"]),
                        Convert.ToInt32(reader["Kolona"])
                    ));
                }
            }

            return zauzetaMesta;
        }

        public List<Sala> GetSale()
        {
            List<Sala> sale = new List<Sala>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Sale";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sale.Add(new Sala
                    {
                        SalaID = Convert.ToInt32(reader["SalaID"]),
                        Naziv = reader["Naziv"].ToString(),
                    });
                }
            }
            return sale;
        }

        public Film GetFilmByNaslov(string naslov)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Filmovi WHERE Naslov=@Naslov";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Naslov", naslov);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Film
                    {
                        FilmID = Convert.ToInt32(reader["FilmID"]),
                        Naslov = reader["Naslov"].ToString(),
                        Zanr = reader["Zanr"].ToString(),
                        Trajanje = Convert.ToInt32(reader["Trajanje"]),
                        Opis = reader["Opis"].ToString(),
                        SlikaURL = reader["SlikaURL"]?.ToString()
                    };
                }
            }
            return null;
        }

        public Sala GetSalaByNaziv(string naziv)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Sale WHERE Naziv=@Naziv";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Naziv", naziv);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Sala
                    {
                        SalaID = Convert.ToInt32(reader["SalaID"]),
                        Naziv = reader["Naziv"].ToString(),
                    };
                }
            }
            return null;
        }

        public void addProjekcija(Projekcija projekcija)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"INSERT INTO Projekcije (FilmID, SalaID, DatumVreme, CenaKarte)
                             VALUES (@FilmID, @SalaID, @DatumVreme, @CenaKarte);";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FilmID", projekcija.FilmID);
                cmd.Parameters.AddWithValue("@SalaID", projekcija.SalaID);
                cmd.Parameters.AddWithValue("@DatumVreme", projekcija.DatumVreme);
                cmd.Parameters.AddWithValue("@CenaKarte", projekcija.CenaKarte);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool deleteProjekcija(int projekcijaID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Projekcije WHERE ProjekcijaID=@ProjekcijaID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProjekcijaID", projekcijaID);
                conn.Open();
                if(cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }
    }
}
