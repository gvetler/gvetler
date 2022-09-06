using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sibenice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GameStart();
        }

        private string sentence;
        private int errors = 0;
        private IEnumerable<char> selectedChars = new List<char>();
        private Random random = new Random();

        private void GameStart()
        {
            sentence = GetSentence();
            selectedChars = new List<char>();
            errors = 0;
            lblSentence.Text = GetMask();
            LoadPicture(errors);
            ShowAllButtons();
        }

        private string GetSentence()
        {
            string filename = GetAppDir + "\\vyraz.txt";
            if (File.Exists(filename))
            {
                string[] sentences = File.ReadAllLines(filename, Encoding.GetEn­coding("utf-8"));
                int i = random.Next(0, sentences.Count() - 1);
                return sentences[i].ToUpper();
            }
            else
            {
                MessageBox.Show(String.Format("Soubor nebyl nalezen", filename));
            }
            return "";
        }

        // NAČTE PO PROHŘE OPĚT TLAČÍTKA
        private void ShowAllButtons()
        {
            foreach (Control ctrl in pnlButtons.Controls)
                if (ctrl is Button)
                {
                    (ctrl as Button).Visible = true;
                }
        }

        // ZAMASKUJE HADANOU VEC OTAZNIKAMA
        private string GetMask()
        {
            string mask = "";
            foreach (char c in sentence)
            {
                if (c == ' ' || selectedChars.Contains(c))
                    mask = mask + c;
                else
                    mask = mask + "?";
            }
            return mask;
        }

        private bool Win()
        {
            foreach (char c in sentence)
            {
                if (c != ' ' && !selectedChars.Contains(c))
                    return false;
            }
            return true;
        }

        private void GameWin()
        {
            MessageBox.Show("Vyhrál Jsi!");
            GameStart();
        }

        private IList<char> GetCharList(char c)
        {
            IList<char> list = new List<char>();
            list.Add(c);
            // PO KLIKU TLAČÍTKA VYBERE DALŠÍ VARIANTY NAPŘ. Ě
            switch (c)
            {
                case 'I':
                    list.Add('Í');
                    break;
                case 'A':
                    list.Add('Á');
                    break;
                case 'E':
                    list.Add('É');
                    list.Add('Ě');
                    break;
                case 'U':
                    list.Add('Ú');
                    list.Add('Ů');
                    break;
                case 'O':
                    list.Add('Ó');
                    break;
                case 'Y':
                    list.Add('Ý');
                    break;
                default:
                    break;
            }
            return list;
        }


        private bool Hit(IList<char> list)
        {
            foreach (char c in sentence)
                if (list.Contains(c))
                    return true;
            return false;
        }

        private string GetAppDir
        { 
            get
            {
                FileInfo fi = new FileInfo(Application.ExecutablePath);
                return fi.DirectoryName;
            }
        }

        // CESTA K OBRÁZKUM A NAČÍTÁNÍ
        private bool LoadPicture(int i)
        {
            string dir = GetAppDir + @"\pics\";
            string filename = dir + i.ToString().PadLeft(2, '0') + ".bmp";
            if (File.Exists(filename))
            { 
                pbPicture.Image = new Bitmap(filename);
                return true;
            }
            return false;
        }

        // ZOBRAZÍ KONEC HRY A RESETUJE JI
        private void GameOver()
        {
            MessageBox.Show("Prohrál jsi!\nHledaný výraz byl: " + sentence);
            GameStart();
        }

        // NAČTE OBRÁZKY PO KAŽDÉ CHYBĚ
        private void Miss()
        {
            errors++;
            bool ok = LoadPicture(errors);
            if (!ok)
                GameOver();
        }

        // NASTAVENÍ TLAČÍTEK
        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            if (btn != null)
            {
                char c = btn.Text[0];
                IList<char> list = GetCharList(c);
                bool hit = Hit(list);
                selectedChars = selectedChars.Concat(list);
                if (hit)
                {
                    lblSentence.Text = GetMask();
                    btn.Visible = false;
                    bool win = Win();
                    if (win)
                    {
                        GameWin();
                    }
                }
                else
                {
                    btn.Visible = false;
                    Miss();
                }
            }
        }
    }
}
