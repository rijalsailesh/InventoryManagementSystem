﻿using Digitalkirana.BusinessLogicLayer;
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
    public class SupplierDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        #region Select Suppliers
        public DataTable SelectAllSuppliers()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM supplier_tbl";
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

        #region Insert Supplier
        public bool InsertSupplier(SupplierBLL supplier)
        {
            try
            {
                string query = $"INSERT INTO supplier_tbl (SupplierName, Email, Phone, Address, AddedBy, AddedDate) VALUES ('{supplier.SupplierName}','{supplier.Email}', '{supplier.Phone}','{supplier.Address}',{supplier.AddedBy}, '{supplier.AddedDate.ToString("yyyy-MM-dd")}')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Supplier Added Successfully");
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
            MessageBox.Show("Supplier Could not be added");
            return false;
        }
        #endregion

        #region Update Supplier
        public bool UpdateSupplier(SupplierBLL supplier)
        {
            try
            {
                string query = $"UPDATE supplier_tbl SET SupplierName = '{supplier.SupplierName}', Email = '{supplier.Email}', Phone = '{supplier.Phone}', Address = '{supplier.Address}' WHERE Id = {supplier.Id}";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Supplier Updated Successfully");
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
            MessageBox.Show("Supplier Could not be updated");
            return false;
        }
        #endregion

        #region Search Supplier
        public DataTable SearchSupplier(string keyword)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT * FROM supplier_tbl WHERE Id LIKE '%{keyword}%' OR SupplierName LIKE '%{keyword}%'";
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

        #region Delete Supplier
        public bool DeleteSupplier(SupplierBLL supplier)
        {
            try
            {
                string query = $"DELETE FROM supplier_tbl WHERE Id = {supplier.Id}";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Supplier Deleted Successfully");
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
            MessageBox.Show("Supplier Could not be deleted");
            return false;
        }
        #endregion

        #region Search Supplier For Purchase
        public SupplierBLL SearchSupplierForPurchase(string keyword)
        {
            DataTable dt = new DataTable();
            SupplierBLL supplier = new SupplierBLL();
            try
            {
                string query = $"SELECT Id, SupplierName, Email, Phone, Address FROM supplier_tbl WHERE Id LIKE '%{keyword}%' OR SupplierName LIKE '%{keyword}%'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    supplier.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    supplier.SupplierName = dt.Rows[0]["SupplierName"].ToString();
                    supplier.Email = dt.Rows[0]["Email"].ToString();
                    supplier.Phone = dt.Rows[0]["Phone"].ToString();
                    supplier.Address = dt.Rows[0]["Address"].ToString();
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

            return supplier;
        }
        #endregion
    }
}
