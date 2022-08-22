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

        MySqlConnection con = new MySqlConnection(Connection.connectionString);

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
            textBoxUsername.Clear();
            textBoxPassword.Clear();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(textBoxUsername.Text==String.Empty && textBoxPassword.Text == String.Empty)
            {
                MessageBox.Show("Please enter username and password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxUsername.Text == String.Empty)
            {
                MessageBox.Show("Please enter username","Alert",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if(textBoxPassword.Text == String.Empty)
            {
                MessageBox.Show("Please enter password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //code
                try
                {
                    string username = textBoxUsername.Text;
                    string password = textBoxPassword.Text;
                    MySqlCommand cmd = con.CreateCommand();
                    MySqlDataReader Reader;
                    cmd.CommandText = $"SELECT * FROM login_tbl WHERE Username='{username}' AND Password='{password}'";
                    con.Open();
                    Reader = cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        Dashboard dashboard = new Dashboard();
                        this.Hide();
                        dashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or Password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
