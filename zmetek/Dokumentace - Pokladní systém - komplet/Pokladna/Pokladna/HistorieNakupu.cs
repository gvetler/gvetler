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
    public partial class HistorieNakupu : Form
    {
        public HistorieNakupu()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);
        }

        private void HistorieNakupu_Load(object sender, EventArgs e)
        {
            Databaze databaze = new Databaze();
            List<List<string>> historieNakupu = databaze.nacistHistoriiNakupu();

            for (int i = 0; i < historieNakupu.Count; i++)
            {
                datagridPrehledNakupu.Rows.Add();
                for (int j = 0; j < 4; j++)
                {
                    datagridPrehledNakupu.Rows[datagridPrehledNakupu.Rows.Count - 2].Cells[j].Value = historieNakupu[i][j];
                }
            }

            nastavitVelkostSloupcu();
        }

        private void nastavitVelkostSloupcu()
        {
            int velikostSloupce = 120;
            for (int i = 0; i < datagridPrehledNakupu.Columns.Count; i++)
            {
                datagridPrehledNakupu.Columns[i].Width = velikostSloupce;
            }
        }


    }
}
