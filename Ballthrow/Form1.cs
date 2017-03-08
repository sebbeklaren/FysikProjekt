using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ballthrow
{
    public partial class Form1 : Form
    {
        Game1 myGame;

        public Form1(Game1 myGame)
        {
            this.myGame = myGame;
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float startX;
            float startY;
            float speed;
            float degrees;
            
            if(float.TryParse(textBox1.Text, out startX) && float.TryParse(textBox2.Text, out startY) &&
                float.TryParse(textBox3.Text, out speed) && float.TryParse(textBox4.Text, out degrees))
            {
                myGame.SetStartX(startX);
                myGame.SetStartY(startY);
                myGame.SetStartVelocity(speed, degrees);
                
            }
            else
                MessageBox.Show("ej giltigt flyttalsformat");

        }


    }
}
