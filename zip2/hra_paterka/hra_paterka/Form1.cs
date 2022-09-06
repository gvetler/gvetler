using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

/*zadání: vytvořit hru v C# winform 2D
po zapnutí je zadáno jmeno a začína hra, obsahuje dvě čísla(score a počet pokusů)
hráč ovládá pohyb nahoru a dolu a střelbu(třaba šipky nahoru a dolu a střelba šipkou doleva
cíl je na pravé straně hracího pole a pohybuje se konstantně dolu a zpět nahoru
mezi cílem a hráčem jsou náhodě generovány překážky 
při zásahu kulkou je přičteno score - po dosažení score 3 je hra resetována(ukončena) a do txt souboru je vypsáno jmeno a počet pokusů
*/
namespace hra_paterka
{
    public partial class Form1 : Form
    {
        int vystrel = 0;
        int pokusy = 0;
        int speed_hrac = 6;
        int score = 0;
        int smer = 0;
        int konec = 0;
        string jmeno;
        PictureBox[] prekazky = new PictureBox[5];
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            generace_bloku();
        }
        private void generace_bloku()
        {
            for(int i = 0; i < 5; i++)
            {
                int rint = random.Next(30,100);
                prekazky[i] = new PictureBox();
                prekazky[i].Size = new Size(30,50);
                prekazky[i].Location = new Point(610,rint+100*i+55);//urceni pozice prekazek 
                prekazky[i].BackColor = Color.Black;
                this.Controls.Add(prekazky[i]);
            }
        }

        private void timer_pro_cil_Tick(object sender, EventArgs e)
        {
            if (cile.Location.Y < 50)
                smer = 1;//smer dolu
            if (cile.Location.Y > 500)
                smer = 0;//smer nahoru
            if (smer == 0)
                 cile.Top -= 2;
            if (smer == 1)
                 cile.Top += 2;
            if (jmeno != null)
            {
                timer_pro_cil.Stop();

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Up)
            {
                if(hrac.Location.Y > 50)//neni nad hraci plochou
                {
                    hrac.Top -= speed_hrac;//posun nahoru
                    if (vystrel == 0)
                        kulka.Top -= speed_hrac;
                }
            }
            if(e.KeyData == Keys.Down)
            {
                if(hrac.Location.Y < 500 )//neni pod hraci plochou
                {
                    hrac.Top += speed_hrac;//posunnn dolu
                    if (vystrel == 0)
                        kulka.Top += speed_hrac;
                }
            }
            if(e.KeyData == Keys.Right)
            {
                vystrel = 1;//zahajeni vystrelu
            }
        }

        private void timer_pro_kulku_Tick(object sender, EventArgs e)
        {//pohyn kulky a zasah cile
            skore.Text = (Convert.ToString(pokusy));
            pokus.Text = (Convert.ToString(score));
            if (vystrel == 1)
                kulka.Left += 5;
            if(kulka.Location.X > 820)
            {//leti mimo hraci pole a je vracena zpet
                vystrel = 0;
                kulka.Location =  new Point(50,(hrac.Location.Y+37));
                pokusy++;
            }
            if(cile.Bounds.IntersectsWith(kulka.Bounds))
            {//fokin funkce je nejvice ez pro nalezeni jestli se dva objekty nachazi na stejne souradnici
                vystrel = 0;
                score++;
                kulka.Location = new Point(50, (hrac.Location.Y + 37));
            }
            for(int i = 0; i < 5; i++)
            {
                if (prekazky[i].Bounds.IntersectsWith(kulka.Bounds))
                {
                vystrel = 0;
                kulka.Location = new Point(50, (hrac.Location.Y + 37));
                pokusy++;
                }
            }
            if(score == 3)
            {

                timer_pro_kulku.Stop();
                jmeno = Interaction.InputBox("Zadej jmeno", "Jmeno", "vase jmeno", -1, -1);
            }
        }
    }
}
