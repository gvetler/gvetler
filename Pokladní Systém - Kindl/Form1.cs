using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace kasa
{
    public partial class kasa : Form
    {
        public kasa()
        {
            InitializeComponent();
        }
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=sklad.db;Version = 3;New = false;Compress = True:");
        }

        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            // sql_con.Close();
        }
        private void LoadData()
        {
            //načítání dat z databaze do datagridu
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select *from sklad";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            // sql_con.Close();
            id.Text = "";
        }

        private void Kasa_Load(object sender, EventArgs e)
        {
            LoadData();
            SetConnection();
            sql_con.Open();
            dataGridView1.Visible = false;
        }

        private void Id_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Id_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = !char.IsDigit(e.KeyChar);

            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if(id.Text.Length<9)
                {
                    int k = int.Parse(id.Text);
                    kus.Text = k.ToString();
                    listBox2.Items.Add(id.Text);
                    id.Text = "";
                   
                    
                }
                sql_cmd = new SQLiteCommand("Select Zbozi, Cena,Kusy from sklad where ID=@ID", sql_con);
                sql_cmd.Parameters.AddWithValue("@ID", id.Text.ToString());
                SQLiteDataReader da = sql_cmd.ExecuteReader();
                while (da.Read())
                {
                    zbozi.Text = da.GetValue(0).ToString();
                    cena.Text = da.GetValue(1).ToString();
                    kusy.Text = da.GetValue(2).ToString();

                }
                
                if(id.Text.Length >10)
                {
                    if (kus.Text == "")
                    {
                        kus.Text = "1";
                    }
                    int a = int.Parse(kusy.Text) - int.Parse(kus.Text);
                    listBox2.Items.Add(id.Text);
                    int celkemcena = int.Parse(celkemc.Text);
                int cenaa = int.Parse(cena.Text);
                int kuss = int.Parse(kus.Text);
                int bb = cenaa * kuss;
                listBox1.Items.Add(zbozi.Text);
                listBox1.Items.Add(bb);
                int cc = celkemcena +  cenaa * kuss;
                celkemc.Text = cc.ToString();
                string txtQuery = "update sklad set Zbozi='" + zbozi.Text + "',Cena='" + cena.Text + "',Kusy='" + a + "' where ID='" + id.Text.ToUpper() + "'";

                    id.Text = "";
                ExecuteQuery(txtQuery);
                LoadData();
                }

                
              
            }

           
        }

        private void Datagrid_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            this.Size = new Size (976, 310);
            
        }
    }
}
