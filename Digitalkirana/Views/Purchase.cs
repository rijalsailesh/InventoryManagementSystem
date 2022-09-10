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
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
            textBoxRate.Maximum = Decimal.MaxValue;
            textBoxQuantity.Maximum = Decimal.MaxValue;
            textBoxInventory.Maximum = Decimal.MaxValue;
            textBoxQuantity.Maximum = Decimal.MaxValue;
            textBoxDiscount.Maximum = Decimal.MaxValue;
            textBoxVat.Maximum = Decimal.MaxValue;
            textBoxPaidAmt.Maximum=Decimal.MaxValue;
            textboxSubtotal.Maximum=Decimal.MaxValue;
            textBoxGrandTotal.Maximum = Decimal.MaxValue;
        }

        SupplierDAL supplierDAL = new SupplierDAL();
        ProductDAL productDAL = new ProductDAL();
        DataTable productDt = new DataTable();
        PurchaseDAL purchaseDAL = new PurchaseDAL();
        UserDAL userDAL = new UserDAL();
        PurchaseDetailsDAL purchaseDetailsDAL = new PurchaseDetailsDAL();
        public string productId;
        public int supplierId;

        private void textBoxSupplierSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSupplierSearch.Text;
            if (keyword == null || keyword == "")
            {
                textBoxSupplierName.Clear();
                textBoxEmail.Clear();
                textBoxAddress.Clear();
                textBoxPhone.Clear();
                supplierId = 0;
            }
            else
            {
                var supplier = supplierDAL.SearchSupplierForPurchase(keyword);
                supplierId = supplier.Id;
                textBoxSupplierName.Text = supplier.SupplierName;
                textBoxPhone.Text = supplier.Phone;
                textBoxAddress.Text = supplier.Address;
                textBoxEmail.Text = supplier.Email;
            }
        }

        private void textBoxProductSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxProductSearch.Text;
            if (keyword == null || keyword == "")
            {
                textBoxProductName.Clear();
                textBoxRate.Value=0;
                textBoxQuantity.Value=0;
                textBoxInventory.Value = 0;
                productId = null;
            }
            else
            {
                var product = productDAL.SearchProductForPurchase(keyword);
                productId = product.Id;
                textBoxProductName.Text = product.ProductName;
                textBoxRate.Value = product.Rate;
                textBoxInventory.Value = product.Quantity;
            }
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            string productName = textBoxProductName.Text;
            decimal rate = textBoxRate.Value;
            decimal quantity = textBoxQuantity.Value;
            decimal total = rate * quantity;
            decimal subtotal = textboxSubtotal.Value;
            subtotal = subtotal + total;
            if (productName == "")
            {
                MessageBox.Show("No any product selected");
            }
            else
            {
                productDt.Rows.Add(productId, productName, rate, quantity, total);
                dataGridViewAddedProducts.DataSource = productDt;
                textBoxProductSearch.Clear();
                textBoxProductName.Clear();
                textBoxInventory.Value=0;
                textBoxRate.Value = 0;
                textBoxQuantity.Value = 0;
                textboxSubtotal.Value = subtotal;
            }
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            productDt.Columns.Add("ID");
            productDt.Columns.Add("Product Name");
            productDt.Columns.Add("Rate");
            productDt.Columns.Add("Quantity");
            productDt.Columns.Add("Total");
        }

        private void textBoxDiscount_ValueChanged(object sender, EventArgs e)
        {
            decimal discountPercent = textBoxDiscount.Value;
            decimal subTotal = textboxSubtotal.Value;
            decimal discountAmt = ((discountPercent / 100) * subTotal);
            decimal grandTotal = subTotal - discountAmt;
            textBoxGrandTotal.Value = grandTotal;
        }

        private void textBoxVat_ValueChanged(object sender, EventArgs e)
        {
            if (textBoxGrandTotal.Value>0)
            {
                decimal vatPercent = textBoxVat.Value;
                decimal total = textBoxGrandTotal.Value;
                decimal vatAmt = ((vatPercent / 100) * total);
                decimal grandTotal = total + vatAmt;
                textBoxGrandTotal.Value = grandTotal;
            }
        }

        private void textBoxPaidAmt_ValueChanged(object sender, EventArgs e)
        {
            decimal grandTotal = textBoxGrandTotal.Value;
            decimal paidAmt = textBoxPaidAmt.Value;
            decimal returnAmt = paidAmt - grandTotal;
            textBoxReturnAmt.Text = returnAmt.ToString("0.00");
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            PurchaseBLL purchase = new PurchaseBLL();
            purchase.SupplierId = supplierId;
            purchase.GrandTotal = textBoxGrandTotal.Value;
            purchase.Date = dateTimePickerBill.Value;
            purchase.Tax = textBoxVat.Value;
            purchase.Discount = textBoxDiscount.Value;
            purchase.AddedBy = userDAL.getUserId(Login.username);
            purchase.PurchaseDetails = productDt;

            using (TransactionScope scope = new TransactionScope())
            {
                bool success = false;
                int purchaseId = -1;
                bool w = purchaseDAL.InsertPurchase(purchase, out purchaseId);
                for (int i = 0; i < productDt.Rows.Count; i++)
                {
                    PurchaseDetailsBLL purchaseDetailsBLL = new PurchaseDetailsBLL();
                    purchaseDetailsBLL.ProductId = productDt.Rows[i][0].ToString();
                    purchaseDetailsBLL.Rate = Convert.ToDecimal(productDt.Rows[i][2]);
                    purchaseDetailsBLL.Quantity = Convert.ToDecimal(productDt.Rows[i][3]);
                    purchaseDetailsBLL.Total = Convert.ToDecimal(productDt.Rows[i][4]);
                    purchaseDetailsBLL.SupplierId = supplierId;
                    purchaseDetailsBLL.AddedDate = DateTime.Now;
                    purchaseDetailsBLL.PurchaseId = purchaseId;
                    purchaseDetailsBLL.AddedBy = userDAL.getUserId(Login.username);
                    bool x = productDAL.IncreaseQuantity(purchaseDetailsBLL.ProductId, purchaseDetailsBLL.Quantity);

                    bool y = purchaseDetailsDAL.InsertPurchaseDetails(purchaseDetailsBLL);
                    success = x && w && y;
                }
                if (success)
                {
                    scope.Complete();
                    MessageBox.Show("Purchase transaction successful.");
                    Reset();
                }
                else
                {
                    MessageBox.Show("Purchase transaction failed.");
                }
            }
        }

        private void Reset()
        {
            dataGridViewAddedProducts.DataSource = null;
            dataGridViewAddedProducts.Rows.Clear();
            textBoxProductSearch.Clear();
            textBoxSupplierSearch.Clear();
            textBoxQuantity.Value = 0;
            textboxSubtotal.Value = 0;
            textBoxVat.Value = 0;
            textBoxDiscount.Value = 0;
            textBoxGrandTotal.Value = 0;
            textBoxReturnAmt.Clear();
            textBoxPaidAmt.Value = 0;
        }
    }
}
