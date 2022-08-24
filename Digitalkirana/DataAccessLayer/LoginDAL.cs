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
    public class LoginDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        #region Check login
        public bool loginCheck(LoginBLL login)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT * FROM user_tbl WHERE Username='{login.Username}' AND Password='{login.Password}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
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
            return false;
        }
        #endregion

        #region Get User Type
        public string getUserType(LoginBLL login)
        {
            string userType = "";
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT UserType FROM user_tbl WHERE Username='{login.Username}' AND Password='{login.Password}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    userType = dt.Rows[0][0].ToString();
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
            return userType;
        }
        #endregion

        #region Get Full Name
        public string getFullName(LoginBLL login)
        {
            string fullName = "";
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT FullName FROM user_tbl WHERE Username='{login.Username}' AND Password='{login.Password}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    fullName = dt.Rows[0][0].ToString();
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
            return fullName;
        }
        #endregion

        #region Get Username
        public string getUsername(LoginBLL login)
        {
            string username = "";
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT Username FROM user_tbl WHERE Username='{login.Username}' AND Password='{login.Password}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    username = dt.Rows[0][0].ToString();
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
            return username;
        }
        #endregion
    }
}
