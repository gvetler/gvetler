using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuDANuceni
{

   

    public partial class Form1 : Form
    {

        public void oznaceni(object sender, EventArgs e) // sem sem si poslal souřadnice (x,y)
        {
            foreach (Control b in this.Controls)
            {

                if (b is Prvek)
                {
                    (b as Prvek).odznaceni();
                }

            }



            

            Prvek oznac = sender as Prvek; //vytvořim si prvek "oznac" a sender as prvek = vemu souřadnice a uložim je do "oznac"
            
            foreach (Control b in this.Controls)  //projedu včechny "controls" komponenty (textbox, label, atd.,...) a ulozi ji do proměnný "b"
            {
                if (b is Prvek) // pokud je to typu, který jsme si vytvořili "Prvek(textboxy) tak udělej...
                {
                    if (oznac.x == (b as Prvek).x)  //my chceme aby se zajímal jen o ten náš prvek o to naše "x" které jsme si tam zadali
                        b.BackColor = Color.Green;
                    if (oznac.y == (b as Prvek).y)
                        b.BackColor = Color.Green;
                    if (oznac.x / 3 == (b as Prvek).x / 3 && oznac.y / 3 == (b as Prvek).y / 3)
                        b.BackColor = Color.Green;


                }

                
                


            }



            

        }


        public Form1()
        {
            InitializeComponent();



            int g =0;
            for (int i=0; i<9; i++)
            {

                int c = 0;

                if (i % 3 == 0)
                {
                    g += 20;
                }
                for (int j=0; j<9; j++)
                {
                    

                    if (j % 3 == 0)
                    {
                        c += 20;
                    }
                    

                    Prvek a = new Prvek(i, j)
                    {
                        Width = 30, Height = 30, BackColor = Color.Azure, Multiline = true, Location = new Point (400 + 31*j+c,400+i*31+g)
                       


                    };




                    a.Click += oznaceni;  // pošleme souřadnice do "oznaceni()" souradnice ktere jsme si vytvořili pro texboxy
                    this.Controls.Add(a);

                }


            }


             


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }

    class Prvek : TextBox
    {
        public int x, y;

        

        public void odznaceni()
        {
            this.BackColor = Color.Azure;
        }
        


        public Prvek(int x, int y)  // konstruktor: provede se vždycky když se vytvoří objekt
        {

            this.x = x;
            this.y = y;

            



        }
    }


}
