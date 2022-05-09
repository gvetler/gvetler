using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pokladna
{
    public partial class Form2 : Form
    {

        int cenaNakupu = 0;
        public Form2()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 uvodniObrazovka = new Form1();
            uvodniObrazovka.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            foreach (Control predmet in this.Controls)
            {
                predmet.TabStop = false;
            }

            nastavitVelkostSloupcu();
        }

        private void nastavitVelikostSloupcu()
        {
            int velikostSloupce = 120;
            for (int i = 0; i < datagridPrehledNakupu.Columns.Count; i++)
            {
                datagridPrehledNakupu.Columns[i].Width = velikostSloupce;
            }
        }

        string nactenyText = "";
        bool stiskNasobeni = false;
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            List<Keys> cislaNumpad = new List<Keys> { Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9 };
            List<Keys> cisla = new List<Keys> { Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 };

            if (stiskNasobeni == true)
            {
                if (cisla.Contains(e.KeyCode))
                {
                    nactenyText += cisla.IndexOf(e.KeyCode).ToString();
                }
                else if (cislaNumpad.Contains(e.KeyCode))
                {
                    nactenyText += cislaNumpad.IndexOf(e.KeyCode).ToString();
                }
            }

            //Stisknuto nasobeni a stisknuti enteru
            if (stiskNasobeni == true && e.KeyCode == Keys.Enter)
            {
                nactenyText = string.Join<char>("", nactenyText.Where((ch, index) => (index % 2) != 0));
                aktualizovatCenuNakupu(-int.Parse(datagridPrehledNakupu.Rows[datagridPrehledNakupu.Rows.Count - 2].Cells[3].Value.ToString()));
                aktualizovatCenuNakupu(int.Parse(datagridPrehledNakupu.Rows[datagridPrehledNakupu.Rows.Count - 2].Cells[2].Value.ToString()) * int.Parse(nactenyText));
                datagridPrehledNakupu.Rows[datagridPrehledNakupu.Rows.Count - 2].Cells[1].Value = int.Parse(nactenyText);
                datagridPrehledNakupu.Rows[datagridPrehledNakupu.Rows.Count - 2].Cells[3].Value = int.Parse(datagridPrehledNakupu.Rows[datagridPrehledNakupu.Rows.Count - 2].Cells[2].Value.ToString()) * int.Parse(nactenyText);
                
                stiskNasobeni = false;
            }

            

            if (e.KeyCode == Keys.Multiply)
            {
                if(datagridPrehledNakupu.Rows.Count > 1)
                {
                    stiskNasobeni = true;
                    nactenyText = "";
                }
                else
                {
                    MessageBox.Show("Funkce změny množství nelze použít, protože není v pokladním systému žádný produkt u tohoto nákupu.");
                    return;
                }
                
            }
            if (e.KeyCode == Keys.NumLock) return;

            //Stisk jednotlivych tlacitek
            if (e.KeyCode == Keys.End)
            {
                btnHistorieNakupu_Click(sender, e);
                return;
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                btnStorno_Click(sender, e);
                return;
            }
            else if (e.KeyCode == Keys.Home)
            {
                btnVymazatPosledni_Click(sender, e);
                return;
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                btnZaplatit_Click(sender, e);
                return;
            }

            //Stisknuty znak obsahuje cislo
            
            
            if (cisla.Contains(e.KeyCode))
            {
                nactenyText += cisla.IndexOf(e.KeyCode).ToString();
            }
            else if(cislaNumpad.Contains(e.KeyCode))
            {
                nactenyText += cislaNumpad.IndexOf(e.KeyCode).ToString();
            }

            //Stisk enteru
            else if (e.KeyCode == Keys.Return)
            {

                Databaze databaze = new Databaze();

                //nacteny text je id zbozi
                string[] poleSDaty = databaze.nacistZbozi(nactenyText);
                if (poleSDaty.Length == 1)
                {
                    MessageBox.Show("Při načítání produktu vznikla tato chyba:" + Environment.NewLine + poleSDaty[0]);
                    nactenyText = "";
                    return;
                }
                else if (poleSDaty.Length == 0)
                {
                    MessageBox.Show("Tento produkt nebyl nazelen.");
                    nactenyText = "";
                    return;
                }

                int index = kontrolaJestliNeniNamarkovany(poleSDaty[0].ToString());

                if(index != -1)
                {
                    int kvantitaZbozi = int.Parse(datagridPrehledNakupu.Rows[index].Cells[1].Value.ToString()) + 1;
                    if(kvantitaZbozi > int.Parse(poleSDaty[2]))
                    {
                        MessageBox.Show("Tento produkt není v dostatečném množství na skladě." + Environment.NewLine + "Na skladě je " + poleSDaty[2] + " kusů.");
                        return;
                    }
                    datagridPrehledNakupu.Rows[index].Cells[1].Value = kvantitaZbozi;

                    int cenaZaKus = int.Parse(datagridPrehledNakupu.Rows[index].Cells[2].Value.ToString());
                    
                    aktualizovatCenuNakupu(cenaZaKus);
                    datagridPrehledNakupu.Rows[index].Cells[3].Value = (int.Parse(datagridPrehledNakupu.Rows[index].Cells[3].Value.ToString()) + cenaZaKus).ToString();

                    nactenyText = "";
                    return;
                }

                int mnozstvi = 1;
                if(mnozstvi > int.Parse(poleSDaty[2]))
                {
                    MessageBox.Show("Tento produkt není v dostatečném množství na skladě." + Environment.NewLine + "Na skladě je " + poleSDaty[2] + " kusů.");
                    return;
                }

                //Nazev produktu, mnozstvi, cena za kus, celkova cena
                datagridPrehledNakupu.Rows.Add(new string[] { poleSDaty[0], "1", poleSDaty[1],  poleSDaty[1]});

                aktualizovatCenuNakupu(int.Parse(poleSDaty[1]));

                nactenyText = "";
            }
        }

        private void aktualizovatCenuNakupu(int pridanaHodnota)
        {
            cenaNakupu += pridanaHodnota;
            lblCenaNakupu.Text = cenaNakupu.ToString() + " Kč";
        }

        private void btnVymazatPosledni_Click(object sender, EventArgs e)
        {
            if (datagridPrehledNakupu.Rows.Count > 1)
            {
                int celkovaCenaProduktu = int.Parse(datagridPrehledNakupu.Rows[datagridPrehledNakupu.Rows.Count - 2].Cells[3].Value.ToString());

                aktualizovatCenuNakupu(-celkovaCenaProduktu);
                datagridPrehledNakupu.Rows.RemoveAt(datagridPrehledNakupu.Rows.Count - 2);
            }
        }

        private void btnStorno_Click(object sender, EventArgs e)
        {
            while (datagridPrehledNakupu.Rows.Count > 1)
            {
                aktualizovatCenuNakupu(-cenaNakupu);
                datagridPrehledNakupu.Rows.RemoveAt(0);
            }
        }

        private void btnZaplatit_Click(object sender, EventArgs e)
        {
            DialogoveOkno dialogoveOkno = new DialogoveOkno();
            dialogoveOkno.ShowDialog();


            try
            {
                int obsahTextboxu = int.Parse(DialogoveOkno.obsahTextboxu);
                if (obsahTextboxu - cenaNakupu == 0) MessageBox.Show("Nemusíte vracet nic.");
                else if (obsahTextboxu - cenaNakupu > 0) MessageBox.Show("Musíte vrátit: " + (obsahTextboxu - cenaNakupu).ToString() + " Kč");
                else if (obsahTextboxu - cenaNakupu < 0) MessageBox.Show("Zákazník musí doplatit: " + (cenaNakupu - obsahTextboxu).ToString() + " Kč");
            }
            catch
            {
                MessageBox.Show("Nezapsal jste správnou číslelnou hodnotu.");
            }
            

            if (datagridPrehledNakupu.Rows.Count - 1 == 0)
            {
                MessageBox.Show("Nebylo nic namarkováno");
                return;
            }

            //Nalezt id nakupu

            Databaze databaze = new Databaze();
            string[] idNakupu = databaze.naleztIDNakupu();
            if (idNakupu.Length > 1)
            {
                MessageBox.Show(idNakupu[0] + Environment.NewLine + idNakupu[1]);
                return;
            }

            //string textProUctenku = "Produkt            Množství            Cena";

            DataTable dt = new DataTable();
            dt.Columns.Add("Produkt");
            dt.Columns.Add("Množství");
            dt.Columns.Add("Cena");


            for (int i = 0; i < datagridPrehledNakupu.Rows.Count - 1; i++)
            {
                string[] idZbozi = databaze.naleztIDZbozi(datagridPrehledNakupu.Rows[i].Cells[0].Value.ToString());
                if (idZbozi.Length > 1)
                {
                    MessageBox.Show(idZbozi[0] + Environment.NewLine + idZbozi[1] + Environment.NewLine + "Tato položka nebude zapsána v rámci tohoto nákupu.");
                    continue;
                }

                try
                {
                    string[] vysledekUkladani = databaze.ulozitNakup(idZbozi[0], idNakupu[0], int.Parse(datagridPrehledNakupu.Rows[i].Cells[1].Value.ToString()), int.Parse(datagridPrehledNakupu.Rows[i].Cells[3].Value.ToString()));
                    if (vysledekUkladani.Length > 0)
                    {
                        MessageBox.Show(vysledekUkladani[0]);
                    }
                    else
                    {
                        dt.Rows.Add(new string[] { datagridPrehledNakupu.Rows[i].Cells[0].Value.ToString(), datagridPrehledNakupu.Rows[i].Cells[1].Value.ToString(), datagridPrehledNakupu.Rows[i].Cells[2].Value.ToString() });
                    }

                }
                catch
                {
                    MessageBox.Show("Při ukládání nákupu došlo k chybě." + Environment.NewLine + "Některé data nejsou ve správném datovém typu.");
                    return;
                }
                Write(dt, "Uctenka_nakup" + idNakupu[0] + ".txt");

            }
        }

        public void Write(DataTable dt, string cestaKSouboru)
        {
            int i = 0;
            StreamWriter sw = null;

            try
            {

                sw = new StreamWriter(cestaKSouboru, false);

                sw.WriteLine("Nákup: ");

                for (i = 0; i < dt.Columns.Count - 1; i++)
                {

                    sw.Write(dt.Columns[i].ColumnName + " | ");

                }
                sw.Write(dt.Columns[i].ColumnName);
                sw.WriteLine();


                foreach (DataRow radek in dt.Rows)
                {
                    object[] pole = radek.ItemArray;

                    for (i = 0; i < pole.Length - 1; i++)
                    {
                        sw.Write(pole[i].ToString() + " | ");
                    }
                    sw.Write(pole[i].ToString());
                    sw.WriteLine();

                }
                sw.WriteLine("Celková cena nákupu: " + cenaNakupu);
                sw.WriteLine("Pokladní: Josef Zetek, Vojtěch Novák");
                sw.WriteLine("Prodejna: SPŠCV");
                sw.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int kontrolaJestliNeniNamarkovany(string nazev)
        {
            for(int i = 0; i < datagridPrehledNakupu.Rows.Count-1; i++)
            {
                if (datagridPrehledNakupu.Rows[i].Cells[0].Value.ToString() == nazev)
                {
                    return i;
                }
            }
            return -1;
        }

        private void btnHistorieNakupu_Click(object sender, EventArgs e)
        {
            HistorieNakupu historieNakupu = new HistorieNakupu();
            historieNakupu.Show();
        }
    }
}
