using Digitalkirana.BusinessLogicLayer;
using Digitalkirana.DataAccessLayer;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digitalkirana.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        LoginBLL login = new LoginBLL();
        LoginDAL loginDAL = new LoginDAL();
        public static string fullName;
        public static string username;

        private void togglePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.UseSystemPasswordChar)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(textBoxUsername.Text==String.Empty && textBoxPassword.Text == String.Empty)
            {
                MessageBox.Show("Please enter username and password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (textBoxUsername.Text == String.Empty)
            {
                MessageBox.Show("Please enter username","Alert",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            else if(textBoxPassword.Text == String.Empty)
            {
                MessageBox.Show("Please enter password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                login.Username = textBoxUsername.Text;
                login.Password = textBoxPassword.Text;
                bool result = loginDAL.loginCheck(login);
                if (result)
                {
                    bool isActive = loginDAL.CheckIsActive(login);
                    if (isActive)
                    {
                    
                        login.UserType = loginDAL.getUserType(login);
                        fullName = loginDAL.getFullName(login);
                        username = loginDAL.getUsername(login);
                        if (login.UserType == "Admin")
                        {
                            AdminDashboard adminDashboard = new AdminDashboard();
                            this.Hide();
                            adminDashboard.ShowDialog();
                            reset();
                            Show();
                        }
                        else
                        {
                            UserDashboard userDashboard = new UserDashboard();
                            this.Hide();
                            userDashboard.ShowDialog();
                            reset();
                            Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This login user is currenlty inactive", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                }
                else
                {
                    MessageBox.Show("Incorrect username or password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

    }
}
