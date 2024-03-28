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
    public partial class ChooseTheme : Form
    {
        public ChooseTheme()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            
            Bitmap objBitmap = new Bitmap(Image.FromFile("back01.png"), new Size(200,100));
            button1.Size = new Size(200, 100);
            button1.Image = objBitmap;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.Text = "";

            Bitmap objBitmap2 = new Bitmap(Image.FromFile("back02.png"), new Size(200, 100));
            button2.Size = new Size(200, 100);
            button2.Image = objBitmap2;
            button2.ImageAlign = ContentAlignment.MiddleRight;
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.Text = "";

            Bitmap objBitmap3 = new Bitmap(Image.FromFile("back03.png"), new Size(200, 100));
            button3.Size = new Size(200, 100);
            button3.Image = objBitmap3;
            button3.ImageAlign = ContentAlignment.MiddleRight;
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.Text = "";

        }

        ChooseCharacter characterForm;
        private void button1_Click(object sender, EventArgs e)
        {
            characterForm = new ChooseCharacter(1); 
            this.Hide();
            characterForm.ShowDialog();     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            characterForm = new ChooseCharacter(2);
            this.Hide();
            characterForm.ShowDialog();         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            characterForm = new ChooseCharacter(3);
            this.Hide();
            characterForm.ShowDialog();            
        }
    }
}
