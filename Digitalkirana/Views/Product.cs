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
using System.Windows.Forms;

namespace Digitalkirana.Views
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
            textBoxRate.Maximum = Decimal.MaxValue;
            textBoxQuantity.Maximum = Decimal.MaxValue;
        }

        CategoryDAL categoryDAL = new CategoryDAL();
        ProductBLL product = new ProductBLL();
        ProductDAL productDAL = new ProductDAL();
        UserDAL userDAL = new UserDAL();
        public string productId;


        private void Product_Load(object sender, EventArgs e)
        {

            dataGridViewProduct.DataSource = productDAL.SelectAllProducts();
            comboBoxCategory.DataSource = categoryDAL.SelectAllCategories();
            comboBoxCategory.DisplayMember = "CategoryName";
            comboBoxCategory.ValueMember = "Id";
            comboBoxCategory.SelectedIndex = -1;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (textBoxProductId.Text != "" && comboBoxCategory.Text != "")
            {

            product.Id = textBoxProductId.Text;
            product.ProductName = textBoxProductName.Text;
            product.Category = comboBoxCategory.Text;
            product.Description = textBoxDescription.Text;
            product.Rate = textBoxRate.Value;
            product.Quantity = textBoxQuantity.Value;
            product.AddedBy = userDAL.getUserId(Login.username);
            product.AddedDate = DateTime.Now;

            if (productId !=null)
            {
                productDAL.UpdateProduct(product);
            }
            else
            {
                productDAL.InsertProduct(product);
            }
            dataGridViewProduct.DataSource = productDAL.SelectAllProducts();
            reset();
            }
            else
            {
                MessageBox.Show("Some field is missing!!");
            }
        }

        private void reset()
        {
            saveBtn.Text = "Add";
            textBoxProductId.Clear();
            textBoxProductName.Clear();
            comboBoxCategory.SelectedIndex = -1;
            textBoxDescription.Clear();
            textBoxRate.Value=0;
            textBoxQuantity.Value=0;
            textBoxProductId.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            productDAL.DeleteProduct(product);
            reset();
            dataGridViewProduct.DataSource = productDAL.SelectAllProducts();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;
            if (keyword == null)
            {
                dataGridViewProduct.DataSource = productDAL.SelectAllProducts();
            }
            else
            {
                dataGridViewProduct.DataSource = productDAL.SearchProduct(keyword);
            }
        }

        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxProductId.Enabled = false;
            saveBtn.Text = "Update";
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            DataGridViewRow selectedRow = dataGridViewProduct.Rows[rowIndex];

            productId = selectedRow.Cells[0].Value.ToString();
            textBoxProductId.Text = selectedRow.Cells[0].Value.ToString();
            textBoxProductName.Text = selectedRow.Cells[1].Value.ToString();
            comboBoxCategory.Text = selectedRow.Cells[2].Value.ToString();
            textBoxDescription.Text = selectedRow.Cells[3].Value.ToString();
            textBoxRate.Text = selectedRow.Cells[4].Value.ToString();
            textBoxQuantity.Text = selectedRow.Cells[5].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void dataGridViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
