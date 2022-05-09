using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PristupovySystemRFID
{
    public partial class SpravaSkupin : Form
    {
        public SpravaSkupin()
        {
            InitializeComponent();
        }

        private void SpravaSkupin_Load(object sender, EventArgs e)
        {
            nacistZakladniHodnotyKomponent();
        }

        private void nacistZakladniHodnotyKomponent()
        {

            dataGridView1.RowHeadersVisible = false;
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Vymazat záznam";
            buttonColumn.Text = "Vymazat";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);

            List<string> nazvySkupin = Databaze.nacistNazvySkupin();
            foreach (string nazevSkupiny in nazvySkupin) comboBoxZvoleneSkupiny.Items.Add(nazevSkupiny);
            try { comboBoxZvoleneSkupiny.SelectedIndex = 0; rbPouzitExistujici.Enabled = true; }
            catch { rbPouzitExistujici.Enabled = false; }
            rbVytvoritSkupinu.Checked = true;

            string[] dnyVTydnu = { "Pondělí", "Úterý", "Středa", "Čtvrtek", "Pátek", "Sobota", "Neděle" };
            foreach (string denVTydnu in dnyVTydnu) comboBoxZvolenyDen.Items.Add(denVTydnu);
            try { comboBoxZvolenyDen.SelectedIndex = 0; }
            catch { }

            for (int i = 0; i < 24; i++)
            {
                comboBoxPocatecniHodiny.Items.Add(i);
                comboBoxKoncoveHodiny.Items.Add(i);
            }
            for (int i = 0; i < 60; i++)
            {
                comboBoxPocatecniMinuty.Items.Add(i);
                comboBoxKoncoveMinuty.Items.Add(i);
                comboBoxPocatecniSekundy.Items.Add(i);
                comboBoxKoncoveSekundy.Items.Add(i);
            }
            comboBoxPocatecniHodiny.SelectedIndex = 0;
            comboBoxPocatecniMinuty.SelectedIndex = 0;
            comboBoxPocatecniSekundy.SelectedIndex = 0;
            comboBoxKoncoveHodiny.SelectedIndex = 23;
            comboBoxKoncoveMinuty.SelectedIndex = 59;
            comboBoxKoncoveSekundy.SelectedIndex = 59;
        }

        private void SpravaSkupin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.serial.Open();
            Form1.instanceZakladnihoOkna.Show();
        }

        private void rbVytvoritSkupinu_CheckedChanged(object sender, EventArgs e)
        {
            txtNovaSkupina.Enabled = rbVytvoritSkupinu.Checked ? true : false;
            if (rbVytvoritSkupinu.Checked) dataGridView1.Rows.Clear();
        }

        private void btnVytvoritPravidlo_Click(object sender, EventArgs e)
        {
            int pristupServerovna = (checkBoxServerovna.Checked) ? 1 : 0;
            int pristupKancelare = (checkBoxKancelare.Checked) ? 1 << 1 : 0;
            int pristupSklad = (checkBoxSklad.Checked) ? 1 << 2 : 0;

            int pristup = pristupServerovna + pristupKancelare + pristupSklad;
            if (pristup == 0)
            {
                MessageBox.Show("Zvolte přístup alespoň k jednomu místu");
                return;
            }

            int den = comboBoxZvolenyDen.SelectedIndex + 1; //Pondělí - Neděle (1-7)

            int pocatecniHodiny = comboBoxPocatecniHodiny.SelectedIndex;
            int pocatecniMinuty = comboBoxPocatecniMinuty.SelectedIndex;
            int pocatecniSekundy = comboBoxPocatecniSekundy.SelectedIndex;

            string pocatecniHodinyString = pocatecniHodiny.ToString();
            if (pocatecniHodiny < 10) pocatecniHodinyString = "0" + pocatecniHodinyString;
            string pocatecniMinutyString = pocatecniMinuty.ToString();
            if (pocatecniMinuty < 10) pocatecniMinutyString = "0" + pocatecniMinutyString;
            string pocatecniSekundyString = pocatecniSekundy.ToString();
            if (pocatecniSekundy < 10) pocatecniSekundyString = "0" + pocatecniSekundyString;


            int koncoveHodiny = comboBoxKoncoveHodiny.SelectedIndex;
            int koncoveMinuty = comboBoxKoncoveMinuty.SelectedIndex;
            int koncoveSekundy = comboBoxKoncoveSekundy.SelectedIndex;

            string koncoveHodinyString = koncoveHodiny.ToString();
            if (koncoveHodiny < 10) koncoveHodinyString = "0" + koncoveHodinyString;
            string koncoveMinutyString = koncoveMinuty.ToString();
            if (koncoveMinuty < 10) koncoveMinutyString = "0" + koncoveMinutyString;
            string koncoveSekundyString = koncoveSekundy.ToString();
            if (koncoveSekundy < 10) koncoveSekundyString = "0" + koncoveSekundyString;

            if (pocatecniHodiny > koncoveHodiny || ((pocatecniHodiny < koncoveHodiny) && (pocatecniMinuty > koncoveMinuty)) || ((pocatecniHodiny < koncoveHodiny) && (pocatecniMinuty < koncoveMinuty) && (pocatecniSekundy > koncoveSekundy)))
            {
                MessageBox.Show("Počátek pravidla nemůže být později než konec.");
                return;
            }

            if (rbVytvoritSkupinu.Checked)
            {
                string nazevSkupiny = txtNovaSkupina.Text;
                if(nazevSkupiny == "")
                {
                    MessageBox.Show("Zadejte název skupiny");
                    return;
                }

                string vracenaHodnota = Databaze.zaevidovatNazevNoveSkupiny(nazevSkupiny);

                if (vracenaHodnota.All(char.IsDigit))
                {
                    int idSkupiny = int.Parse(vracenaHodnota);
                    string pocatecniHodnota = pocatecniHodinyString + ":" + pocatecniMinutyString + ":" + pocatecniSekundyString;
                    string koncovaHodnota = koncoveHodinyString + ":" + koncoveMinutyString + ":" + koncoveSekundyString;
                    
                    if(Databaze.vlozitNovePravidlo(idSkupiny, pristup, den, pocatecniHodnota, koncovaHodnota))
                    {
                        comboBoxZvoleneSkupiny.Items.Clear();
                        List<string> nazvySkupin = Databaze.nacistNazvySkupin();
                        foreach (string nazev in nazvySkupin) comboBoxZvoleneSkupiny.Items.Add(nazev);
                        try { comboBoxZvoleneSkupiny.SelectedIndex = 0; rbPouzitExistujici.Enabled = true; }
                        catch { rbPouzitExistujici.Enabled = false; rbVytvoritSkupinu.Checked = true; }
                        
                    }
                }
                else if(vracenaHodnota != "")
                {
                    MessageBox.Show("V průběhu evidování vznikla tato chyba: " + Environment.NewLine + vracenaHodnota);
                }
            }
            else
            {
                string nazevSkupiny = comboBoxZvoleneSkupiny.SelectedItem.ToString();
                int idSkupiny = Databaze.zjistitIDSkupiny(nazevSkupiny);
                if(idSkupiny == -1) return;

                string pocatecniHodnota = pocatecniHodinyString + ":" + pocatecniMinutyString + ":" + pocatecniSekundyString;
                string koncovaHodnota = koncoveHodinyString + ":" + koncoveMinutyString + ":" + koncoveSekundyString;

                if(Databaze.vlozitNovePravidlo(idSkupiny, pristup, den, pocatecniHodnota, koncovaHodnota))
                {
                        comboBoxZvoleneSkupiny.Items.Clear();
                        List<string> nazvySkupin = Databaze.nacistNazvySkupin();
                        foreach (string nazev in nazvySkupin) comboBoxZvoleneSkupiny.Items.Add(nazev);
                        try { comboBoxZvoleneSkupiny.SelectedIndex = 0; rbPouzitExistujici.Enabled = true; }
                        catch { rbPouzitExistujici.Enabled = false; rbVytvoritSkupinu.Checked = true; }
                        
                }
            }
        }

        private void btnVymazatSkupinu_Click(object sender, EventArgs e)
        {
            string nazevSkupiny = "";

            try
            {
                if(comboBoxZvoleneSkupiny.SelectedItem == null)
                {
                    MessageBox.Show("Není vybrána žádná skupina");
                    return;
                }
                nazevSkupiny = comboBoxZvoleneSkupiny.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Není vybrána žádná skupina");
                return;
            }

            if(MessageBox.Show("Opravdu chcete vymazat skupinu " + nazevSkupiny + "?", "Vymazat skupinu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(Databaze.vymazatSkupinu(nazevSkupiny))
                {
                    comboBoxZvoleneSkupiny.Items.Clear();
                    List<string> nazvySkupin = Databaze.nacistNazvySkupin();
                    foreach (string nazev in nazvySkupin) comboBoxZvoleneSkupiny.Items.Add(nazev);
                    try { comboBoxZvoleneSkupiny.SelectedIndex = 0; rbPouzitExistujici.Enabled = true; }
                    catch
                    { 
                        rbPouzitExistujici.Enabled = false;
                        rbVytvoritSkupinu.Checked = true;
                        comboBoxZvoleneSkupiny.Text = "";
                    }
                }
            }

        }

        private void comboBoxZvoleneSkupiny_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string nazevSkupiny = "";
            if (comboBoxZvoleneSkupiny.SelectedItem == null) return;
            try
            {
                nazevSkupiny = comboBoxZvoleneSkupiny.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Nelze zobrazit pravidla pro tuto skupinu.");
                return;
            }

            string[] dnyVTydnu = { "Po", "Út", "St", "Čt", "Pá", "So", "Ne" };
            List<List<string>> dataKZobrazeni = Databaze.nacistVsechnyPravidlaSkupiny(nazevSkupiny);


            foreach (List<string> seznamDat in dataKZobrazeni)
            {
                try
                {

                    bool dvereServerovna = (PrevodySoustav.vstupAktivni(int.Parse(seznamDat[1]), 0) == 1) ? true : false;
                    bool dvereKancelar = (PrevodySoustav.vstupAktivni(int.Parse(seznamDat[1]), 1) == 1) ? true : false;
                    bool dvereSklad = (PrevodySoustav.vstupAktivni(int.Parse(seznamDat[1]), 2) == 1) ? true : false;

                    string den = dnyVTydnu[int.Parse(seznamDat[2]) - 1];

                    string pocatecniCas = seznamDat[3].ToString();
                    string koncovyCas = seznamDat[4].ToString();

                    DateTime datumPocatecniCas = DateTime.Parse(pocatecniCas);
                    DateTime datumKoncovyCas = DateTime.Parse(koncovyCas);

                    string pocatecniCasString = datumPocatecniCas.ToString("HH:mm:ss");
                    string koncovyCasString = datumKoncovyCas.ToString("HH:mm:ss");

                    dataGridView1.Rows.Add(dvereServerovna, dvereKancelar, dvereSklad, den, pocatecniCasString, koncovyCasString);
                }
                catch
                {
                    MessageBox.Show("V tabulce pravidel skupin jsou uložena data v neočekávaném datovém typu");
                    return;
                }
            }
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    int dvere = ((bool)(senderGrid.Rows[e.RowIndex].Cells[0].Value) == true) ? 1 : 0;
                    dvere += (((bool)(senderGrid.Rows[e.RowIndex].Cells[1].Value) == true) ? 1 : 0) << 1;
                    dvere += (((bool)(senderGrid.Rows[e.RowIndex].Cells[2].Value) == true) ? 1 : 0) << 2;

                    List<string> dnyVTydnu = new List<string> { "Po", "Út", "St", "Čt", "Pá", "So", "Ne" };

                    string den = senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                    int index = dnyVTydnu.FindIndex(a => a.Contains(den)) + 1;

                    string pocatecniCas = senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string koncovyCas = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();

                    string nazevSkupiny = "";
                    try
                    {
                        nazevSkupiny = comboBoxZvoleneSkupiny.SelectedItem.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Není vybrána žádná skupina");
                        return;
                    }

                    if (Databaze.vymazatPravidlo(nazevSkupiny, dvere, index, pocatecniCas, koncovyCas))
                    {
                        MessageBox.Show("Záznam byl úspěšně vymazán");
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        dataGridView1.Refresh();
                    }

                }
            }
            catch { }
            
        }
    }
}
