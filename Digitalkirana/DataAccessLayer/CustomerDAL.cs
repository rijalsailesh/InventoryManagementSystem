using Digitalkirana.BusinessLogicLayer;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digitalkirana.DataAccessLayer
{
    public class CustomerDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        #region Select Customers
        public DataTable SelectAllCustomers()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM customer_tbl";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion

        #region Insert Customers
        public bool InsertCustomer(CustomerBLL customer)
        {
            try
            {
                string query = $"INSERT INTO customer_tbl (CustomerName, Email, Phone, Address, AddedBy, AddedDate) VALUES ('{customer.CustomerName}','{customer.Email}', '{customer.Phone}','{customer.Address}',{customer.AddedBy}, '{customer.AddedDate.ToString("yyyy-MM-dd")}')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Customer Added Successfully");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            MessageBox.Show("Customer could not be added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        #endregion

        #region Update Customer
        public bool UpdateCustomer(CustomerBLL customer)
        {
            try
            {
                string query = $"UPDATE customer_tbl SET CustomerName = '{customer.CustomerName}', Email = '{customer.Email}', Phone = '{customer.Phone}', Address = '{customer.Address}' WHERE Id = {customer.Id}";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Customer Updated Successfully");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            MessageBox.Show("Customer Could not be updated");
            return false;
        }
        #endregion

        #region Search Customer
        public DataTable SearchCustomer(string keyword)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT * FROM customer_tbl WHERE Id LIKE '%{keyword}%' OR CustomerName LIKE '%{keyword}%'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion

        #region Delete Customer
        public bool DeleteCustomer(CustomerBLL customer)
        {
            try
            {
                string query = $"DELETE FROM customer_tbl WHERE Id = {customer.Id}";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Customer Deleted Successfully");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            MessageBox.Show("Customer Could not be deleted");
            return false;
        }
        #endregion
    }
}
