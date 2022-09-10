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
    public class CategoryDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);
        
        #region Select Categories
        public DataTable SelectAllCategories()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM category_tbl";
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

        #region Insert Category
        public bool InsertCategory(CategoryBLL category)
        {
            try
            {
                string query = $"INSERT INTO category_tbl (CategoryName, Description, AddedBy, AddedDate ) VALUES ('{category.CategoryName}','{category.Description}',{category.AddedBy},'{category.AddedDate.ToString("yyyy-MM-dd")}')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Category Added Successfully", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show("Category could not be added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        #endregion

        #region Update Category
        public bool UpdateCategory(CategoryBLL category)
        {
            try
            {
                string query = $"UPDATE category_tbl SET CategoryName = '{category.CategoryName}', Description = '{category.Description}' WHERE Id = {category.Id}";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Category Updated Successfully");
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
            MessageBox.Show("Category could not be updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        #endregion

        #region Search Category
        public DataTable SearchCategory(string keyword)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT * FROM category_tbl WHERE Id LIKE '%{keyword}%' OR CategoryName LIKE '%{keyword}%'";
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

        #region Delete Category
        public bool DeleteCategory(CategoryBLL category)
        {
            try
            {
                string query = $"DELETE FROM category_tbl WHERE Id = {category.Id}";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Category Deleted Successfully");
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
            MessageBox.Show("Category could not be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        #endregion
    }
}
