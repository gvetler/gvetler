using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokladna
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);
        }
        private void Form1_Load(object sender, EventArgs e) 
        {
            this.KeyPreview = true;

            //Vytvoreni databaze
            Databaze databaze = new Databaze();
            string[] vysledekProcesu = databaze.vytvoritDatabazi();
            if (vysledekProcesu.Length > 0)
            {
                MessageBox.Show(vysledekProcesu[0]);
            }
        }

        private void BtnZadatManualne_Click(object sender, EventArgs e)
        {
            ZadaniPrihlasovacichUdajuManualne();
        }

        bool zadaneUzivatelskeJmeno = false;

        string uzivatelskeJmeno = "";
        string heslo = "";

        public void ZadaniPrihlasovacichUdajuManualne()
        {
            PrihlaseniManualne testDialog = new PrihlaseniManualne();
            testDialog.ShowDialog();

            testDialog.Dispose();

            //Prihlaseni do databaze
            Databaze databaze = new Databaze();
            if (databaze.prihlaseniDoSystemu(PrihlaseniManualne.uzivatelskeJmeno, PrihlaseniManualne.heslo) == true)
            {
                Form2 pokladniSystem = new Form2();
                this.Hide();
                pokladniSystem.Show();
            }
            else MessageBox.Show("Přihlášení proběhlo neúspěšně");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (zadaneUzivatelskeJmeno == false)
                {
                    zadaneUzivatelskeJmeno = true;
                    lblInstrukce.Text = "Naskenujte čárový kód hesla";
                    uzivatelskeJmeno = textBox1.Text;
                    textBox1.Text = "";
                }
                else
                {
                    heslo = textBox1.Text;
                    try
                    {
                        uzivatelskeJmeno = uzivatelskeJmeno.Remove(0, 5);
                    }
                    catch
                    {
                        MessageBox.Show("Jméno má moc krátký formát.");
                        uzivatelskeJmeno = "";
                        heslo = "";
                        textBox1.Text = "";
                        zadaneUzivatelskeJmeno = false;
                        lblInstrukce.Text = "Naskenujte čárový kód uživatele";
                    }
                    

                    Databaze databaze = new Databaze();
                    if (databaze.prihlaseniDoSystemu(uzivatelskeJmeno, heslo) == true)
                    {
                        Form2 pokladniSystem = new Form2();
                        this.Hide();
                        pokladniSystem.Show();
                    }
                    else
                    {
                        MessageBox.Show("Přihlášení proběhlo neúspěšně");
                        uzivatelskeJmeno = "";
                        heslo = "";
                        textBox1.Text = "";
                        zadaneUzivatelskeJmeno = false;
                        lblInstrukce.Text = "Naskenujte čárový kód uživatele";
                    }
                }
            }
        }
    }
}
