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
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }

        PurchaseDAL purchaseDAL = new PurchaseDAL();
        SalesDAL salesDAL = new SalesDAL();

        private void Transactions_Load(object sender, EventArgs e)
        {
            comboBoxTransaction.SelectedIndex = -1;
        }

        private void comboBoxTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTransaction.SelectedIndex == 0)
            {
                dataGridViewTransactions.DataSource = purchaseDAL.SelectPurchaseTransactions();
            }
            else if(comboBoxTransaction.SelectedIndex== 1)
            {
                dataGridViewTransactions.DataSource = salesDAL.SelectSalesTransactions();
            }
        }
    }
}
