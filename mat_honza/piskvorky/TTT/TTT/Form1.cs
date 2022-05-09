using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Gameboard();
        }
        // definování multidimenzionálního pole
        Button[,] buttons = new Button[15, 15];

        void Gameboard()
        {
            // iterace jednotlivých řádků + sloupců
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    // vzhled hracího pole
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(30, 30);
                    buttons[i, j].Location = new Point(i * 30, j * 30);
                    buttons[i, j].FlatStyle = FlatStyle.Flat;   
                    buttons[i, j].Font = new Font(DefaultFont.FontFamily, 12, FontStyle.Bold);

                    // EventHandler - záznam kliknutí
                    buttons[i, j].Click += new EventHandler(button_Click);

                    // přidání objektů do panelu
                    gamepanel.Controls.Add(buttons[i, j]);
                }
            }
            /*
             *https://stackoverflow.com/questions/41285748/click-event-for-two-dimensional-button-array
             *https://stackoverflow.com/questions/13181258/c-sharp-using-2d-arrays-for-buttons
             *https://www.c-sharpcorner.com/uploadfile/mahesh/creating-a-button-at-run-time-in-C-Sharp/
             *https://stackoverflow.com/questions/1428504/how-add-button-control-on-frame-or-panel-at-runtime-in-c-sharp
             */
        }
        void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text != "")
            {
                return;
            }

            // Zobrazit hráče na tahu
            button.Text = ShowPlayer.Text;

            Player();
        }

        void Player()
        {
            Check();
            //-- Musí být v designeru[BUTTON - Vzhled-Text] nastaveno X nebo O -> |začínající znak| --
            if (ShowPlayer.Text == "X")
            {
                ShowPlayer.Text = "O";
            }
            else
            {
                ShowPlayer.Text = "X";
            }
        }

        public List<Button> Winner { get; set; } = new List<Button>();

        void Check()
        {
            // vertical
            for (int i = 0; i < 15; i++)
            {
                Winner = new List<Button>();
                for (int j = 0; j < 15; j++)
                {
                    HandleBtn(buttons[i, j]);
                }
            }

            // horizontal
            for (int i = 0; i < 15; i++)
            {
                Winner = new List<Button>();
                for (int j = 0; j < 15; j++)
                {
                    HandleBtn(buttons[j, i]);
                }
            }

            // diagonal top left->bottom right
            for (int k = 0; k < 15; k++)
            {
                Winner = new List<Button>();
                for (int i = k, j = 0; i < 15; i++, j++)
                {
                    HandleBtn(buttons[i, j]);
                }

                Winner = new List<Button>();
                for (int i = 0, j = k; j < 15; i++, j++)
                {
                    HandleBtn(buttons[i, j]);
                }
            }

            // diagonal (bottom-left to top-right)
            for (int k = 0; k < 9; k++)
            {
                Winner = new List<Button>();
                for (int i = 14, j = k; j < 15; i--, j++)
                {
                    HandleBtn(buttons[i, j]);
                }

                Winner = new List<Button>();
                for (int i = k, j = 0; i >= 0; i--, j++)
                {
                    HandleBtn(buttons[i, j]);
                }
            }
            foreach (var button in buttons)
            {
                    return;
            }

            MessageBox.Show("Game Draw");
            Application.Restart();

            //https://stackoverflow.com/questions/46472143/c-sharp-check-if-win-function-for-tictactoe
        }

        void HandleBtn(Button button)
        {
            if (button.Text != ShowPlayer.Text)
            {
                Winner.Clear();
            }
            else
            {
                Winner.Add(button);
            }

            if (Winner.Count == 5)
            {
                Show(Winner);
                return;
            }
        }
        void Show(List<Button> winner)
        {
            // vybarvení 5 výherních bloků
            foreach (var button in winner)
            {
                button.BackColor = Color.PowderBlue;
            }

            MessageBox.Show("Player " + ShowPlayer.Text + " wins");
            Application.Restart();
        }

    }
}