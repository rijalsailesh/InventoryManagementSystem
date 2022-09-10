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
        public bool InsertPurchase(PurchaseBLL purchase, out int purchaseId)
        {
            bool success = false;
            purchaseId = -1;
            try
            {
                string query = $"INSERT INTO purchase_tbl (SupplierId, GrandTotal, Date, Tax, Discount, AddedBy ) VALUES ({purchase.SupplierId}, {purchase.GrandTotal},'{purchase.Date.ToString("yyyy-MM-dd")}', {purchase.Tax}, {purchase.Discount}, {purchase.AddedBy}); SELECT LAST_INSERT_ID()";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                var obj = cmd.ExecuteScalar();
                if (obj!=null)
                {
                    purchaseId = int.Parse(obj.ToString());
                    success = true;
                }
                else
                {
                    success = false;
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
            return success;
        }
        #endregion
    }
}
