using Digitalkirana.BusinessLogicLayer;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digitalkirana.DataAccessLayer
{
    public class PurchaseDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        #region Insert Purchase
        public bool InsertCategory(PurchaseBLL purchase,out int purchaseId)
        {
            try
            {
                string query = $"INSERT INTO purchase_tbl (SupplierId, GrandTotal, Date, Tax, Discount, AddedBy ) VALUES ('{purchase.SupplierId}','{purchase.GrandTotal}','{purchase.Date.ToString("yyyy-MM-dd")}', {purchase.Tax}, {purchase.Discount}, {purchase.AddedBy})";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                object obj = cmd.ExecuteScalar();
                if (obj!=null)
                {
                    purchaseId = (int)obj;
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
            purchaseId = 0;
            return false;
        }
        #endregion
    }
}
