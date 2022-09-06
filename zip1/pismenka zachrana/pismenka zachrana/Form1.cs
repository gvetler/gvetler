using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 * pismenka se spawnují na levé straně a pohybují se směrem doprava kde je řeka do které spadnou pokud nejsou na lodi
 * 
*/
namespace pismenka_zachrana
{
    public partial class Form1 : Form
    {
        string[] abc = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        int doprava = 1;
        int doleva = 1;
        int i = 0;
        int zachranena=0;
        int utopena=0;
        Random random = new Random();
        Label[] pismenka = new Label[27];
        public Form1()
        {
            InitializeComponent();
        }

        private void timer_pro_lod_Tick(object sender, EventArgs e)
        {//spawn pismen
            int rand = random.Next(1500, 8000);
            if (i < 26)
            {
                pismenka[i] = new Label();
                pismenka[i].Size = new Size(30, 30);
                pismenka[i].Location = new Point(30, 272);
                pismenka[i].Text = abc[i];
                pismenka[i].Font  = new Font(Font.FontFamily,20);
                this.Controls.Add(pismenka[i]);
                i++;
            }
            timer_pro_pismenka.Interval = (rand);
        }

        private void timer_kolize_Tick(object sender, EventArgs e)
        {
            if  (lod.Bounds.IntersectsWith(breh1.Bounds))
            {
                doleva = 0;
            }
            if (!(lod.Bounds.IntersectsWith(breh1.Bounds)))
            {
                doleva = 1;
            }
            if (lod.Bounds.IntersectsWith(breh2.Bounds))
            {
                doprava = 0;
            }
            if (!(lod.Bounds.IntersectsWith(breh2.Bounds)))
            {
               doprava = 1;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (doleva == 1)
            {//pohyb doleva lodě
                if (e.KeyCode == Keys.Left)
                {
                    lod.Left -= 5;
                    zavora.Left -= 5;
                    for (int x = 0; x < i; x++)
                    {//když je pismeno na lodi tak se hýbe společně s ní
                        if (pismenka[x].Bounds.IntersectsWith(lod.Bounds))
                        {
                            pismenka[x].Left -= 5;
                        }
                    }
                }
            }
            if (doprava == 1)
            {//pohyb doprava lodě
                if (e.KeyCode == Keys.Right)
                {
                    lod.Left += 5;
                    zavora.Left += 5;
                    for (int x = 0; x < i; x++)
                    {//když je pismeno na lodi tak se hýbe společně s ní
                        if (pismenka[x].Bounds.IntersectsWith(lod.Bounds))
                        {
                            pismenka[x].Left += 5;
                        }
                    }
                }
            }
        }

        private void pohyb_pismena_Tick(object sender, EventArgs e)
        {
            for(int x = 0; x < i; x++)
            {
                if (x < 1)
                {//pohyb pro prvni pismeno
                    if (((pismenka[x].Bounds.IntersectsWith(breh1.Bounds)) || ((pismenka[x].Bounds.IntersectsWith(lod.Bounds)))) && (!(pismenka[x].Bounds.IntersectsWith(zavora.Bounds))))
                    {//pohyb doprava kdyz jsou na levem brehu
                        pismenka[x].Left += 5;
                    }
                }
                if(x >= 1)
                {//kdyz uz jsou dve tak jestli se neprekrivaji a na lod se vejdou jen 3
                    if ((((pismenka[x].Bounds.IntersectsWith(breh1.Bounds))) || ((pismenka[x].Bounds.IntersectsWith(lod.Bounds)))) && (!(pismenka[x].Bounds.IntersectsWith(pismenka[x-1].Bounds))) && (!(pismenka[x].Bounds.IntersectsWith(zavora.Bounds))))
                    {//pohyb doprava kdyz jsou na levem brehu
                        pismenka[x].Left += 5;
                    }
                }

                if(!(pismenka[x].Bounds.IntersectsWith(breh1.Bounds)) && !(pismenka[x].Bounds.IntersectsWith(breh2.Bounds)) && !(pismenka[x].Bounds.IntersectsWith(lod.Bounds)))
                {//pohyb dolu kdyz jsou ve vzduchu
                    pismenka[x].Top += 5;
                }

                if (pismenka[x].Bounds.IntersectsWith(breh2.Bounds))
                {//pohyb doprava kdyz jsou na pravem brehu
                    pismenka[x].Left += 5;
                }

                if (x < 1)
                    if ((pismenka[x].Bounds.IntersectsWith(lod.Bounds)) && (lod.Bounds.IntersectsWith(breh2.Bounds)))
                    {//pohyb doprava kdyz je lod u brehu2
                    pismenka[x].Left += 5;
                    }
                if (x >= 1)
                    if ((pismenka[x].Bounds.IntersectsWith(lod.Bounds)) && (lod.Bounds.IntersectsWith(breh2.Bounds)) && (!(pismenka[x].Bounds.IntersectsWith(pismenka[x - 1].Bounds))))
                    {
                    pismenka[x].Left += 5;
                    }

                if (pismenka[x].Bounds.IntersectsWith(voda.Bounds))
                {//odstraneni kdyz spadnou do vody
                    pismenka[x].Location = new Point(70, 500);
                    this.Controls.Remove(pismenka[x]);
                    utopena++;
                    label3.Text = Convert.ToString(utopena);
                }

                if (pismenka[x].Bounds.IntersectsWith(konec.Bounds))
                {//kdyz dojede do cile
                    pismenka[x].Location = new Point(70, 500);
                    this.Controls.Remove(pismenka[x]);
                    zachranena++;
                    label4.Text = Convert.ToString(zachranena);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
