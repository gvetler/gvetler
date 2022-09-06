using System;
using System.Drawing;
using System.Windows.Forms;


namespace generatorctverec
{
    public partial class Form1 : Form
    {
        // 
        private bool[,] kruh = new bool[28, 10];
        private bool[,] tri = new bool[28, 10];
        private bool[,] ctverce2 = new bool[28, 10];
        //

        private const int sirka2 = 100;
        private const int mezera2 = 15;

        public Form1()
        {
            InitializeComponent();
        }

        public void Generuj(Graphics g)
        {
            Brush brush;

            Random blue = new Random();
            Random green = new Random();
            Random red = new Random();
            Random yellow = new Random();

            Brush[] brushesblue = new Brush[]
            {
                Brushes.Aqua,
                Brushes.Aquamarine,
                Brushes.DarkCyan,
                Brushes.Navy,
                Brushes.RoyalBlue,
                Brushes.Blue,
                Brushes.CornflowerBlue,
                Brushes.DodgerBlue,
                Brushes.DeepSkyBlue,
                Brushes.LightSkyBlue,
                Brushes.MediumAquamarine,
                Brushes.MediumTurquoise,
                Brushes.Teal,
                Brushes.DarkBlue,
                Brushes.Cyan,            
            };

            Brush[] brushesgreen = new Brush[]
            {
                Brushes.SeaGreen,
                Brushes.DarkGreen,
                Brushes.GreenYellow,
                Brushes.Green,
                Brushes.MediumSpringGreen,
                Brushes.Lime,
                Brushes.Olive,
                Brushes.Chartreuse,
                Brushes.DarkOliveGreen,
                Brushes.DarkSeaGreen,
                Brushes.ForestGreen,
                Brushes.LawnGreen,
                Brushes.LightGreen,
                Brushes.OliveDrab,
                Brushes.PaleGreen,           
            };

            Brush[] brushesred = new Brush[]
            {
                Brushes.Crimson,
                Brushes.DarkRed,
                Brushes.DarkOrange,
                Brushes.DeepPink,
                Brushes.Fuchsia,
                Brushes.MediumOrchid,
                Brushes.Gold,
                Brushes.HotPink,
                Brushes.Red,
                Brushes.Tomato,
                Brushes.Orange,
                Brushes.LightSalmon,
                Brushes.Coral,
                Brushes.DarkRed,
                Brushes.DarkSalmon,
                Brushes.Violet,
            };

            Brush[] brushesyellow = new Brush[]
            {
                Brushes.Gold,
                Brushes.Goldenrod,
                Brushes.Khaki,
                Brushes.DarkGoldenrod,
                Brushes.DarkKhaki,
                Brushes.Yellow,
                Brushes.Moccasin,
                Brushes.SandyBrown,
                Brushes.Peru,
                Brushes.NavajoWhite,
                Brushes.LightYellow,
                Brushes.PapayaWhip,
                Brushes.Beige,
                Brushes.Bisque,
                Brushes.BurlyWood,
            };

            //vlastní 
            Random random = new Random();
            double k = random.Next(1000);
            k = k * 224 / 154745;


            //KONGURENTNÍ
            DateTime cas = DateTime.Now;
            double x = cas.Millisecond + cas.Millisecond; //x = seed
            x = (6969420 * x + 56789) % 1598746328; // (A * Xn + C) % M => A = zvolená konstanta, C = zvolená konstanta, M = modulo (zbytek po celočíselném dělení).
            x = x / 1598746328; // interval od 0 do 1

            // ctverec
            if (x < 0.3)
            {
                for (int j = 0; j < ctverce2.GetLength(1); j++)
                {
                    for (int i = 0; i < ctverce2.GetLength(0); i++)
                    {
                        if (k >= 0.50)
                        {
                            brush = brushesblue[blue.Next(brushesblue.Length)];

                            g.FillRectangle(brush, i * (sirka2 + mezera2), j * (sirka2 + mezera2), sirka2, sirka2);
                        }
                        else
                        {
                            brush = brushesgreen[green.Next(brushesgreen.Length)];

                            g.FillRectangle(brush, i * (sirka2 + mezera2), j * (sirka2 + mezera2), sirka2, sirka2);
                        }
                    }
                }
            }
            
            // kruh cely
            if (x >= 0.5 & x < 0.75)
            {
                for (int j = 0; j < kruh.GetLength(1); j++)
                {
                    for (int i = 0; i < kruh.GetLength(0); i++)
                    {
                        if (k  >= 0.50)
                        {
                            brush = brushesred[red.Next(brushesred.Length)];

                            g.FillEllipse(brush, i * (sirka2 + mezera2), j * (sirka2 + mezera2), sirka2, sirka2);
                        }
                        else
                        {
                            brush = brushesyellow[yellow.Next(brushesyellow.Length)];

                            g.FillEllipse(brush, i * (sirka2 + mezera2), j * (sirka2 + mezera2), sirka2, sirka2);
                        }                        
                    }
                }
            }
            
            // pulkruh dolni cast
            if (x >= 0.3 & x < 0.5)
            {
                for (int j = 0; j < tri.GetLength(1); j++)
                {
                    for (int i = 0; i < tri.GetLength(0); i++)
                    {
                        if (k >= 0.50)
                        {
                            brush = brushesred[red.Next(brushesred.Length)];
                            Rectangle rect = new Rectangle(i * (sirka2 + mezera2), j * (sirka2 + mezera2), sirka2, sirka2);

                            float startAngle = 0.0F;
                            float sweepAngle = 180.0F;

                            // Fill pie to screen.
                            g.FillPie(brush, rect, startAngle, sweepAngle);
                        }
                        else
                        {
                            brush = brushesblue[blue.Next(brushesblue.Length)];
                            Rectangle rect = new Rectangle(i * (sirka2 + mezera2), j * (sirka2 + mezera2), sirka2, sirka2);

                            float startAngle = 0.0F;
                            float sweepAngle = 180.0F;

                            // Fill pie to screen.
                            g.FillPie(brush, rect, startAngle, sweepAngle);

                        }
                    }
                }
            }

            // pulkruh horni cast
            if (x >= 0.75 & x <= 1)
            {
                for (int j = 0; j < tri.GetLength(1); j++)
                {
                    for (int i = 0; i < tri.GetLength(0); i++)
                    {
                        if (k >= 0.50)
                        {
                            brush = brushesgreen[green.Next(brushesgreen.Length)];
                            Rectangle rect = new Rectangle(i * (sirka2 + mezera2), j * (sirka2 + mezera2), sirka2, sirka2);

                            float startAngle = 180.0F;
                            float sweepAngle = 180.0F;

                            // Fill pie to screen.
                            g.FillPie(brush, rect, startAngle, sweepAngle);
                        }
                        else
                        {
                            brush = brushesyellow[yellow.Next(brushesyellow.Length)];
                            Rectangle rect = new Rectangle(i * (sirka2 + mezera2), j * (sirka2 + mezera2), sirka2, sirka2);

                            float startAngle = 180.0F;
                            float sweepAngle = 180.0F;

                            // Fill pie to screen.
                            g.FillPie(brush, rect, startAngle, sweepAngle);

                        }
                    }
                }
            }
            
        }
        // UNUSED
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Generuj(e.Graphics);
            pictureBox1.Image = null;
            System.Threading.Thread.Sleep(1000);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // FULLSCREEN + BORDERLESS
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

        }
    }
}
