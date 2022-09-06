using Digitalkirana.BusinessLogicLayer;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digitalkirana.DataAccessLayer
{
    public class PurchaseDetailsDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        #region Insert Category
        public bool InsertCategory(PurchaseDetailsBLL pd)
        {
            try
            {
                string query = $"INSERT INTO purchase-details_tbl (ProductId, Rate, Quantity, Total, SupplierId, AddedDate, AddedBy ) VALUES ('{pd.ProductId}',{pd.Rate}, {pd.Quantity}, {pd.Total}, {pd.SupplierId}, '{pd.AddedDate.ToString("yyyy-MM-dd")}', {pd.AddedBy})";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Category Added Successfully");
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
            MessageBox.Show("Category Could not be added");
            return false;
        }
        #endregion
    }
}
