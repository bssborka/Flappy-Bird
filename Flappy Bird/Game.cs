using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Game : Form
    {
       
        int pipeSpeed = 8;
        int gravity = 5;
        int scoreCount = 0;
        private List<string> frames = new List<string>(new String[]
        {
            "001","002","003","004","005","006","007","008","009"
        });
        private int currFrame = 0;
        int backId, charId;
        public Game(int backID, int charID)
        {
            backId = backID;
            charId = charID;        
            
            
            
            InitializeComponent();
            

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            bottom = new pb()
            {
                Location = new Point(480, 500),
                Size = new Size(260, 250),
                Parent = this,
                BackColor=Color.Transparent,
                SizeMode= PictureBoxSizeMode.StretchImage
            };
            top = new pb()
            {
                Location = new Point(840, -3),
                Size = new Size(260, 250),
                Parent = this,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            switch (backId)
            {
                case 1:
                    this.BackgroundImage = (Bitmap)Image.FromFile("back01.png");
                    top.Image = (Bitmap)Image.FromFile("treeBottom01.png");
                    bottom.Image = (Bitmap)Image.FromFile("treeUp01.png");
                    break;
                case 2:
                    this.BackgroundImage = (Bitmap)Image.FromFile("back02.png");
                    top.Image = (Bitmap)Image.FromFile("treeBottom02.png");
                    bottom.Image = (Bitmap)Image.FromFile("treeUp02.png");
                    break;
                case 3:
                    this.BackgroundImage = (Bitmap)Image.FromFile("back03.png");
                    top.Image = (Bitmap)Image.FromFile("treeBottom03.png");
                    bottom.Image = (Bitmap)Image.FromFile("treeUp03.png");
                    break;                    
            }
            over.Visible = false;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currFrame = ((currFrame + 1) % frames.Count());
            Bitmap bmp;
            switch (charId)
            {
                case 1:
                    bmp = (Bitmap)Image.FromFile("grey/" + frames[currFrame] + ".png");
                    bird.Image = bmp;
                    break;
                   case 2:
                    bmp = (Bitmap)Image.FromFile("cockatiel/" + frames[currFrame] + ".png");
                    bird.Image = bmp;
                    break;
                case 3:
                    bmp = (Bitmap)Image.FromFile("blue/" + frames[currFrame] + ".png");
                    bird.Image = bmp;
                    break;

            }

            bird.Top += gravity;
            bottom.Left -= pipeSpeed;
            top.Left -= pipeSpeed;
            if (bottom.Left < -50)
            {
                bottom.Left = 800;
                scoreCount++;
                if (scoreCount % 5 == 0 && scoreCount != 0)
                {
                    pipeSpeed += 4;
                }
            }
            if (top.Left<-80)
            {
                top.Left = 950; 
                scoreCount++;             
            }
            score.Text = "Score: " + scoreCount.ToString();
            if (bird.Bounds.IntersectsWith(bottom.Bounds) ||
                bird.Bounds.IntersectsWith(top.Bounds)||
                bird.Bounds.IntersectsWith(ground.Bounds)|| 
                bird.Top < -25)
            {
                endGame();
            }          
            
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Space)
            {
                gravity = -15;
            }
        }

        private void GameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void endGame()
        {
            timer1.Stop();
            over.Visible = true;
        }
    }
}
