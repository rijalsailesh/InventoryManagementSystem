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
        }

        CategoryDAL categoryDAL = new CategoryDAL();

        private void Product_Load(object sender, EventArgs e)
        {
            comboBoxCategory.DataSource = categoryDAL.SelectAllCategories();
            comboBoxCategory.DisplayMember = "CategoryName";
            comboBoxCategory.ValueMember = "Id";
            comboBoxCategory.SelectedIndex = -1;
        }
    }
}
