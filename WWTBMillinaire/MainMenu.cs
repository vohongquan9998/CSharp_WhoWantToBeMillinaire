using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WWTBMillinaire.Control;

namespace WWTBMillinaire
{
    public partial class FormLogin : Form
    {
        int currentPlayerID;
        public FormLogin()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            if(txtNick.TextLength==0)
            {
                new CustomMessageBox("Please enter your nickname to login?", false).ShowDialog();
            }
            else if(txtPass.TextLength==0)
            {
                new CustomMessageBox("Please enter your password to login?", false).ShowDialog();
            }
            else
            {

                string queryCheckAccount = "SELECT * FROM player WHERE NickName=@nick AND Password=@pass";
                SqlDataReader reader = new Process().sqlDataReader(queryCheckAccount,new string[] { "nick", "pass" },new object[] {txtNick.Text,txtPass.Text });
                if (reader.Read())
                {
                    this.Visible = false;
                    currentPlayerID = Convert.ToInt32(reader["Id"]);
                    bool isAdmin = (bool)reader["isAdmin"];
                    if(isAdmin)
                    {
                        new FormForAdmin().ShowDialog();
                    }
                    else
                    {
                        new PlayingScreen(currentPlayerID).ShowDialog();
                    }
                }
                else
                {
                    new CustomMessageBox("Login failed. Please check your nickname & password again",false).ShowDialog();
                }
            }
            
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            new QuestionManagement().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new UpdateQuestionManagement().ShowDialog();
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            //HDMSYIB
            
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new Register().ShowDialog();
        }
    }
}
