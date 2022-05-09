using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snakeDAN
{
    public partial class Form1 : Form
    {
        bool smer1, smer2, smer3, smer4 = false;
        PictureBox[] telo = new PictureBox[100];
        
        int zivot = 0;
        

        void generacetela()
        {

            int[] X = new int[zivot+1];
            int[] Y = new int[zivot+1];
            

            for (int i = 0; i <= zivot; i++)
            {
                X[i] = telo[i].Location.X;
                Y[i] = telo[i].Location.Y;

            }


            for (int i = 0; i<=zivot; i++)
            {
                if (i == 0)
                {
                    
                    if (smer1 == true)
                        telo[0].Location = new Point(telo[0].Location.X, telo[0].Location.Y - 30);
                    else if (smer2 == true)
                        telo[0].Location = new Point(telo[0].Location.X, telo[0].Location.Y + 30);
                    else if (smer3 == true)
                        telo[0].Location = new Point(telo[0].Location.X + 30, telo[0].Location.Y);
                    else if (smer4 == true)
                        telo[0].Location = new Point(telo[0].Location.X - 30, telo[0].Location.Y);
                    
                }

                else
                {
                    
                    telo[i].Location = new Point(X[i-1],Y[i-1]);
                    
                }

                


            }

        }


        void generacejidla()
        {
            if (telo[0].Location == pictureBox2.Location)
            {
                Random random = new Random();
                pictureBox2.Location = new Point(((random.Next(0, 1200)) / 30) * 30, ((random.Next(0, 900)) / 30) * 30);
                
                zivoty();
            }
                
        }
        void generacehlavy()
        {
            Random random = new Random();
            
            
            telo[0] = new PictureBox
            {
                BackColor = Color.Black, Width = 30, Height = 30,
                Location = new Point(((random.Next(0, 1200)) / 30) * 30, ((random.Next(0, 900)) / 30) * 30)
                

            };
           
            

            pictureBox2.Location = new Point(((random.Next(0, 1200)) / 30) * 30, ((random.Next(0, 900)) / 30) * 30);

            this.Controls.Add(telo[0]);
        }
        
        void zivoty()
        {
            zivot++;
            telo[zivot] = new PictureBox
            {
                BackColor = Color.Green, Width = 30, Height = 30

            };

            

            this.Controls.Add(telo[zivot]);
           
        }

        void kolize()
        {
            for (int i = 1; i <=zivot; i++)
            {
                if (telo[0].Location == telo[i].Location)
                {
                    timer1.Stop();
                    label1.Text = "game over!";


                }


            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            generacejidla();
            generacetela();
            kolize();

           
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            
            InitializeComponent();
            this.KeyPreview = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {


            generacehlavy();

            timer1.Start();


            button1.Visible = false;
            

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
            {
                smer1 = true;
                smer2 = false;
                smer3 = false;
                smer4 = false;
            }

            else if (e.KeyData == Keys.S)
            {
                smer2 = true;
                smer1 = false;
                smer3 = false;
                smer4 = false;

            }

            else if (e.KeyData == Keys.D)
            {
                smer3 = true;
                smer2 = false;
                smer1 = false;
                smer4 = false;

            }

            else if (e.KeyData == Keys.A)
            {
                smer4 = true;
                smer1 = false;
                smer2 = false;
                smer3 = false;

            }
        }
    }
}
