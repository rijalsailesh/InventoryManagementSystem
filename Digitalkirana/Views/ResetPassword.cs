using Digitalkirana.DataAccessLayer;
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
    public partial class ResetPassword : Form
    {
        public int userId;
        public ResetPassword(int id)
        {
            InitializeComponent();
            userId = id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(textBoxNewPassword.Text=="" || textBoxConfirmPassword.Text == "")
            {
                MessageBox.Show("Please Enter New/Confirm Password");
            }
            else
            {
                if (textBoxNewPassword.Text == textBoxConfirmPassword.Text)
                {
                    UserDAL userDAL = new UserDAL();
                    userDAL.ResetPasswordByUserId(userId,textBoxNewPassword.Text);
                    reset();
                }
                else
                {
                    MessageBox.Show("New password and confirm password does not matched");
                    return;
                }
            }
        }

        private void reset()
        {
            textBoxNewPassword.Clear();
            textBoxConfirmPassword.Clear();
        }
    }
}
