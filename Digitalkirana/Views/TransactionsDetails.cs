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
    public partial class TransactionsDetails : Form
    {
        public TransactionsDetails()
        {
            InitializeComponent();
        }

        private void TransactionsDetails_Load(object sender, EventArgs e)
        {
            dataGridViewPurchaseDetails.DataSource = Transactions.transactionsDetailsDt;
        }
    }
}
