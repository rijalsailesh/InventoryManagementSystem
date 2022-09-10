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
    public class SalesDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        #region Insert Sales
        public bool InsertSales(SalesBLL sales, out int salesId)
        {
            bool success = false;
            salesId = -1;
            try
            {
                string query = $"INSERT INTO sales_tbl (CustomerId, GrandTotal, Date, Tax, Discount, AddedBy ) VALUES ({sales.CustomerId}, {sales.GrandTotal},'{sales.Date.ToString("yyyy-MM-dd")}', {sales.Tax}, {sales.Discount}, {sales.AddedBy}); SELECT LAST_INSERT_ID()";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                var obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    salesId = int.Parse(obj.ToString());
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
