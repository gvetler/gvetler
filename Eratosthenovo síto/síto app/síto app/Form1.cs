using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace síto_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(textBox1.Text);
            int[] pole = new int[max];
            int podminka = 0;

            for (int i = 0; i < pole.Length - 1; i++)
            {
                pole[i] = i + 2;
            }

            for (int i = 0; i < Math.Sqrt(pole.Max()); i++)
            {
                for (int j = 2; j < pole.Max(); j++)
                {
                    if (pole.Contains(pole[i] * j) && pole[i] != 0)
                    {
                        podminka = (pole[i] * j) - 2;
                        pole[podminka] = 0;
                    }
                }
            }

            for (int i = 0; i < pole.Length - 1; i++)
            {
                if (pole[i] != 0)
                {                   
                    textBox2.Text = pole[i] + " ";
                }
            }

        
        }
    }
}
