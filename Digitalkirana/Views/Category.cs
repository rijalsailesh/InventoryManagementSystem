using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digitalkirana.Views
{
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection(Connection.connectionString);
        int id = 0;


        private void saveBtn_Click_1(object sender, EventArgs e)
        {
            string query = "";
            string successMessage = "";
            try
            {
                if (id == 0)
                {
                    query = $"INSERT INTO category_tbl (CategoryName) VALUES ('{textBoxCategory.Text}')";
                    successMessage = $"Category: {textBoxCategory.Text} Added Successfully";
                }
                else
                {
                    query = $"UPDATE category_tbl SET CategoryName = '{textBoxCategory.Text}' WHERE Id = {id}";
                    successMessage = $"Category: {textBoxCategory.Text} Updated Successfully";
                }
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(successMessage);
                textBoxCategory.Clear();
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                SetDataInGridView();
            }
        }

        private void Category_Load(object sender, EventArgs e)
        {
            SetDataInGridView();
        }

        private void SetDataInGridView()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM category_tbl", con);
                DataTable dt = new DataTable();
                con.Open();
                adapter.Fill(dt);
                dataGridViewCategory.DataSource = dt;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }


        private void dataGridViewCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridViewCategory.Rows[index];
            id = Convert.ToInt32(selectedRow.Cells[0].Value);
            textBoxCategory.Text = selectedRow.Cells[1].Value.ToString();
        }
    }
}
