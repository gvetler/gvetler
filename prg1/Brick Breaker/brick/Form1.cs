using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace brick
{
    
    public partial class Form1 : Form
    {

        System.Media.SoundPlayer p = new System.Media.SoundPlayer();
        


        public Form1()
        {
            InitializeComponent();
            p.SoundLocation = "hra.wav";
            p.PlayLooping();
            
        }
        int ball_x = 5;
        int ball_y = 4;
        int score = 0;
        private void Score()
        {
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox &&x.Tag=="blok")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        ball_y = -ball_y;
                        score++;
                        label1.Text = "Skóre: " + score;
                        
                    }
                }
            }
        }
        
        private void Konec()
        {
            
            if (score == 18)
            {
                timer1.Stop();
                p.Stop();
                axWindowsMediaPlayer1.URL = "uspech.wav";
                axWindowsMediaPlayer1.Ctlcontrols.play();
                MessageBox.Show("Vyhrál si");
                MessageBox.Show("Pro vypnutí hry stuskněte ESC a pro restart hry Enter");
                

            }
            if (ball.Top + ball.Height > ClientSize.Height)
            {
                timer1.Stop();
                p.Stop();
                axWindowsMediaPlayer2.URL = "end.wav";
                axWindowsMediaPlayer2.Ctlcontrols.play();
                ball.Update();
                ball.ResetText();
                
                Ball_move();
               //MessageBox.Show("Skončil si, tvoje skóre je: " + score);
                //MessageBox.Show("Pro vypnutí hry stuskněte ESC, a pro restart hry Enter");
                


            }
        }
        private void Ball_move()
        {
           
            ball.Left += -ball_x;
            ball.Top += ball_y;
          

            if (ball.Left+ball.Width>ClientSize.Width||ball.Left<0)
            {
                ball_x = -ball_x;
            }
           
            if(ball.Top<0|| ball.Bounds.IntersectsWith(player.Bounds))
            {
                ball_y = -ball_y;
            }
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && player.Left > 0)
            {
                player.Left -= 12;

            }
            if (e.KeyCode == Keys.Right && player.Right < 630)
            {
                player.Left += 12;
            }
            if (e.KeyCode == Keys.Escape)
            {
                System.Windows.Forms.Application.Exit();

            }
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.Application.Restart();

            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
          
            Ball_move();
            Score();
            Konec();
            
   
           


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }
    }
}
