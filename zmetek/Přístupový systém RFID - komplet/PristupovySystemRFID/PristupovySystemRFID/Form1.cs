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
    public partial class Form1 : Form
    {
        public static Form1 instanceZakladnihoOkna;
        public static SerialPort serial = new SerialPort();
        List<string> prijateHodnoty = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerAktualizaceUI.Enabled = true;
            inicializaceSeriovehoPortu();
            instanceZakladnihoOkna = this;
            Databaze.vytvoreniDatabaze();
            nacistHistorii();
        }

        private void nacistHistorii()
        {
            List<List<string>> historie = Databaze.historiePrichodu();
            foreach (List<string> radek in historie)
            {
                dataGridView1.Rows.Add(radek[0], radek[1], radek[2], radek[3], radek[4], radek[5]);
            }
        }

        private void prihlaseniCiselnik(int ciselnyKod, int cisloDveri, bool naskenovanyKod)
        {
            
            List<string> dnyVTydnu = new List<string>(){ "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            List<string> dvere = new List<string>() { "Serverovna", "Kancelář", "Sklad" };
            string denVTydnu = DateTime.Now.DayOfWeek.ToString();

            int den = dnyVTydnu.IndexOf(denVTydnu) + 1;


            List<string> udajeUzivatele = new List<string>();

            if(naskenovanyKod) udajeUzivatele = Databaze.prihlaseniCiselnik(ciselnyKod, 1);
            else udajeUzivatele = Databaze.prihlaseniCiselnik(ciselnyKod, 0);

            string cas = DateTime.Now.ToString("HH:mm:ss");



            if (udajeUzivatele.Count == 3)
            {
                int ziskaniPristupu = (Databaze.ziskatPristup(int.Parse(udajeUzivatele[0]), cisloDveri, cas, den)) ? 1:0;
                if (ziskaniPristupu == 1) pictureBox1.Image = Properties.Resources.PristupUdelen;
                else pictureBox1.Image = Properties.Resources.PristupNeudelen;
                
                if(naskenovanyKod) Databaze.zapisPristupu(ciselnyKod, 1, DateTime.Now.ToString("d"), cas, cisloDveri, ziskaniPristupu);
                else Databaze.zapisPristupu(ciselnyKod, 0, DateTime.Now.ToString("d"), cas, cisloDveri, ziskaniPristupu);

                prijateHodnoty = new List<string>{ udajeUzivatele[1], udajeUzivatele[2], DateTime.Now.ToString("d"), cas, dvere[cisloDveri], ((ziskaniPristupu == 1) ? "Ano" : "Ne") };
                //dataGridView1.Rows.Add(udajeUzivatele[1], udajeUzivatele[2], DateTime.Now.ToString("d"), cas, dvere[cisloDveri], ((ziskaniPristupu == 1) ? "Ano" : "Ne"));
                //labelJmenoUzivatele.Text = udajeUzivatele[1] + " " + udajeUzivatele[2];
            }
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
            catch
            {
                MessageBox.Show("Nebyl inicializovany seriovy port.");
            }
           
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

                    prihlaseniCiselnik(desitkovaHodnota, 0, false); //prvni agrument = zadana hodnota na ciselniku, druhy argument = cislo dveri, treti argument = byl obsah naskenovany (zadany jinak nez na ciselniku)

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
                    prihlaseniCiselnik(desitkovaHodnota, 1, true);
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
                    prihlaseniCiselnik(desitkovaHodnota, 2, true);
                    break;
            }
        }

        private void btnSpravaSkupin_Click(object sender, EventArgs e)
        {
            timerAktualizaceUI.Enabled = false;
            serial.Close();
            SpravaSkupin spravaSkupin = new SpravaSkupin();
            spravaSkupin.Show();
            instanceZakladnihoOkna.Hide();
        }

        private void btnSpravaUzivatelu_Click(object sender, EventArgs e)
        {
            timerAktualizaceUI.Enabled = false;
            serial.Close();
            SpravaUzivatelu spravaUzivatelu = new SpravaUzivatelu();
            spravaUzivatelu.Show();
            instanceZakladnihoOkna.Hide();
        }

        private void TimerAktualizaceUI_Tick(object sender, EventArgs e)
        {
            if(prijateHodnoty.Count != 0)
            {
                prehoditPoradi();
                dataGridView1.Rows.Add(prijateHodnoty[0], prijateHodnoty[1], prijateHodnoty[2], prijateHodnoty[3], prijateHodnoty[4], prijateHodnoty[5]);
                labelJmenoUzivatele.Text = prijateHodnoty[0] + " " + prijateHodnoty[1];
                prijateHodnoty.Clear();
                prehoditPoradi();
            }
        }

        private void prehoditPoradi()
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            rows.AddRange(dataGridView1.Rows.Cast<DataGridViewRow>());
            rows.Reverse();
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.AddRange(rows.ToArray());
        }
    }
}
