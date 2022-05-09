using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace PristupovySystemRFID
{
    public partial class SpravaUzivatelu : Form
    {
        int idUpravovanehoUzivatele = 0;
        SerialPort serial = new SerialPort();
        int ciselnik = 0;
        int skener = 0;
        public SpravaUzivatelu()
        {
            InitializeComponent();
        }

        private void SpravaUzivatelu_Load(object sender, EventArgs e)
        {
            timerAktualizaceUI.Enabled = true;
            inicializaceSeriovehoPortu();
            nacistZakladniHodnotyKomponent();
        }

        private void nacistZakladniHodnotyKomponent()
        {
            List<string> uzivatele = Databaze.nacistUzivatele();
            foreach (string uzivatel in uzivatele) comboBoxZvolenyUzivatel.Items.Add(uzivatel);
            try { comboBoxZvolenyUzivatel.SelectedIndex = 0; rbPouzitExistujicihoUzivatele.Enabled = true; }
            catch { rbPouzitExistujicihoUzivatele.Enabled = false; }
            rbNovyUzivatel.Checked = true;
        }

        public void prijataData(object sender, SerialDataReceivedEventArgs e)
        {
            string vstupniData = ((SerialPort)sender).ReadExisting();

            List<int> seznamASCIIHodnot = new List<int>();

            foreach (char znak in vstupniData) seznamASCIIHodnot.Add((int)znak);

            Console.WriteLine("Tato sada obsahuje " + seznamASCIIHodnot.Count + " znaku");

            if (seznamASCIIHodnot.Count == 1) return;

            switch (seznamASCIIHodnot.Count)
            {
                case 9:
                    //zadano z klavesnice - Vchod "serverovna"

                    int poradiCislic = 1;
                    string nactenaHodnota = "";
                    foreach (char znak in seznamASCIIHodnot)
                    {
                        if (poradiCislic > 2 && poradiCislic < 7) nactenaHodnota += znak.ToString();
                        poradiCislic++;
                    }
                    int desitkovaHodnota = PrevodySoustav.prevodNaDesitkovouSoustavu(nactenaHodnota, 16);

                    if (desitkovaHodnota == -1)
                    {
                        MessageBox.Show("Vyskytla se chyba");
                        return;
                    }

                    //textBoxCiselnyKod.Text = desitkovaHodnota.ToString();
                    ciselnik = desitkovaHodnota;

                    break;

                case 13:
                    //Naskenovano ze strany klavesnice - Vchod "kancelare"
                    poradiCislic = 1;
                    nactenaHodnota = "";
                    foreach (char znak in seznamASCIIHodnot)
                    {
                        if (poradiCislic > 2 && poradiCislic < 10) nactenaHodnota += znak.ToString();
                        poradiCislic++;
                    }

                    desitkovaHodnota = PrevodySoustav.prevodNaDesitkovouSoustavu(nactenaHodnota, 16);
                    if (desitkovaHodnota == -1)
                    {
                        MessageBox.Show("Vyskytla se chyba");
                        return;
                    }
                    //textBoxNaskenovanyKod.Text = desitkovaHodnota.ToString();
                    skener = desitkovaHodnota;
                    break;

                case 12:
                    //naskenovano skenerem RS485 - Vchod "sklad"
                    poradiCislic = 1;
                    nactenaHodnota = "";
                    foreach (char znak in seznamASCIIHodnot)
                    {
                        if (poradiCislic > 1 && poradiCislic < 9) nactenaHodnota += znak.ToString();
                        poradiCislic++;
                    }

                    desitkovaHodnota = PrevodySoustav.prevodNaDesitkovouSoustavu(nactenaHodnota, 16);
                    if (desitkovaHodnota == -1)
                    {
                        MessageBox.Show("Vyskytla se chyba");
                        return;
                    }
                    skener = desitkovaHodnota;
                    break;
            }
        }

        private void SpravaUzivatelu_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerAktualizaceUI.Enabled = false;
            serial.Close();
            Form1.serial.Open();
            Form1.instanceZakladnihoOkna.Show();
        }

        private void rbNovyUzivatel_CheckedChanged(object sender, EventArgs e)
        {
            if(rbNovyUzivatel.Checked)
            {
                btnVykonat.Text = "Vytvořit";
                textBoxJmeno.Text = "";
                textBoxPrijmeni.Text = "";
                textBoxCiselnyKod.Text = "";
                textBoxNaskenovanyKod.Text = "";
                comboBoxOdebraniSkupiny.Enabled = false;
                comboBoxPrirazeniSkupiny.Enabled = false;
                buttonOdebrat.Enabled = false;
                buttonPriradit.Enabled = false;
                
            }
            else
            {
                btnVykonat.Text = "Upravit";
                upravovaniExistujicihoUzivatele();

                comboBoxOdebraniSkupiny.Enabled = true;
                comboBoxPrirazeniSkupiny.Enabled = true;
                buttonOdebrat.Enabled = true;
                buttonPriradit.Enabled = true;
                
            }
        }

        private void btnVykonat_Click(object sender, EventArgs e)
        {
            if(rbNovyUzivatel.Checked)
            {

                string jmeno = textBoxJmeno.Text;
                if(jmeno == "")
                {
                    MessageBox.Show("Vyplňte jméno uživatele");
                    return;
                }
                string prijmeni = textBoxPrijmeni.Text;
                if(prijmeni == "")
                {
                    MessageBox.Show("Vyplňte jméno uživatele");
                    return;
                }

                int naskenovanyKod = 0;
                if (textBoxNaskenovanyKod.Text != "")
                {
                    try
                    {
                        naskenovanyKod = int.Parse(textBoxNaskenovanyKod.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Naskenovaný kód musí být prázdný nebo číselný.");
                        return;
                    }
                }

                int ciselnyKod = 0;
                if(textBoxCiselnyKod.Text.Length > 4)
                {
                    MessageBox.Show("Číslený kód může být maximálně 4 znaky dlouhý");
                    return;
                }

                if (textBoxCiselnyKod.Text != "")
                {
                    try
                    {
                        ciselnyKod = int.Parse(textBoxCiselnyKod.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Číselný kód musí být prázdný nebo číselný.");
                        return;
                    }
                }
                while (jmeno.EndsWith(" ")) jmeno = jmeno.Remove(jmeno.Length - 1);
                while (prijmeni.EndsWith(" ")) prijmeni = prijmeni.Remove(prijmeni.Length - 1);


                if(Databaze.vytvoritUzivatele(jmeno, prijmeni, naskenovanyKod, ciselnyKod))
                {
                    MessageBox.Show("Uživatel byl vytvořen");
                    comboBoxZvolenyUzivatel.Items.Clear();
                    List<string> uzivatele = Databaze.nacistUzivatele();
                    foreach (string uzivatel in uzivatele) comboBoxZvolenyUzivatel.Items.Add(uzivatel);
                    try
                    {
                        comboBoxZvolenyUzivatel.SelectedIndex = 0;
                        rbPouzitExistujicihoUzivatele.Enabled = true;
                    }
                    catch { rbPouzitExistujicihoUzivatele.Enabled = false; }
                }
            }
            else
            {
                string jmeno = textBoxJmeno.Text;
                if (jmeno == "")
                {
                    MessageBox.Show("Vyplňte jméno uživatele");
                    return;
                }
                string prijmeni = textBoxPrijmeni.Text;
                if (prijmeni == "")
                {
                    MessageBox.Show("Vyplňte jméno uživatele");
                    return;
                }

                int naskenovanyKod = 0;
                if (textBoxNaskenovanyKod.Text != "")
                {
                    try
                    {
                        naskenovanyKod = int.Parse(textBoxNaskenovanyKod.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Naskenovaný kód musí být prázdný nebo číselný.");
                        return;
                    }
                }

                int ciselnyKod = 0;
                if (textBoxCiselnyKod.Text.Length > 4)
                {
                    MessageBox.Show("Číslený kód může být maximálně 4 znaky dlouhý");
                    return;
                }

                if (textBoxCiselnyKod.Text != "")
                {
                    try
                    {
                        ciselnyKod = int.Parse(textBoxCiselnyKod.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Číselný kód musí být prázdný nebo číselný.");
                        return;
                    }
                }
                if(Databaze.upravitUzivatele(idUpravovanehoUzivatele, jmeno, prijmeni, naskenovanyKod, ciselnyKod))
                {
                    MessageBox.Show("Uživatel byl upraven");
                    comboBoxZvolenyUzivatel.Items.Clear();
                    List<string> uzivatele = Databaze.nacistUzivatele();
                    foreach (string uzivatel in uzivatele) comboBoxZvolenyUzivatel.Items.Add(uzivatel);
                    try
                    { comboBoxZvolenyUzivatel.SelectedIndex = 0; rbPouzitExistujicihoUzivatele.Enabled = true; }
                    catch { rbPouzitExistujicihoUzivatele.Enabled = false; }
                }
            }
        }

        private void comboBoxZvolenyUzivatel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxZvolenyUzivatel.SelectedItem == null) return;

            comboBoxPrirazeniSkupiny.Items.Clear();
            comboBoxOdebraniSkupiny.Items.Clear();

            rbNovyUzivatel.PerformClick();
            rbPouzitExistujicihoUzivatele.PerformClick();

            string[] uzivatel = comboBoxZvolenyUzivatel.SelectedItem.ToString().Split(' ');


            List<string> prirazeneSkupiny = Databaze.nacistPrirazeneSkupinyUzivateli(uzivatel[0], uzivatel[1]);
            List<string> neprirazeneSkupiny = Databaze.nacistNeprirazeneSkupinyUzivateli(uzivatel[0], uzivatel[1]);

            foreach (string skupina in prirazeneSkupiny) comboBoxOdebraniSkupiny.Items.Add(skupina);
            foreach (string skupina in neprirazeneSkupiny) comboBoxPrirazeniSkupiny.Items.Add(skupina);
        }

        private void upravovaniExistujicihoUzivatele()
        {
            string[] uzivatel = comboBoxZvolenyUzivatel.SelectedItem.ToString().Split(' ');
            List<string> informace = Databaze.naleztInformaceOUzivateli(uzivatel[0], uzivatel[1]);
            if (informace.Count == 0)
            {
                MessageBox.Show("Uživatel nebyl nalezen");
                return;
            }
            textBoxJmeno.Text = informace[0];
            textBoxPrijmeni.Text = informace[1];
            textBoxCiselnyKod.Text = informace[2];
            textBoxNaskenovanyKod.Text = informace[3];
            idUpravovanehoUzivatele = int.Parse(informace[4]);
        }

        private void buttonPriradit_Click(object sender, EventArgs e)
        {
            if(comboBoxPrirazeniSkupiny.SelectedItem == null)
            {
                MessageBox.Show("Vyberte nějakou skupinu, do které chcete uživatele přiřadit");
                return;
            }
            try
            {
                string nazevSkupiny = comboBoxPrirazeniSkupiny.SelectedItem.ToString();
                int idSkupiny = Databaze.zjistitIDSkupiny(nazevSkupiny);
                if(idSkupiny == -1)
                {
                    MessageBox.Show("Skupina nebyla nalezena");
                    return;
                }

                if(Databaze.vlozitRelaciUzivateleSkupiny(idUpravovanehoUzivatele, idSkupiny))
                {
                    MessageBox.Show("Uživatel byl přiřazen skupině " + nazevSkupiny);
                    comboBoxPrirazeniSkupiny.Items.Clear();
                    comboBoxOdebraniSkupiny.Items.Clear();

                    List<string> prirazeneSkupiny = Databaze.nacistPrirazeneSkupinyUzivateli(textBoxJmeno.Text, textBoxPrijmeni.Text);
                    foreach (string skupina in prirazeneSkupiny) comboBoxOdebraniSkupiny.Items.Add(skupina);

                    List<string> neprirazeneSkupiny = Databaze.nacistNeprirazeneSkupinyUzivateli(textBoxJmeno.Text, textBoxPrijmeni.Text);
                    foreach (string skupina in neprirazeneSkupiny) comboBoxPrirazeniSkupiny.Items.Add(skupina);
                    

                    comboBoxOdebraniSkupiny.Text = "";
                    comboBoxPrirazeniSkupiny.Text = "";
                }

            }
            catch { MessageBox.Show("Vyskytla se nečekaná chyba"); }
        }

        private void buttonOdebrat_Click(object sender, EventArgs e)
        {
            if (comboBoxOdebraniSkupiny.SelectedItem == null)
            {
                MessageBox.Show("Vyberte nějakou skupinu, ze které chcete uživatele odebrat");
                return;
            }
            try
            {
                string nazevSkupiny = comboBoxOdebraniSkupiny.SelectedItem.ToString();
                int idSkupiny = Databaze.zjistitIDSkupiny(nazevSkupiny);
                if (idSkupiny == -1)
                {
                    MessageBox.Show("Skupina nebyla nalezena");
                    return;
                }

                if (Databaze.odstranitRelaciUzivateleSkupiny(idUpravovanehoUzivatele, idSkupiny))
                {
                    MessageBox.Show("Uživatel byl odebrán ze skupiny " + nazevSkupiny);
                    comboBoxPrirazeniSkupiny.Items.Clear();
                    comboBoxOdebraniSkupiny.Items.Clear();

                    List<string> prirazeneSkupiny = Databaze.nacistPrirazeneSkupinyUzivateli(textBoxJmeno.Text, textBoxPrijmeni.Text);
                    foreach (string skupina in prirazeneSkupiny) comboBoxOdebraniSkupiny.Items.Add(skupina);

                    List<string> neprirazeneSkupiny = Databaze.nacistNeprirazeneSkupinyUzivateli(textBoxJmeno.Text, textBoxPrijmeni.Text);
                    foreach (string skupina in neprirazeneSkupiny) comboBoxPrirazeniSkupiny.Items.Add(skupina);
                    

                    comboBoxOdebraniSkupiny.Text = "";
                    comboBoxPrirazeniSkupiny.Text = "";
                }

            }
            catch { MessageBox.Show("Vyskytla se nečekaná chyba"); }
        }

        private void inicializaceSeriovehoPortu()
        {
            try
            {
                serial.PortName = "COM3";
                serial.BaudRate = 19200;
                serial.Handshake = Handshake.None;
                serial.Parity = Parity.None;
                serial.DataBits = 8;
                serial.StopBits = StopBits.One;

                serial.DataReceived += new SerialDataReceivedEventHandler(prijataData);
                serial.Open();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void buttonVymazatUzivatele_Click(object sender, EventArgs e)
        {
            if(Databaze.odstranitUzivatele(idUpravovanehoUzivatele))
            {
                MessageBox.Show("Uživatel byl úspěšně odstraněn");
                comboBoxZvolenyUzivatel.Items.Clear();
                comboBoxPrirazeniSkupiny.Items.Clear();
                comboBoxOdebraniSkupiny.Items.Clear();
                textBoxJmeno.Text = "";
                textBoxPrijmeni.Text = "";
                textBoxCiselnyKod.Text = "";
                textBoxNaskenovanyKod.Text = "";
                idUpravovanehoUzivatele = -1;
                nacistZakladniHodnotyKomponent();
            }
        }

        private void TimerAktualizaceUI_Tick(object sender, EventArgs e)
        {
            if(ciselnik.ToString() != textBoxCiselnyKod.Text && ciselnik != 0)
            {
                textBoxCiselnyKod.Text = ciselnik.ToString();
                ciselnik = 0;
            }
            if (skener.ToString() != textBoxNaskenovanyKod.Text && skener!= 0)
            {
                textBoxNaskenovanyKod.Text = skener.ToString();
                skener = 0;
            }
        }
    }
}
