using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace reakcidoba
{
    public partial class Form1 : Form
    
       
    {
        private static readonly Stopwatch watch = new Stopwatch(); //stopky
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            deaktivujbuttons();
            
             
            if (textBox3.Text == "")
            {
                textBox3.Text = 0.000.ToString();
            }
           

        }
       


        private void deaktivujbuttons()  //deaktivování buttonů
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

        }
        private void kontrolavys()
        {
            if (listBox1.Items.Count > 9) //konec programu po 10 pokusech
            {
                deaktivujbuttons();
                button6.Enabled = false;
                prumer();
                MessageBox.Show("Konec koukni se na výsledky");
                //textBox4.Text = a.ToString();
                //MessageBox.Show(a.ToString());
                
                

            }
        }

        private void button6_Click(object sender, EventArgs e) //tlačítko start, když se zmáčkne stopky se rozběhnou a zastaví pokud klikneme na tlačíko(zmackni)
        {       //random number generator jaké tlačítko se zobrazí
                kontrolavys();
                //if(button1Was)
                watch.Restart();
                deaktivujbuttons();

                Random btn = new Random();
                int cislo = btn.Next(0, 5);
                if (cislo == 0)
                {
                button1.Visible = true;
                button1.Enabled = true;
                     watch.Start();
                    
                }
                if (cislo == 1)
                {
                button2.Visible = true;
                button2.Enabled = true;
                    watch.Start();
            }
                if (cislo == 2)
                {
                    button3.Visible = true;
                    button3.Enabled = true;
                    watch.Start();
            }
                if (cislo == 3)
                {
                    button4.Visible = true;
                    button4.Enabled = true;
                    watch.Start();

            }
                if (cislo == 4)
                {
                     button5.Visible = true;
                    button5.Enabled = true;
                    watch.Start();
            }
           
        }
        private bool b1 = false;
        private bool b2 = false;
        private bool b3 = false;
        private bool b4 = false;
        private bool b5 = false;
        //private bool b6 = false;
        private void Napis() //vypsaní do listboxu
        {
            if (watch.Elapsed.Seconds == 0)
            {
                listBox1.Items.Add(GetTimeString(watch.Elapsed));
            }
            
          
        }
        private void max() //hledání maxima porovnání v textboxech s aktuální hodnout
        {
            if(watch.Elapsed.Seconds > 0)
            {
                MessageBox.Show("Hodnota byla větší jak 1 sekunda nebude se počítat do hodnocení celkového");
            }
            
            if (watch.Elapsed.Seconds ==0)
        {
            if(int.Parse(textBox1.Text) < watch.Elapsed.Milliseconds)
            {
                textBox1.Text = watch.Elapsed.Milliseconds.ToString();
            }
        }
    }
        private void min() //hledání minima porovnání v textboxech s aktuální hodnout
        {
            if (watch.Elapsed.Seconds > 0)
            {
                MessageBox.Show("Hodnota byla větší jak 1 sekunda nebude se počítat do hodnocení celkového");
            }
           
            if (watch.Elapsed.Seconds == 0)
            {
                if (int.Parse(textBox2.Text) > watch.Elapsed.Milliseconds)
                {
                    textBox2.Text = watch.Elapsed.Milliseconds.ToString();
                }
            }
        }
        private void prumer() //hledání pruměru (pomaham si pomocnym textboxem)
        {
            int a = int.Parse(textBox4.Text);
            int b = a / 10;
            textBox3.Text = b.ToString();
           
        }

        private string GetTimeString(TimeSpan elapsed) //string format do list boxu
        {
            string result = string.Format("{0} s {1} ms", elapsed.Seconds, elapsed.Milliseconds);
            return result;
        }

        //tlačítka zmackni
        private void button1_Click(object sender, EventArgs e) 
        {
            b1 = true;
            int a = int.Parse(textBox4.Text) + watch.Elapsed.Milliseconds;  // pricitani do pomocneho textboxu
            textBox4.Text = a.ToString();
           
            Napis();
            max();
            min();
            //prumer();
            kontrolavys();
            if(b1 == true) //deaktivování buttonu pokud se zmackne tlacitko zmackni
            {
                deaktivujbuttons();
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            b2 = true;
            int a = int.Parse(textBox4.Text) + watch.Elapsed.Milliseconds;
            textBox4.Text = a.ToString();
            Napis();
            max();
            min();
            //prumer();
            kontrolavys();
            if (b2 == true)
            {
                deaktivujbuttons();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            b3 = true;
            int a = int.Parse(textBox4.Text) + watch.Elapsed.Milliseconds;
            textBox4.Text = a.ToString();

            Napis();
            max();
            min();
            //prumer();
            kontrolavys();
            if (b3 == true)
            {
                deaktivujbuttons();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            b4 = true;
            int a = int.Parse(textBox4.Text) + watch.Elapsed.Milliseconds;
            textBox4.Text = a.ToString();

            Napis();
            max();
            min();
            //prumer();
            kontrolavys();
            if (b4 == true)
            {
                deaktivujbuttons();
            }
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            b5 = true;
            int a = int.Parse(textBox4.Text) + watch.Elapsed.Milliseconds;
            textBox4.Text = a.ToString();
            Napis();
            max();
            min();
           // prumer();
            kontrolavys();
            if (b5 == true)
            {
                deaktivujbuttons();
            }
           
        }

        
        //zobraz listbox tlačítko
        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
        }
        //restart tlačítko
        private void button8_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }
    }
}
