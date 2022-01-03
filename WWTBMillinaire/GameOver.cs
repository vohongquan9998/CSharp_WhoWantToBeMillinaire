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
    public partial class GameOver : Form
    {
        string score;
        int currentPlayerID;
        public GameOver(string score,int currentPlayerID)
        {
            InitializeComponent();
            this.score = score;
            this.currentPlayerID = currentPlayerID;
            lbScore.Text = score;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new PlayingScreen(currentPlayerID).ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Visible =false;

        }

        private void GameOver_Load(object sender, EventArgs e)
        {

        }
    }
}
