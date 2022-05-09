using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GORILY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Distance: 2 * V^2 * Sin(T) * Cos(T) / g = V^2 * Sin(2*T) / g

        private bool hrac;

        private const int VelikostBananu = 7;

        private double Theta, BulletX, BulletY, Vx, Vy;

        private const int TICKS_PER_SECOND = 10;

        private int Score1, Score2;

        private int PocetDomu = 11;

        Rectangle Gorila1, Gorila2;

        List<Rectangle> Domy;

        private const double YAcceleration =
            9.8 / (TICKS_PER_SECOND * TICKS_PER_SECOND);

        // Inicializuj.
        private void Form1_Load(object sender, EventArgs e)
        {
            tmrMoveShot.Enabled = false;
            tmrMoveShot.Interval = 100 / TICKS_PER_SECOND;

            PripravHru();
            DrawField(picCanvas.CreateGraphics());

        }

        void PripravHru()
        {
            Random rnd = new Random();
            Domy = new List<Rectangle>();
            int Sirka = picCanvas.Width / PocetDomu;
            for (int i = 0; i < PocetDomu; ++i)
            {
                int Vyska = rnd.Next(50, 220);
                Rectangle Domek = new Rectangle(i * Sirka, picCanvas.Height - Vyska, Sirka, Vyska);
                Domy.Add(Domek);
            }

            ZapniCudliky();
            buttonNewGame.Visible = false;
            int VyskaOpic = 50;
            int SirkaOpic = 26;

            lblKonec.Text = "";
            int tmp = rnd.Next(0, 3);
            // tmp * Sirka + Sirka / 2 - SirkaOpic / 2;
            Gorila1 = new Rectangle(tmp * Sirka + Sirka / 2 - SirkaOpic / 2, picCanvas.Height - Domy[tmp].Height - VyskaOpic, SirkaOpic, VyskaOpic);
            tmp = rnd.Next(1, 4);
            // tmp = tmp * Sirka + Sirka / 2 - SirkaOpic / 2;
            Gorila2 = new Rectangle(picCanvas.Width - tmp * Sirka + Sirka / 2 - SirkaOpic / 2, picCanvas.Height - Domy[PocetDomu - tmp].Height - VyskaOpic, SirkaOpic, VyskaOpic);

            Graphics gr = picCanvas.CreateGraphics();
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gr.Clear(picCanvas.BackColor);

            // OPICE.
            gr.FillEllipse(Brushes.Black, Gorila1);
            gr.FillEllipse(Brushes.Black, Gorila2);

            // BARAKY.
            bool barvicka = false;
            foreach (var x in Domy)
            {
                Brush br;
                if (barvicka) br = Brushes.DimGray;
                else br = Brushes.DarkCyan;
                gr.FillRectangle(br, x);
                barvicka = !barvicka;
            }
        }

        private void btnShoot1_Click(object sender, EventArgs e)
        {
            hrac = true;
            Strel();
        }

        private void btnShoot2_Click(object sender, EventArgs e)
        {
            hrac = false;
            Strel();
        }

        // spustí banán.
        private void Strel()
        {
            // Překreslí.
            using (Graphics gr = picCanvas.CreateGraphics())
            {
                DrawField(gr);
            }

            // ziská rychlost.
            float speed;
            try
            {
                if (hrac)
                {
                    speed = float.Parse(txtSpeed1.Text);
                }
                else
                {
                    speed = float.Parse(txtSpeed2.Text);
                }
            }
            catch
            {
                MessageBox.Show("Invalid speed", "Invalid Speed",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (speed < 1)
            {
                MessageBox.Show("Speed must be at least 1 mps",
                    "Invalid Speed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Dostane rychlost komponentů v metrech za tick.
            Vx = speed * Math.Cos(Theta) / TICKS_PER_SECOND;
            if (!hrac)
            {
                Vx *= -1;
            }
            Vy = -speed * Math.Sin(Theta) / TICKS_PER_SECOND; 

            VypniCudliky();

            Application.DoEvents();

            // Začne pohyb banánu.
            tmrMoveShot.Enabled = true;
        }

        void VypniCudliky()
        {
            // Vypne přístup k tlařítkům.
            btnShoot1.Enabled = false;
            txtDegrees1.Enabled = false;
            txtSpeed1.Enabled = false;
            btnShoot2.Enabled = false;
            txtDegrees2.Enabled = false;
            txtSpeed2.Enabled = false;
            Cursor = Cursors.WaitCursor;
        }
        void ZapniCudliky()
        {
            // Zapne přístup k tlačítkůmm.
            if (!hrac)
            {
                btnShoot1.Enabled = true;
                txtDegrees1.Enabled = true;
                txtSpeed1.Enabled = true;
            }
            else
            {
                btnShoot2.Enabled = true;
                txtDegrees2.Enabled = true;
                txtSpeed2.Enabled = true;
            }
            Cursor = Cursors.Default;
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            DrawField(e.Graphics);
        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }

        private void picCanvas_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            PripravHru();
        }

        // Namaluje Pole.
        private void DrawField(Graphics gr)
        {
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gr.Clear(picCanvas.BackColor);

            // OPICE.
            gr.FillEllipse(Brushes.Black, Gorila1);
            gr.FillEllipse(Brushes.Black, Gorila2);

            // BARAKY.
            bool barvicka = false;
            foreach (var x in Domy)
            {
                Brush br;
                if (barvicka) br = Brushes.DimGray;
                else br = Brushes.DarkCyan;
                gr.FillRectangle(br, x);
                barvicka = !barvicka;
            }
            // SPOCITA UHEL.
            try
            {
                if (!hrac)
                {
                    Theta = double.Parse(txtDegrees2.Text) * Math.PI / 180;
                }
                else
                {
                    Theta = double.Parse(txtDegrees1.Text) * Math.PI / 180;
                }
            }
            catch
            {
                Theta = 0;
            }
            if (Theta > Math.PI / 2) Theta = Math.PI / 2;
            if (Theta < 0) Theta = 0;

            if (hrac)
            {
                BulletX = Gorila1.X + Gorila1.Width + Math.Cos(Math.PI / 2 - Theta) / 2 + Math.Cos(Theta) * 0.6;
                BulletY = Gorila1.Y + 10 - Math.Sin(Math.PI / 2 - Theta) / 2 - Math.Sin(Theta) * 0.6;
            }
            else
            {
                BulletX = Gorila2.X - VelikostBananu + Math.Cos(Math.PI / 2 - Theta) / 2 + Math.Cos(Theta) * 0.6;
                BulletY = Gorila2.Y + 10 - Math.Sin(Math.PI / 2 - Theta) / 2 - Math.Sin(Theta) * 0.6;
            }
        }

        private void tmrMoveShot_Tick(object sender, EventArgs e)
        {
            // vymaže předchozí pozici banánu.
            using (Graphics gr = picCanvas.CreateGraphics())
            {

                Brush br = new SolidBrush(Color.FromArgb(250, 0, 78, 156));
                gr.FillEllipse(br, (float)(BulletX), (float)(BulletY),
                        VelikostBananu, VelikostBananu);

                // pohyb banánu.
                Vy += YAcceleration;
                BulletX += Vx;
                BulletY += Vy;

                int trefena = ZjistiZasah();
                if (trefena > 0 || BulletY > picCanvas.ClientRectangle.Height || BulletX > picCanvas.ClientRectangle.Width || BulletX < 0 || BulletY < -3000)
                {
                    tmrMoveShot.Enabled = false;
                    if (trefena == 0 || trefena == 3)
                    {
                        ZapniCudliky();
                    }
                    switch (trefena)
                    {
                        case 1:
                            Zasah(1);
                            break;
                        case 2:
                            Zasah(2);
                            break;
                    }
                }

                Brush barvaBananu;
                if (trefena > 0)
                {
                    barvaBananu = Brushes.Red;
                }
                else
                {
                    barvaBananu = Brushes.Yellow;
                }
                // Nakreslí banán.
                gr.FillEllipse(barvaBananu,
                    (float)(BulletX), (float)(BulletY),
                    VelikostBananu, VelikostBananu);

            }
        }

        // zjistí jestli banán zasáhl
        private int ZjistiZasah()
        {
            Rectangle banan = new Rectangle((int)BulletX, (int)BulletY, VelikostBananu, VelikostBananu);
            if (Gorila1.IntersectsWith(banan))
            {
                return 2;
            }
            else if (Gorila2.IntersectsWith(banan))
            {
                return 1;
            }

            foreach (var x in Domy)
            {
                if (x.IntersectsWith(banan))
                {
                    return 3;
                }
            }
            return 0;
        }

        // co se stane po zásahu
        void Zasah(int gorila)
        {
            Cursor = Cursors.Default;
            lblKonec.Text = "HRAC CISLO " + gorila + " VYHRAL!";
            if(gorila == 1)
            {
                Score1++;
            }
            else
            {
                Score2++;
            }
            lblScore.Text = Score1.ToString() + ":" + Score2.ToString();
            buttonNewGame.Visible = true;
        }



        private void txtChanged(object sender, EventArgs e)
        {
            DrawField(picCanvas.CreateGraphics());
        }
    }
}
