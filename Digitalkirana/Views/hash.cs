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
    public partial class hash : Form
    {
        public hash()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string hashed = "$2a$10$sCufqbiC5njqJj2urNCXBuNIFHHlc2WeA9E/aVbzB.KAqDJXvLPxK";
            if (BCrypt.Net.BCrypt.Verify(textBox1.Text, hashed))
            {
                MessageBox.Show("Yes");
            }
            else
            {
                MessageBox.Show("No");
            }
        }
    }
}
