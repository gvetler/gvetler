using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIIII
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
            createField();

        }
        
        public int hrac = 2;
        public int tahy = 0;
        public int p1 = 0;
        public int p2 = 0;
        public int kol = 1;
        public int skoreHrac_1 = 0;
        public int skoreHrac_2 = 0;
        Button[,] buttony = new Button[15, 15];



        private void ButtonClick(object sender, EventArgs e)
        {
            

            Button button = (Button)sender;
            
            if ( hrac == 2) 
            {
                hrac = 1;
                hrac2Rada.Text = "JSI NA TAHU!";
                hrac1Rada.Text = "STOJÍŠ!";
                //button.BackgroundImage = Properties.Resources.X;
                button.Text = "X";
                kol++;
                radkyKontrola();
            }
            else
            {
                hrac = 2;
                hrac1Rada.Text = "JSI NA TAHU!";
                hrac2Rada.Text = "STOJÍŠ!";
                //button.BackgroundImage = Properties.Resources.O;
                button.Text = "O";
                kol++;
                radkyKontrola();
            }
            koloNum.Text = kol.ToString();


        }
        private void radkyKontrola()
        {
          
            int checkX = 0;
            int checkO = 0;
           
            for (int i = 0; i < 15; i++)
            {

                for (int j = 0; j < 15; j++)
                {

                    //if (buttons[i,j].BackgroundImage == Properties.Resources.X)
                    if (buttony[i, j].Text == "X")
                    {
                        checkX++;
                        if (checkX < 5 && checkO != 0)
                        {
                            checkX = 0;
                        }
                        //MessageBox.Show($"X= {checkX} O= {checkO}");
                    }
                    //else if (buttons[i, j].BackgroundImage == Properties.Resources.O)
                    else if (buttony[i, j].Text == "O")
                    {
                        checkO++;
                        if (checkO < 5 && checkX != 0)
                        {
                            checkO = 0;
                        }
                        //MessageBox.Show($"X= {checkX} O= {checkO}");
                    }

                    if (checkX == 5 || checkO == 5)
                    {
                        break;
                    }
                }
            }
            if (checkX == 5 || checkO == 5)
            {
                if (checkX == 5)
                {
                    MessageBox.Show("Hráč 1 vyhrál");
                    skoreHrac_1 += 10;
                    skoreHrac1.Text = skoreHrac_1.ToString();
                    novaHra();
                }
                else
                {
                    MessageBox.Show("Hráč 2 vyhrál");
                    skoreHrac_2 += 10;
                    skoreHrac2.Text = skoreHrac_2.ToString();
                    novaHra();
                }
                

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            skoreHrac1.Text = skoreHrac_1.ToString();
            skoreHrac2.Text = skoreHrac_2.ToString();
            hrac1Rada.Text = "JSI NA TAHU!";
            hrac2Rada.Text = "STOJÍŠ!";
        }
        private void createField()
        {

           

            // iterace jednotlivých řádků + sloupců
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    buttony[i, j] = new Button();
                    buttony[i, j].Size = new Size(30, 30);
                    buttony[i, j].Location = new Point(i * 32, j * 32);
                    buttony[i, j].Click += new EventHandler(ButtonClick);

                    // přidání objektů do panelu
                    gPanel.Controls.Add(buttony[i, j]);
                }
            }


        }

        private void novaHra()
        {
            gPanel.Controls.Clear();
            createField();
            kol = 1;
        }

    }

}
