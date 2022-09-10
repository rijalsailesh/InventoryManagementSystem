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
    internal class SalesDetailsDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        #region Insert Sales Details
        public bool InsertSalesDetails(SalesDetailsBLL sd)
        {
            bool success = false;
            try
            {
                string query = $"INSERT INTO sales_details_tbl (ProductId, Rate, Quantity, Total, CustomerId, AddedDate, AddedBy, SalesId ) VALUES ('{sd.ProductId}',{sd.Rate}, {sd.Quantity}, {sd.Total}, {sd.CustomerId}, '{sd.AddedDate.ToString("yyyy-MM-dd")}', {sd.AddedBy}, {sd.SalesId})";
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
    }
}
