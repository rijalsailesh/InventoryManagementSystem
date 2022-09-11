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
    public class PurchaseDetailsDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        #region Insert Purchase Details
        public bool InsertPurchaseDetails(PurchaseDetailsBLL pd)
        {
            bool success = false;
            try
            {
                string query = $"INSERT INTO purchase_details_tbl (ProductId, Rate, Quantity, Total, SupplierId, AddedDate, AddedBy, PurchaseId ) VALUES ('{pd.ProductId}',{pd.Rate}, {pd.Quantity}, {pd.Total}, {pd.SupplierId}, '{pd.AddedDate.ToString("yyyy-MM-dd")}', {pd.AddedBy}, {pd.PurchaseId})";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
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

        #region Select Purchase Details By PurchaseId
        public DataTable SelectPurchaseDetailsByPurchaseId(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT * FROM purchase_details_tbl WHERE PurchaseId = {id}";
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
