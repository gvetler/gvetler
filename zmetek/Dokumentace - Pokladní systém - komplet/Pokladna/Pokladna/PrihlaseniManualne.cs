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
    public partial class PrihlaseniManualne : Form
    {
        public static string uzivatelskeJmeno = "";
        public static string heslo = "";
        public PrihlaseniManualne()
        {
            InitializeComponent();
        }

        private void PrihlaseniManualne_Load(object sender, EventArgs e)
        {
            txtUzivatelskeJmeno.PasswordChar = '*';
            txtHeslo.PasswordChar = '*';
        }

        private void PrihlaseniManualne_FormClosing(object sender, FormClosingEventArgs e)
        {
            uzivatelskeJmeno = txtUzivatelskeJmeno.Text;
            heslo = txtHeslo.Text;
        }

        private void btnPrihlasit_Click(object sender, EventArgs e)
        {
            uzivatelskeJmeno = txtUzivatelskeJmeno.Text;
            heslo = txtHeslo.Text;
            this.Close();
        }
    }
}
