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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        CategoryBLL category = new CategoryBLL();
        CategoryDAL categoryDAL = new CategoryDAL();
        UserDAL userDAL = new UserDAL();

        private void dataGridViewCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridViewCategory.Rows[rowIndex];
            category.Id = Convert.ToInt32(selectedRow.Cells[0].Value);
            textBoxCategoryName.Text = selectedRow.Cells[1].Value.ToString();
            textBoxDescription.Text = selectedRow.Cells[2].Value.ToString();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            category.CategoryName = textBoxCategoryName.Text;
            category.Description = textBoxDescription.Text;
            category.AddedDate = DateTime.Now;
            category.AddedBy = userDAL.getUserId(Login.username);

            if (category.Id > 0)
            {
                categoryDAL.UpdateCategory(category);
            }
            else
            {
                categoryDAL.InsertCategory(category);
            }
            dataGridViewCategory.DataSource = categoryDAL.SelectAllCategories();
            reset();
        }

        private void reset()
        {
            category.Id = 0;
            textBoxCategoryName.Clear();
            textBoxDescription.Clear();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            dataGridViewCategory.DataSource = categoryDAL.SelectAllCategories();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            categoryDAL.DeleteCategory(category);
            dataGridViewCategory.DataSource = categoryDAL.SelectAllCategories();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;
            if (keyword == null)
            {
                dataGridViewCategory.DataSource = categoryDAL.SelectAllCategories();
            }
            else
            {
                dataGridViewCategory.DataSource = categoryDAL.SearchCategory(keyword);
            }
        }
    }
}
