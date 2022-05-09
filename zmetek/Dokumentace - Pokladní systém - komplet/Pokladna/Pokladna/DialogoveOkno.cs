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
    public partial class DialogoveOkno : Form
    {
        public static string obsahTextboxu = "";
        public DialogoveOkno()
        {
            InitializeComponent();
        }

        private void DialogoveOkno_FormClosing(object sender, FormClosingEventArgs e)
        {
            obsahTextboxu = textBox1.Text;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                obsahTextboxu = textBox1.Text;
                this.Close();
            }
        }
    }
}
