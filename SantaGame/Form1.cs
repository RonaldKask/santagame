using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SantaGame
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int leftSpeed = 6;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            santa.Top += gravity;
            flake.Left -= leftSpeed;
            moon.Left -= leftSpeed;
            hut.Left -= leftSpeed;
            tree.Left -= leftSpeed;
            scoreLabel.Text = $"score: {score}";

            if(flake.Left < -100)
            {
                flake.Left = 500;
                score++;
            }

            if(hut.Left < -100)
            {
                hut.Left = 500;
            }

            if(moon.Left < -100)
            {
                moon.Left = 600;
            }

            if(tree.Left < -100)
            {
                tree.Left = 822;
            }

            if(santa.Bounds.IntersectsWith(flake.Bounds) || santa.Bounds.IntersectsWith(hut.Bounds) ||
                santa.Bounds.IntersectsWith(ground.Bounds) || santa.Bounds.IntersectsWith(moon.Bounds)
                || santa.Bounds.IntersectsWith(tree.Bounds))
            {
                gameOver();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void gameOver()
        {
            timer1.Stop();
            scoreLabel.Text = $"Game Over!";
            playAgain.Visible = true;
        }

        private void playAgain_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }

        private void scoreLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
