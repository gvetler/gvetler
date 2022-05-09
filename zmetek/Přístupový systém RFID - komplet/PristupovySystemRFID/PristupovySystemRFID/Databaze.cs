using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PristupovySystemRFID
{
    class Databaze
    {
        private static SQLiteConnection databaze = new SQLiteConnection();
        public static void vytvoreniDatabaze()
        {

            try
            {
                databaze.ConnectionString = "Data Source=data.sqlite";
                databaze.Open();
            }
            catch { }
            

            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);

            List<string> prikazy = new List<string>();
            prikazy.Add("CREATE TABLE IF NOT EXISTS uzivatele (id_uzivatele INTEGER PRIMARY KEY AUTOINCREMENT, jmeno VARCHAR(50), prijmeni VARCHAR(50), cislo_cipu INTEGER UNIQUE, ciselny_kod INTEGER UNIQUE, UNIQUE(jmeno, prijmeni))");
            prikazy.Add("CREATE TABLE IF NOT EXISTS skupiny (id_skupiny INTEGER PRIMARY KEY AUTOINCREMENT, nazev VARCHAR(50) UNIQUE)");
            prikazy.Add("CREATE TABLE IF NOT EXISTS uzivatelske_skupiny(id_skupiny INTEGER, cislo_dveri INT, den INT, pocatecni_hodnota VARCHAR(30), konecna_hodnota VARCHAR(30), FOREIGN KEY(id_skupiny) REFERENCES skupiny(id_skupiny), UNIQUE (id_skupiny, pocatecni_hodnota, konecna_hodnota, den, cislo_dveri))");
            prikazy.Add("CREATE TABLE IF NOT EXISTS vazebni_tabulka(id_uzivatele INT, id_skupiny INT, FOREIGN KEY(id_uzivatele) REFERENCES uzivatele(id_uzivatele), FOREIGN KEY(id_skupiny) REFERENCES skupiny(id_skupiny), UNIQUE(id_uzivatele, id_skupiny))");
            prikazy.Add("CREATE TABLE IF NOT EXISTS pristupy_uzivatelu(id_uzivatele INT, datum VARCHAR(30), cas TIME, cislo_dveri INT, pristup_udelen BOOLEAN, FOREIGN KEY(id_uzivatele) REFERENCES uzivatele(id_uzivatele))");

            foreach (string prikaz in prikazy)
            {
                sqPrikaz.CommandText = prikaz;

                try
                {
                    sqPrikaz.ExecuteNonQuery();
                }

                catch (Exception error)
                {
                    MessageBox.Show("Vyskytla se chyba:" + Environment.NewLine + error.Message);
                }
            }
        }

        public static List<string> nacistNazvySkupin()
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "SELECT nazev FROM skupiny ORDER BY id_skupiny ASC";
            SQLiteDataReader reader = sqPrikaz.ExecuteReader();
            List<string> seznamSkupin = new List<string>();
            while (reader.Read())
            {
                seznamSkupin.Add(reader["nazev"].ToString());
            }
            return seznamSkupin;
        }

        public static List<string> nacistUzivatele()
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "SELECT jmeno, prijmeni FROM uzivatele ORDER BY jmeno ASC";
            SQLiteDataReader reader = sqPrikaz.ExecuteReader();
            List<string> seznamJmen = new List<string>();
            while (reader.Read())
            {
                seznamJmen.Add(reader["jmeno"].ToString() + " " + reader["prijmeni"].ToString());
            }
            return seznamJmen;
        }

        public static string zaevidovatNazevNoveSkupiny(string nazevSkupiny)
        {

            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "INSERT INTO skupiny (nazev) VALUES ('" + nazevSkupiny + "')";
            string navratovaHodnota = "";
            try
            {
                sqPrikaz.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                navratovaHodnota = error.Message;
                return navratovaHodnota;
            }

            sqPrikaz.CommandText = "SELECT id_skupiny FROM skupiny WHERE nazev = '" + nazevSkupiny + "'";
            SQLiteDataReader reader = sqPrikaz.ExecuteReader();
            while(reader.Read())
            {
                navratovaHodnota = reader["id_skupiny"].ToString();
                return navratovaHodnota;
            }

            return navratovaHodnota;
        }
        
        public static bool vlozitNovePravidlo(int idSkupiny, int cisloDveri, int den, string pocatecniHodnota, string koncovaHodnota)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "INSERT INTO uzivatelske_skupiny (id_skupiny, cislo_dveri, den, pocatecni_hodnota, konecna_hodnota) VALUES (" + idSkupiny + ", " + cisloDveri + ", " + den + ", '" + pocatecniHodnota + "', '" + koncovaHodnota + "')";
            try
            {
                sqPrikaz.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("Vyskytla se chyba:" + Environment.NewLine + error.Message);
                return false;
            }
            return true;
        }

        public static bool vymazatSkupinu(string nazevSkupiny)
        {   
            int idSkupiny = zjistitIDSkupiny(nazevSkupiny);
            if(idSkupiny == -1)
            {
                return false;
            }

            List<string> prikazy = new List<string>();
            prikazy.Add("DELETE FROM uzivatelske_skupiny WHERE id_skupiny = " + idSkupiny);
            prikazy.Add("DELETE FROM vazebni_tabulka WHERE id_skupiny = " + idSkupiny);
            prikazy.Add("DELETE FROM skupiny WHERE id_skupiny = " + idSkupiny);

            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            foreach (string prikaz in prikazy)
            {
                sqPrikaz.CommandText = prikaz;

                try
                {
                    sqPrikaz.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Vyskytla se chyba:" + Environment.NewLine + error.Message);
                    return false;
                }
            }
            
            return true;
        }

        public static int zjistitIDSkupiny(string nazevSkupiny)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "SELECT id_skupiny FROM skupiny WHERE nazev = '" + nazevSkupiny + "'";
            SQLiteDataReader reader = sqPrikaz.ExecuteReader();
            int idSkupiny = -1;
            while (reader.Read())
            {
                try
                {
                    idSkupiny = int.Parse(reader["id_skupiny"].ToString());
                }
                catch
                {
                    MessageBox.Show("Vyskytla se neočekáváná chyba");
                    return -1;
                }
            }
            reader.Close();
            return idSkupiny;
        }

        public static bool vytvoritUzivatele(string jmeno, string prijmeni, int cisloCipu, int ciselnyKod)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "INSERT INTO uzivatele (jmeno, prijmeni, cislo_cipu, ciselny_kod) VALUES ('" + jmeno + "', '" + prijmeni + "', " + cisloCipu + ", " + ciselnyKod + ")";
            try
            {
                sqPrikaz.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("Vyskytla se chyba:" + Environment.NewLine + error.Message);
                return false;
            }
            return true;
        }

        public static List<string> nacistPrirazeneSkupinyUzivateli(string jmenoUzivatele, string prijmeniUzivatele)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);

            sqPrikaz.CommandText = "SELECT nazev FROM skupiny WHERE id_skupiny IN (SELECT id_skupiny FROM vazebni_tabulka WHERE id_uzivatele = (SELECT id_uzivatele FROM uzivatele WHERE jmeno = '" + jmenoUzivatele + "' AND prijmeni = '" + prijmeniUzivatele + "'))";
            SQLiteDataReader reader = sqPrikaz.ExecuteReader();

            List<string> navratovaHodnota = new List<string>();

            while (reader.Read())
            {
                navratovaHodnota.Add(reader["nazev"].ToString());
            }
            reader.Close();
            return navratovaHodnota;
        }

        public static List<string> nacistNeprirazeneSkupinyUzivateli(string jmenoUzivatele, string prijmeniUzivatele)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "SELECT nazev FROM skupiny WHERE id_skupiny NOT IN (SELECT id_skupiny FROM vazebni_tabulka WHERE id_uzivatele = (SELECT id_uzivatele FROM uzivatele WHERE jmeno = '" + jmenoUzivatele + "' AND prijmeni = '" + prijmeniUzivatele + "'))";

            SQLiteDataReader reader = sqPrikaz.ExecuteReader();

            List<string> navratovaHodnota = new List<string>();

            while (reader.Read())
            {
                navratovaHodnota.Add(reader["nazev"].ToString());
            }
            reader.Close();
            return navratovaHodnota;
        }

        public static List<string> naleztInformaceOUzivateli(string jmenoUzivatele, string prijmeniUzivatele)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "SELECT id_uzivatele, jmeno, prijmeni, cislo_cipu, ciselny_kod FROM uzivatele WHERE jmeno = '" + jmenoUzivatele + "' AND prijmeni = '" + prijmeniUzivatele + "'";
            SQLiteDataReader reader = sqPrikaz.ExecuteReader();

            List<string> navratovaHodnota = new List<string>();

            while (reader.Read())
            {
                navratovaHodnota.Add(reader["jmeno"].ToString());
                navratovaHodnota.Add(reader["prijmeni"].ToString());
                navratovaHodnota.Add(reader["ciselny_kod"].ToString());
                navratovaHodnota.Add(reader["cislo_cipu"].ToString());
                navratovaHodnota.Add(reader["id_uzivatele"].ToString());
            }
            reader.Close();
            return navratovaHodnota;
        }

        public static bool upravitUzivatele(int id_uzivatele, string jmeno, string prijmeni, int cisloCipu, int ciselnyKod)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);

            sqPrikaz.CommandText = "UPDATE uzivatele SET jmeno = '" + jmeno + "', prijmeni = '" + prijmeni + "', cislo_cipu = " + cisloCipu + ", ciselny_kod = " + ciselnyKod + " WHERE id_uzivatele = " + id_uzivatele;

            try
            {
                sqPrikaz.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("Vyskytla se chyba:" + Environment.NewLine + error.Message);
                return false;
            }
            return true;
        }

        public static bool vlozitRelaciUzivateleSkupiny(int idUzivatele, int idSkupiny)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "INSERT INTO vazebni_tabulka (id_uzivatele, id_skupiny) VALUES (" + idUzivatele + ", " + idSkupiny + ")";
            try
            {
                sqPrikaz.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("Vyskytla se chyba:" + Environment.NewLine + error.Message);
                return false;
            }
            return true;
        }

        public static bool odstranitRelaciUzivateleSkupiny(int idUzivatele, int idSkupiny)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "DELETE FROM vazebni_tabulka WHERE id_uzivatele = " + idUzivatele + " AND id_skupiny = " + idSkupiny;
            try
            {
                sqPrikaz.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("Vyskytla se chyba:" + Environment.NewLine + error.Message);
                return false;
            }
            return true;
        }

        public static bool odstranitUzivatele(int idUzivatele)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            List<string> prikazy = new List<string>();
            prikazy.Add("DELETE FROM vazebni_tabulka WHERE id_uzivatele = " + idUzivatele);
            prikazy.Add("DELETE FROM pristupy_uzivatelu WHERE id_uzivatele = " + idUzivatele);
            prikazy.Add("DELETE FROM uzivatele WHERE id_uzivatele = " + idUzivatele);
            
            foreach (string prikaz in prikazy)
            {
                sqPrikaz.CommandText = prikaz;
                try
                {
                    sqPrikaz.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Vyskytla se chyba:" + Environment.NewLine + error.Message);
                    return false;
                }
            }
            return true;
        }

        public static List<List<string>> nacistVsechnyPravidlaSkupiny(string nazevSkupiny)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "SELECT * FROM uzivatelske_skupiny WHERE id_skupiny = (SELECT id_skupiny FROM skupiny WHERE nazev = '" + nazevSkupiny + "')";
            SQLiteDataReader reader = sqPrikaz.ExecuteReader();

            List<List<string>> navratovaHodnota = new List<List<string>>();

            while (reader.Read())
            {
                List<string> radka = new List<string>();
                radka.Add(reader["id_skupiny"].ToString());
                radka.Add(reader["cislo_dveri"].ToString());
                radka.Add(reader["den"].ToString());
                radka.Add(reader["pocatecni_hodnota"].ToString());
                radka.Add(reader["konecna_hodnota"].ToString());
                navratovaHodnota.Add(radka);
            }
            reader.Close();
            return navratovaHodnota;
        }

        public static bool vymazatPravidlo(string nazevSkupiny, int dvere, int den, string pocatecniCas, string koncovyCas)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "DELETE FROM uzivatelske_skupiny WHERE cislo_dveri = " + dvere + " AND den = " + den + " AND pocatecni_hodnota = '" + pocatecniCas + "' AND konecna_hodnota = '" + koncovyCas + "' AND id_skupiny = (SELECT id_skupiny FROM skupiny WHERE nazev = '" + nazevSkupiny + "')";
            Console.WriteLine(sqPrikaz.CommandText);
            Console.WriteLine(sqPrikaz.CommandText);
            try
            {
                sqPrikaz.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("Vyskytla se chyba:" + Environment.NewLine + error.Message);
                return false;
            }
            return true;
        }

        public static List<string> prihlaseniCiselnik(int ciselny_kod, int jednaSeONaskenovanyKod)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            if (ciselny_kod == 0)
            {
                MessageBox.Show("Tento číselný kód nelze použít");
                return new List<string>();
            }

            if(jednaSeONaskenovanyKod == 0) sqPrikaz.CommandText = "SELECT id_uzivatele, jmeno, prijmeni FROM uzivatele WHERE ciselny_kod = " + ciselny_kod;
            else sqPrikaz.CommandText = "SELECT id_uzivatele, jmeno, prijmeni FROM uzivatele WHERE cislo_cipu = " + ciselny_kod;
            

            SQLiteDataReader reader = sqPrikaz.ExecuteReader();
            List<string> navratovaHodnota = new List<string>();

            while (reader.Read())
            {
                navratovaHodnota.Add(reader["id_uzivatele"].ToString());
                navratovaHodnota.Add(reader["jmeno"].ToString());
                navratovaHodnota.Add(reader["prijmeni"].ToString());

            }
            reader.Close();
            return navratovaHodnota;
        }

        public static bool ziskatPristup(int idUzivatele, int dvere, string cas, int den)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);

            int casHodiny = int.Parse(cas.Split(':')[0]);
            int casMinuty = int.Parse(cas.Split(':')[1]);
            int casSekundy = int.Parse(cas.Split(':')[2]);

            sqPrikaz.CommandText = "SELECT * FROM uzivatelske_skupiny WHERE id_skupiny IN (SELECT id_skupiny FROM vazebni_tabulka WHERE id_uzivatele = " + idUzivatele + ") AND den=" + den;
            SQLiteDataReader reader = sqPrikaz.ExecuteReader();
            while (reader.Read())
            {
                if(PrevodySoustav.vstupAktivni(int.Parse(reader["cislo_dveri"].ToString()), dvere) == 0) continue;

                DateTime datumPocatecniCas = DateTime.Parse(reader["pocatecni_hodnota"].ToString());
                DateTime datumKoncovyCas = DateTime.Parse(reader["konecna_hodnota"].ToString());

                string pocatecniCasString = datumPocatecniCas.ToString("HH:mm:ss");
                string koncovyCasString = datumKoncovyCas.ToString("HH:mm:ss");

                int pocatecniCasHodiny = int.Parse(pocatecniCasString.Split(':')[0]);
                int pocatecniCasMinuty = int.Parse(pocatecniCasString.Split(':')[1]);
                int pocatecniCasSekundy = int.Parse(pocatecniCasString.Split(':')[2]);

                int koncovyCasHodiny = int.Parse(koncovyCasString.Split(':')[0]);
                int koncovyCasMinuty = int.Parse(koncovyCasString.Split(':')[1]);
                int koncovyCasSekundy = int.Parse(koncovyCasString.Split(':')[2]);

                if(casHodiny > pocatecniCasHodiny && casHodiny < koncovyCasHodiny)
                {
                    return true;
                }
                else if((casHodiny == pocatecniCasHodiny || casHodiny == koncovyCasHodiny) && casMinuty > pocatecniCasMinuty && casMinuty < koncovyCasMinuty)
                {
                    return true;
                }
                else if((casHodiny == pocatecniCasHodiny || casHodiny == koncovyCasHodiny) && (casMinuty == pocatecniCasMinuty || casMinuty == koncovyCasMinuty) && casSekundy > pocatecniCasSekundy && casSekundy < koncovyCasSekundy)
                {
                    return true;
                }
            }
            reader.Close();
            return false;
        }

        public static bool zapisPristupu(int ciselnyKod, int jednaSeONaskenovanyKod, string datum, string cas, int dvere, int pristupUdelen)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);

            int idUzivatele = -1;
            if(jednaSeONaskenovanyKod == 0) sqPrikaz.CommandText = "SELECT id_uzivatele FROM uzivatele WHERE ciselny_kod = " + ciselnyKod;
            else sqPrikaz.CommandText = "SELECT id_uzivatele FROM uzivatele WHERE cislo_cipu = " + ciselnyKod;

            SQLiteDataReader reader = sqPrikaz.ExecuteReader();
            while (reader.Read())
            {
                idUzivatele = int.Parse(reader["id_uzivatele"].ToString());
            }
            reader.Close();

            if(idUzivatele == -1)
            {
                MessageBox.Show("Uživatel s tímto číslem kódu neexistuje.");
                return false;
            }

            sqPrikaz.CommandText = "INSERT INTO pristupy_uzivatelu (id_uzivatele, datum, cas, cislo_dveri, pristup_udelen) VALUES (" + idUzivatele  + ", '" + datum + "', '" + cas + "', '" + dvere + "', '" + pristupUdelen + "')";
            try
            {
                sqPrikaz.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("Vyskytla se chyba:" + Environment.NewLine + error.Message);
                return false;
            }
            return true;
        }

        public static string zjistitJmenoSkupiny(int idSkupiny)
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "SELECT nazev FROM skupiny WHERE id_skupiny = " + idSkupiny;
            SQLiteDataReader reader = sqPrikaz.ExecuteReader();
            string navratovaHodnota = "";
            while (reader.Read())
            {
                navratovaHodnota = reader["nazev"].ToString();
            }
            reader.Close();
            return navratovaHodnota;
        }

        public static List<List<string>> historiePrichodu()
        {
            SQLiteCommand sqPrikaz = new SQLiteCommand(databaze);
            sqPrikaz.CommandText = "SELECT * FROM pristupy_uzivatelu ORDER BY datum DESC";

            SQLiteDataReader reader = sqPrikaz.ExecuteReader();
            List<List<string>> navratovaHodnota = new List<List<string>>();

            while (reader.Read())
            {
                List<string> radek = new List<string>();

                SQLiteCommand sqPrikaz2 = new SQLiteCommand(databaze);
                sqPrikaz2.CommandText = "SELECT jmeno, prijmeni FROM uzivatele WHERE id_uzivatele = " + reader["id_uzivatele"].ToString();
                SQLiteDataReader reader2 = sqPrikaz2.ExecuteReader();
                while (reader2.Read())
                {
                    radek.Add(reader2["jmeno"].ToString());
                    radek.Add(reader2["prijmeni"].ToString());
                }
                reader2.Close();

                radek.Add(reader["datum"].ToString());
                
                DateTime cas = DateTime.Parse(reader["cas"].ToString());

                radek.Add(cas.ToString("HH:mm:ss"));
                try
                {
                    List<string> dvere = new List<string>() { "Serverovna", "Kancelář", "Sklad" };
                    radek.Add(dvere[int.Parse(reader["cislo_dveri"].ToString())]);
                }
                catch
                {
                    radek.Add("");
                    MessageBox.Show("Nastala chyba při načítání historie príchodů.");
                }

                radek.Add((reader["pristup_udelen"].ToString() == "True") ? "Ano" : "Ne");

                navratovaHodnota.Add(radek);
            }
            reader.Close();
            return navratovaHodnota;
        }

    }
}
