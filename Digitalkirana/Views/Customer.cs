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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        CustomerBLL customer = new CustomerBLL();
        CustomerDAL customerDAL = new CustomerDAL();
        UserDAL userDAL = new UserDAL();


        private void Customer_Load(object sender, EventArgs e)
        {
            dataGridViewCustomer.DataSource = customerDAL.SelectAllCustomers();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            customer.CustomerName = textBoxCustomerName.Text;
            customer.Email = textBoxEmail.Text;
            customer.Phone = textBoxPhone.Text;
            customer.Address = textBoxAddress.Text;
            customer.AddedDate = DateTime.Now;
            customer.AddedBy = userDAL.getUserId(Login.username);

            if (customer.Id > 0)
            {
                customerDAL.UpdateCustomer(customer);
            }
            else
            {
                customerDAL.InsertCustomer(customer);
            }
            dataGridViewCustomer.DataSource = customerDAL.SelectAllCustomers();
            reset();
        }

        private void reset()
        {
            textBoxCustomerName.Clear();
            textBoxEmail.Clear();
            textBoxAddress.Clear();
            textBoxPhone.Clear();
            customer.Id = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            customerDAL.DeleteCustomer(customer);
            reset();
            dataGridViewCustomer.DataSource = customerDAL.SelectAllCustomers();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;
            if (keyword == null)
            {
                dataGridViewCustomer.DataSource = customerDAL.SelectAllCustomers();
            }
            else
            {
                dataGridViewCustomer.DataSource = customerDAL.SearchCustomer(keyword);
            }
        }

        private void dataGridViewCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridViewCustomer.Rows[rowIndex];
            customer.Id = Convert.ToInt32(selectedRow.Cells[0].Value);
            textBoxCustomerName.Text = selectedRow.Cells[1].Value.ToString();
            textBoxEmail.Text = selectedRow.Cells[2].Value.ToString();
            textBoxPhone.Text = selectedRow.Cells[3].Value.ToString();
            textBoxAddress.Text = selectedRow.Cells[4].Value.ToString();
        }
    }
}
