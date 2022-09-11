using Digitalkirana.BusinessLogicLayer;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
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

        #region Select Sales Transactions
        public DataTable SelectSalesTransactions()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT s.Id `Sales ID`, c.CustomerName `Customer Name`, s.GrandTotal `Grand Total`, s.Tax, s.Discount, s.Date, u.FullName `Added By` FROM sales_tbl s INNER JOIN customer_tbl c on s.CustomerId = c.Id INNER JOIN user_tbl u on u.Id = s.AddedBy";
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
    }
}
