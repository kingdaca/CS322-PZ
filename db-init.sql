-- 1. Kreiranje baze podataka (ako ne postoji)
CREATE DATABASE IF NOT EXISTS BioskopDB;
USE BioskopDB;

-- 2. Tabele
CREATE TABLE Filmovi (
    FilmID INT PRIMARY KEY AUTO_INCREMENT,
    Naslov VARCHAR(100) NOT NULL,
    Zanr VARCHAR(50),
    Trajanje INT, -- u minutima
    Opis TEXT,
    SlikaURL VARCHAR(200)
) ENGINE=InnoDB;

CREATE TABLE Sale (
    SalaID INT PRIMARY KEY AUTO_INCREMENT,
    Naziv VARCHAR(50) NOT NULL,
    BrojSedista INT NOT NULL,
    Redovi INT NOT NULL,
    Kolone INT NOT NULL
) ENGINE=InnoDB;

CREATE TABLE Projekcije (
    ProjekcijaID INT PRIMARY KEY AUTO_INCREMENT,
    FilmID INT,
    SalaID INT,
    DatumVreme DATETIME NOT NULL,
    CenaKarte DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (FilmID) REFERENCES Filmovi(FilmID) ON DELETE CASCADE,
    FOREIGN KEY (SalaID) REFERENCES Sale(SalaID) ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE Korisnici (
    KorisnikID INT PRIMARY KEY AUTO_INCREMENT,
    Ime VARCHAR(50) NOT NULL,
    Prezime VARCHAR(50) NOT NULL,
    Username VARCHAR(100) UNIQUE NOT NULL,
    Lozinka VARCHAR(100) NOT NULL,
    JeAdmin TINYINT(1) DEFAULT 0
) ENGINE=InnoDB;

CREATE TABLE Karte (
    KartaID INT PRIMARY KEY AUTO_INCREMENT,
    ProjekcijaID INT,
    KorisnikID INT,
    Red INT NOT NULL,
    Kolona INT NOT NULL,
    DatumKupovine DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status VARCHAR(20) DEFAULT 'rezervisano', -- rezervisano/placeno/otkazano
    FOREIGN KEY (ProjekcijaID) REFERENCES Projekcije(ProjekcijaID) ON DELETE CASCADE,
    FOREIGN KEY (KorisnikID) REFERENCES Korisnici(KorisnikID) ON DELETE CASCADE
) ENGINE=InnoDB;

-- 3. Test podaci
INSERT INTO Filmovi (Naslov, Zanr, Trajanje, Opis) VALUES
('Avatar 2', 'Akcija', 192, 'Nastavak popularnog filma'),
('Oppenheimer', 'Drama', 180, 'Biografski film o Robertu Oppenheimeru'),
('Barbie', 'Komedija', 114, 'Komedija o Barbie i Kenu');

INSERT INTO Sale (Naziv, BrojSedista, Redovi, Kolone) VALUES
('Sala 1', 100, 10, 10),
('Sala 2', 80, 8, 10),
('VIP Sala', 50, 5, 10);

INSERT INTO Projekcije (FilmID, SalaID, DatumVreme, CenaKarte) VALUES
(1, 1, '2024-06-15 20:00:00', 550.00),
(2, 2, '2024-06-15 18:00:00', 600.00),
(3, 1, '2024-06-16 19:00:00', 500.00);

INSERT INTO Korisnici (Ime, Prezime, Username, Lozinka, JeAdmin) VALUES
('Admin', 'Admin', 'admin', 'admin123', 1),
('Pera', 'Perić', 'pera', 'pera123', 0);

-- 4. Dodatni indeksi za bolju performansu
CREATE INDEX idx_projekcije_datum ON Projekcije(DatumVreme);
CREATE INDEX idx_karte_status ON Karte(Status);
CREATE INDEX idx_korisnici_username ON Korisnici(Username);

-- 5. Stored Procedure za rezervaciju karte (opcionalno)
DELIMITER $$

CREATE PROCEDURE RezervisiKartu(
    IN p_projekcija_id INT,
    IN p_korisnik_id INT,
    IN p_red INT,
    IN p_kolona INT,
    OUT p_karta_id INT,
    OUT p_status VARCHAR(50)
)
BEGIN
    DECLARE zauzeto INT DEFAULT 0;
    
    -- Provera da li je mesto već zauzeto
    SELECT COUNT(*) INTO zauzeto
    FROM Karte
    WHERE ProjekcijaID = p_projekcija_id 
      AND Red = p_red 
      AND Kolona = p_kolona 
      AND Status IN ('rezervisano', 'placeno');
    
    IF zauzeto > 0 THEN
        SET p_karta_id = -1;
        SET p_status = 'Mesto je već zauzeto';
    ELSE
        -- Rezervacija karte
        INSERT INTO Karte (ProjekcijaID, KorisnikID, Red, Kolona, Status)
        VALUES (p_projekcija_id, p_korisnik_id, p_red, p_kolona, 'rezervisano');
        
        SET p_karta_id = LAST_INSERT_ID();
        SET p_status = 'Uspešno rezervisano';
    END IF;
END$$

DELIMITER ;

-- 6. View za pregled projekcija sa filmovima i salama (opcionalno)
CREATE VIEW ProjekcijePrikaz AS
SELECT 
    p.ProjekcijaID,
    f.Naslov AS FilmNaslov,
    f.Zanr,
    f.Trajanje,
    s.Naziv AS SalaNaziv,
    s.Redovi,
    s.Kolone,
    p.DatumVreme,
    p.CenaKarte,
    (s.BrojSedista - COUNT(k.KartaID)) AS SlobodnaMesta
FROM Projekcije p
JOIN Filmovi f ON p.FilmID = f.FilmID
JOIN Sale s ON p.SalaID = s.SalaID
LEFT JOIN Karte k ON p.ProjekcijaID = k.ProjekcijaID AND k.Status IN ('rezervisano', 'placeno')
GROUP BY p.ProjekcijaID;

-- 7. Trigger za automatsko ažuriranje broja zauzetih mesta (opcionalno)
DELIMITER $$

CREATE TRIGGER after_karta_insert
AFTER INSERT ON Karte
FOR EACH ROW
BEGIN
    -- Možete dodati logiku za ažuriranje statistike ili slanje notifikacija
    -- Na primer, logovanje rezervacije u posebnu tabelu
    INSERT INTO LogRezervacije (KartaID, KorisnikID, VremeLoga)
    VALUES (NEW.KartaID, NEW.KorisnikID, NOW());
END$$

DELIMITER ;

-- 8. Tabela za logovanje (ako koristite trigger)
CREATE TABLE IF NOT EXISTS LogRezervacije (
    LogID INT PRIMARY KEY AUTO_INCREMENT,
    KartaID INT,
    KorisnikID INT,
    VremeLoga DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;