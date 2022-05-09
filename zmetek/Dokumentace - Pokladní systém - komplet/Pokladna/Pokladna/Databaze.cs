using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Pokladna
{
    class Databaze
    {

        static SQLiteConnection pripojeni = new SQLiteConnection();

        public string[] vytvoritDatabazi()
        {
            try
            {
                pripojeni.ConnectionString = "Data source=data.sqlite";
                pripojeni.Open();
            }
            catch { }
            

            //Vytvoreni tabulky zbozi
            SQLiteCommand prikaz = new SQLiteCommand(pripojeni);
            prikaz.CommandText = "CREATE TABLE IF NOT EXISTS zbozi (id_zbozi VARCHAR(20) PRIMARY KEY, nazev VARCHAR(40), cena INT, dostupne_polozky INT, UNIQUE(nazev))";
            try
            {
                prikaz.ExecuteNonQuery();
            }
            catch (Exception chyba)
            {
                string[] navratovePole = new string[1];


                navratovePole[0] = "Vyskytl se problém s vytvářením tabulky zboží.";
                navratovePole[0] += Environment.NewLine;
                navratovePole[0] += chyba.Message.ToString();

                return navratovePole;
            }


            //Vytvoreni tabulky nakupy
            prikaz.CommandText = "CREATE TABLE IF NOT EXISTS nakupy (id_zbozi VARCHAR(20), id_nakupu INT, pocet_polozek INT, cena INT, FOREIGN KEY(id_zbozi) REFERENCES zbozi(id_zbozi) ON DELETE CASCADE, PRIMARY KEY(id_zbozi, id_nakupu))";

            try
            {
                prikaz.ExecuteNonQuery();
            }
            catch (Exception chyba)
            {
                string[] navratovePole = new string[1];

                
                navratovePole[0] = "Vyskytl se problém s vytvářením tabulky nákupy.";
                navratovePole[0] += Environment.NewLine;
                navratovePole[0] += chyba.Message.ToString();

                return navratovePole;
            }

            //Vytvoreni tabulky prihlaseni uzivatelu
            prikaz.CommandText = "CREATE TABLE IF NOT EXISTS uzivatele (jmeno_uzivatele VARCHAR(50) PRIMARY KEY, heslo VARCHAR(50))";

            try
            {
                prikaz.ExecuteNonQuery();
            }
            catch (Exception chyba)
            {
                string[] navratovePole = new string[1];


                navratovePole[0] = "Vyskytl se problém s vytvářením tabulky uživatelů.";
                navratovePole[0] += Environment.NewLine;
                navratovePole[0] += chyba.Message.ToString();

                return navratovePole;
            }

            return new string[0];
        }

        public string[] nacistZbozi(string id_zbozi)
        {
            SQLiteCommand prikaz = new SQLiteCommand(pripojeni);

            prikaz.CommandText = "SELECT * FROM zbozi WHERE id_zbozi = '" + id_zbozi + "'";

            SQLiteDataReader cteni = prikaz.ExecuteReader();

            string[] poleKVraceni = new string[0];

            while (cteni.Read())
            {
                try
                {
                    poleKVraceni = new string[]{ cteni["nazev"].ToString(), cteni["cena"].ToString(), cteni["dostupne_polozky"].ToString() };
                    break;
                    
                }
                catch (Exception error)
                {
                    poleKVraceni = new string[] { error.Message.ToString() };
                    break;
                }
            }
            return poleKVraceni;
        }

        public bool prihlaseniDoSystemu(string uzivatelskeJmeno, string heslo)
        {
            SQLiteCommand prikaz = new SQLiteCommand(pripojeni);

            prikaz.CommandText = "SELECT heslo FROM uzivatele WHERE jmeno_uzivatele = '" + uzivatelskeJmeno + "'";

            
            SQLiteDataReader cteni = prikaz.ExecuteReader();

            bool stavPrihlaseni = false;

            while(cteni.Read())
            {
                try
                {
                    if (cteni["heslo"].ToString() == heslo)
                    {
                        stavPrihlaseni = true;
                        break;
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message.ToString());
                }
            }

            return stavPrihlaseni;
        }

        public string[] naleztIDNakupu()
        {

            SQLiteCommand prikaz = new SQLiteCommand(pripojeni);

            int vyslednaHodnota = 0;

            prikaz.CommandText = "SELECT * FROM nakupy ORDER BY (id_nakupu) DESC";

            try
            {
                SQLiteDataReader cteni = prikaz.ExecuteReader();

                while (cteni.Read())
                {
                    return new string[] { ((int.Parse(cteni["id_nakupu"].ToString())) + 1).ToString() };
                }
            }
            catch (Exception error)
            {

                //Pole neobsahuje nic, vysledna hodnota je 0
                if (error.Message == "Index je mimo hranice pole.")
                {
                    return new string[] { vyslednaHodnota.ToString() };
                }
                return new string[] { "Vyskytla se chyba v průběhu generování id nákupu.", error.Message };
            }
            return new string[] { vyslednaHodnota.ToString() };
        }

        public string[] naleztIDZbozi(string nazev)
        {
            SQLiteCommand prikaz = new SQLiteCommand(pripojeni);
            prikaz.CommandText = "SELECT * FROM zbozi WHERE nazev='" + nazev + "'";
            string[] spatnyVysledek = new string[2];
            try
            {
                SQLiteDataReader cteni = prikaz.ExecuteReader();

                string id_zbozi = "";

                while(cteni.Read())
                {
                    
                    if(cteni["nazev"].ToString() == nazev)
                    {
                        id_zbozi = cteni["id_zbozi"].ToString();
                        return new string[] { id_zbozi };
                    }
                }
            }
            catch (Exception error)
            {
                spatnyVysledek = new string[] { "Nastala chyba ve hledání id pro dané zboží.", error.Message };
            }
            return spatnyVysledek;
        }

        public string[] ulozitNakup(string idZbozi, string idNakupu, int pocetPolozek, int cena)
        {
            SQLiteCommand prikaz = new SQLiteCommand(pripojeni);

            prikaz.CommandText = "INSERT INTO nakupy (id_zbozi, id_nakupu, pocet_polozek, cena) VALUES ('" + idZbozi + "', " + idNakupu + ", " + pocetPolozek + ", " + cena + ")";
            try
            {
                prikaz.ExecuteNonQuery();
            }
            catch (Exception chyba)
            {
                string[] navratovePole = new string[1];


                navratovePole[0] = "Vyskytl se problém s přidáním záznamu do tabulky nakupy.";
                navratovePole[0] += Environment.NewLine;
                navratovePole[0] += chyba.Message.ToString();

                return navratovePole;
            }
            return new string[0];
        }

        public List<List<string>> nacistHistoriiNakupu()
        {
            List<List<string>> vyslednyList = new List<List<string>>();

            SQLiteCommand prikaz = new SQLiteCommand(pripojeni);
            prikaz.CommandText = "SELECT * FROM nakupy ORDER BY (id_nakupu) ASC";

            SQLiteDataReader cteni = prikaz.ExecuteReader();

            while(cteni.Read())
            {
                SQLiteCommand prikaz2 = new SQLiteCommand(pripojeni);

                prikaz2.CommandText = "SELECT * FROM zbozi WHERE id_zbozi = '" + cteni["id_zbozi"] + "'";
                SQLiteDataReader cteni2 = prikaz2.ExecuteReader();
                while (cteni2.Read())
                {
                    if(cteni2["id_zbozi"].ToString() == cteni["id_zbozi"].ToString())
                    {
                        vyslednyList.Add(new List<string>() { cteni["id_nakupu"].ToString(), cteni2["nazev"].ToString(), cteni["pocet_polozek"].ToString(), cteni["cena"].ToString() });
                    }
                }
            }

            return vyslednyList;

        }
    }
}
