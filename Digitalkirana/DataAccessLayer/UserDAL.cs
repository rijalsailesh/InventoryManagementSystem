using Digitalkirana.BusinessLogicLayer;
using MySqlConnector;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace Digitalkirana.DataAccessLayer
{
    public class UserDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);
        #region Select Users
        public DataTable SelectAllUsers()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM user_tbl";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
            }
            catch(Exception ex)
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

        #region Insert User
        public bool InsertUser(UserBLL user)
        {
            try
            {
                string query = $"INSERT INTO user_tbl (FullName, Username, Password, Phone, Address, Gender, UserType, AddedDate, AddedBy, Active) VALUES ('{user.FullName}','{user.UserName}','{user.Password}','{user.Phone}','{user.Address}','{user.Gender}','{user.UserType}','{user.AddedDate}','{user.AddedBy}',{user.Active})";
                MySqlCommand cmd = new MySqlCommand(query,con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("User Added Successfully");
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            MessageBox.Show("User Could not be added");
            return false;
        }
        #endregion

        #region Update User
        public bool UpdateUser(UserBLL user)
        {
            try
            {
                string query = $"UPDATE user_tbl SET FullName = '{user.FullName}', Username = '{user.UserName}', Password = '{user.Password}', Phone = '{user.Phone}', Address = '{user.Address}', Gender = '{user.Gender}', UserType = '{user.UserType}', Active = {user.Active} WHERE Id = '{user.Id}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("User Updated Successfully");
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
            MessageBox.Show("User Could not be updated");
            return false;
        }
        #endregion

        #region Search User
        public DataTable SearchUser(string keyword)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT * FROM user_tbl WHERE Id LIKE '%{keyword}%' OR FullName LIKE '%{keyword}%' OR Username LIKE '%{keyword}%'";
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

        #region Get User Id From UserName
        public int getUserId(string username)
        {
            int userId = 0;
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT Id FROM user_tbl WHERE Username='{username}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    userId =Convert.ToInt32(dt.Rows[0][0]);
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
            return userId;
        }
        #endregion
    }
}
