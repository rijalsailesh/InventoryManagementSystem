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
        int transactionId = 0;
        string totalAmt = null;

        private void Transactions_Load(object sender, EventArgs e)
        {
            comboBoxTransaction.SelectedIndex = -1;
        }

        private void comboBoxTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTransaction.SelectedIndex == 0)
            {
                dataGridViewTransactions.DataSource = salesDAL.SelectSalesTransactions();
            }
            else if(comboBoxTransaction.SelectedIndex== 1)
            {
                dataGridViewTransactions.DataSource = purchaseDAL.SelectPurchaseTransactions();
            }
            
        }

        private void dataGridViewTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            DataGridViewRow selectedRow = dataGridViewTransactions.Rows[rowIndex];
            transactionId = Convert.ToInt32(selectedRow.Cells[0].Value);
            btnDetails.Enabled = true;
            totalAmt = Convert.ToString(selectedRow.Cells[2].Value);
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            string type = null;
            if (comboBoxTransaction.SelectedIndex == 0)
            {
                type = "sales";
            }
            else if (comboBoxTransaction.SelectedIndex == 1)
            {
                type = "purchase";
            }
            if(type!= null)
            {
                TransactionsDetails transactionsDetails = new TransactionsDetails(transactionId, type, totalAmt);
                transactionsDetails.ShowDialog();
            }
        }

    }
}
