using Digitalkirana.BusinessLogicLayer;
using Digitalkirana.Views;
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
                string query = "SELECT u1.Id, u1.FullName `Full Name`, u1.Username, u1.Phone, u1.Address, u1.Gender, u1.UserType `User Type`, u1.AddedDate `Added Date`, u1.Active, u2.FullName  FROM `user_tbl` u1 INNER JOIN user_tbl u2 ON u1.AddedBy = u2.Id";
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
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                string query = $"INSERT INTO user_tbl (FullName, Username, Password, Phone, Address, Gender, UserType, AddedDate, AddedBy, Active) VALUES ('{user.FullName}','{user.UserName}','{hashedPassword}','{user.Phone}','{user.Address}','{user.Gender}','{user.UserType}','{user.AddedDate.ToString("yyyy-MM-dd")}','{user.AddedBy}',{user.Active})";
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
                string query = $"UPDATE user_tbl SET FullName = '{user.FullName}', Username = '{user.UserName}', Phone = '{user.Phone}', Address = '{user.Address}', Gender = '{user.Gender}', UserType = '{user.UserType}', Active = {user.Active} WHERE Id = '{user.Id}'";
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
                string query = $"SELECT u1.Id, u1.FullName `Full Name`, u1.Username, u1.Phone, u1.Address, u1.Gender, u1.UserType `User Type`, u1.AddedDate `Added Date`, u1.Active, u2.FullName  FROM `user_tbl` u1 INNER JOIN user_tbl u2 ON u1.AddedBy = u2.Id WHERE u1.Id LIKE '%{keyword}%' OR u1.FullName LIKE '%{keyword}%' OR u1.Username LIKE '%{keyword}%'";
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

        #region Reset Password By User Id
        public bool ResetPasswordByUserId(int userId, string password)
        {
            try
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                string query = $"UPDATE user_tbl SET Password = '{hashedPassword}' WHERE Id = {userId}";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Password has been reset sucessfully.");
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
            MessageBox.Show("Password could not be reset.");
            return false;
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
