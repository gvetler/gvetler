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
using System.IO.Ports;
using System.Text.RegularExpressions;
namespace rfid
{
    public partial class RFID : Form
    {
        public RFID()
        {
            InitializeComponent();
        }
        //definování
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();


        //pripojeni databaze
        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=lidi.db;Version = 3;New = false;Compress = True:");
        }

        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        
        private void LoadData()
        {
            //načítání dat z databaze do datagridu
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select *from zamestnanci";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            sql_con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            //nastavení pracovní doby
            TimeSpan zac = TimeSpan.Parse("06:00"); // zacatek prace v 6
            TimeSpan kon = TimeSpan.Parse("18:00");   // konec v 6
            TimeSpan ted = DateTime.Now.TimeOfDay;
            if (ted >= kon || ted <= zac)
            {
                MessageBox.Show("Ještě není pracovní doba");
                idbox.Enabled = false;
            }
        }
        public void komunikace()
        {

            //nastavení komunikace
            SerialPort com = new SerialPort();
            com.PortName = "COM8";
            com.BaudRate = 19200;
            //com.Handshake = Handshake.None;
            com.Parity = Parity.None;
            com.DataBits = 8;
            com.StopBits = StopBits.One;
            com.Open();
            //vypis do textboxu
            //string kod = "qwertzuioplkjhgfdsayxcvbnm1234567890";
            string s = com.ReadLine().Trim();
            idbox.Text = s;
           
            com.Close();
        }
            //string s = com.ReadLine();
            
        

        //kliknutí na načti id(komunikace seriova)
        private void button1_Click(object sender, EventArgs e)
        {
            komunikace();
        }
        //pri zmene textu se vyplní ostatní textboxu
        private void idbox_TextChanged(object sender, EventArgs e)
        {
            
            //pripojeni databaze
            SetConnection();
            sql_con.Open();
            if (idbox.Text != "")
                {
                    sql_cmd = new SQLiteCommand("Select Jmeno, Dvere, skupina,pristup from zamestnanci where ID=@ID", sql_con);
                    if (idbox.Text.Length < 9) //definování délky id (pokud vyhovuje vypise) 
                    {
                        //vyplnení zbylych textboxu podle id
                        sql_cmd.Parameters.AddWithValue("@ID", idbox.Text.ToUpper());
                        SQLiteDataReader da = sql_cmd.ExecuteReader();
                        while (da.Read())
                        {
                            textBox1.Text = da.GetValue(0).ToString();
                            textBox2.Text = da.GetValue(1).ToString();
                            textBox3.Text = da.GetValue(2).ToString();
                            textBox4.Text = da.GetValue(3).ToString();
                        }
                    }
                    if (idbox.Text.Length > 8)//nevyhovuje
                    {
                        MessageBox.Show("Zadal si špatně id");
                        idbox.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                    sql_con.Close();

                    if (textBox4.Text == "povolen") //když je pristup 1 tak se otevrou dvere
                    {
                        MessageBox.Show("Pristup povolen");
                        //ZAPIS DO TABULKY LOG
                        string txtQuery = " insert into log(ID,jmeno,dvere,skupina,pristup,cas,datum)values('" + idbox.Text.ToUpper() + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + DateTime.Now.ToString("dd.MM.yyyy") + "')";
                        ExecuteQuery(txtQuery);
                    }
                    else
                    if (textBox4.Text == "nepovolen") //když je pristup 0 tak se neotevrou dvere
                    {
                        MessageBox.Show("Pristup nepovolen");
                        string txtQuery = " insert into log(ID,jmeno,dvere,skupina,pristup,cas,datum)values('" + idbox.Text.ToUpper() + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + DateTime.Now.ToString("dd.MM.yyyy") + "')";
                        ExecuteQuery(txtQuery);
                    }
                    textBox4.Text = "";
                
            }
            

        }
        //podle skupiny povolení práv
        //editace databaze (aktivuje se "skryté menu")
        private void edit_Click(object sender, EventArgs e)
        {
            pridej.Visible = true;
            smaz.Visible = true;
            uprav.Visible = true;
            dataGridView1.Visible = true;
            Size = new Size(816, 345);
        }
        //smazani konkrtetního zamestnance
        private void smaz_Click(object sender, EventArgs e)
        {
            string txtQuery = "delete from zamestnanci where ID='" + idbox.Text.ToUpper() + "'";
            ExecuteQuery(txtQuery);
            LoadData();
        }
        //upravit databazi(zamestnance)
        private void uprav_Click(object sender, EventArgs e)
        {
            string txtQuery = "update zamestnanci set Jmeno='" + textBox1.Text + "',Dvere='" + textBox2.Text + "',skupina='" + textBox3.Text + "' where ID='" + idbox.Text.ToUpper() + "'";
            ExecuteQuery(txtQuery);
            LoadData();
        }
        //pridani nového zaměstnance
        private void pridej_Click_1(object sender, EventArgs e)
        {
            string txtQuery = "insert into zamestnanci(ID,jmeno,dvere,skupina,pristup)values('" + idbox.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            ExecuteQuery(txtQuery);
            LoadData();
        }
        //kliknutí na šipku v datagridu (vypíše do textboxů)
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idbox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
        //podle dveří a skupiny se vyhodnotí přístup    
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SetConnection();
            sql_con.Open();
        
            if(textBox2.Text.Length == 5 | textBox2.Text.Length ==6)
            {
                if (textBox3.Text != "")
                {
                    //vyplnení zbyleho textboxu pokud najde v databazi prislusne dvere a skupinu pak vyhodnotí pristup
                    sql_cmd = new SQLiteCommand("Select pristup from skupiny where dvere = @dvere AND skupina = @skupina", sql_con); 
                    sql_cmd.Parameters.AddWithValue("@dvere", textBox2.Text.ToLower());
                    sql_cmd.Parameters.AddWithValue("@skupina", textBox3.Text.ToLower());
                    SQLiteDataReader daa = sql_cmd.ExecuteReader();
                    while (daa.Read())
                    {
                        textBox4.Text = daa.GetValue(0).ToString();
                    }
                }
            }
            sql_con.Close();          
        }

   

        

        
    }
}

