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
    public class ProductDAL
    {

        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        #region Select Products
        public DataTable SelectAllProducts()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM product_tbl";
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

        #region Insert Product
        public bool InsertProduct(ProductBLL product)
        {
            try
            {
                string query = $"INSERT INTO product_tbl (Id, ProductName, Category, Description, Rate, Quantity, AddedBy, AddedDate ) VALUES ('{product.Id}','{product.ProductName}', '{product.Category}', '{product.Description}', {product.Rate}, {product.Quantity}, {product.AddedBy},'{product.AddedDate.ToString("yyyy-MM-dd")}')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Product Added Successfully");
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
            MessageBox.Show("Product Could not be added");
            return false;
        }
        #endregion

        #region Update Product
        public bool UpdateProduct(ProductBLL product)
        {
            try
            {
                string query = $"UPDATE product_tbl SET ProductName='{product.ProductName}', Category = '{product.Category}', Description = '{product.Description}', Rate = {product.Rate}, Quantity = {product.Quantity} WHERE Id = '{product.Id}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Product Updated Successfully");
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
            MessageBox.Show("Product Could not be updated");
            return false;
        }
        #endregion

        #region Search Product
        public DataTable SearchProduct(string keyword)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT * FROM product_tbl WHERE Id LIKE '%{keyword}%' OR ProductName LIKE '%{keyword}%'";
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

        #region Delete Product
        public bool DeleteProduct(ProductBLL product)
        {
            try
            {
                string query = $"DELETE FROM product_tbl WHERE Id = {product.Id}";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Product Deleted Successfully");
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
            MessageBox.Show("Product Could not be deleted");
            return false;
        }
        #endregion

    }
}
