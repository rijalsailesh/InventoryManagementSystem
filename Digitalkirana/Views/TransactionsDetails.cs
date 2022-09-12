using Digitalkirana.BusinessLogicLayer;
using Digitalkirana.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Digitalkirana.Views
{
    public partial class TransactionsDetails : Form
    {
        public int Tid;
        public string Ttype;
        public string total;
        public TransactionsDetails(int transactionId, string type, string totalAmount)
        {
            InitializeComponent();
            Tid = transactionId;
            Ttype = type;
            total = totalAmount;
        }
        SalesDetailsDAL salesDetailsDAL = new SalesDetailsDAL();
        PurchaseDetailsDAL purchaseDetailsDAL = new PurchaseDetailsDAL();
        
        private void TransactionsDetails_Load(object sender, EventArgs e)
        {
            dataGridViewPurchaseDetails.SelectedCells[0].Selected = false;
            if (Ttype == "sales")
            {
                dataGridViewPurchaseDetails.DataSource = salesDetailsDAL.SelectSalesDetailsBySalesId(Tid);
            }
            else if (Ttype == "purchase")
            {
                dataGridViewPurchaseDetails.DataSource = purchaseDetailsDAL.SelectPurchaseDetailsByPurchaseId(Tid);

            }
            totalAmt.Text = total;
        }
    }
}
