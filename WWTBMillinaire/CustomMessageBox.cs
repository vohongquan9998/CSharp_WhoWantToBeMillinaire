using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WWTBMillinaire
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string message,bool multiText)
        {
            InitializeComponent();
            label1.Text = message;
            if(multiText)
            {
                pictureBox2.Height = 104;
                panel1.Height = 85;
            }
            else
            {
                pictureBox2.Height = 49;
                panel1.Height = 32;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            this.Visible =false;
        }
    }
}
