using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace JobPortal
{
    public partial class Applicant_Profile : Form
    {
        int id;

        public Applicant_Profile()
        {
            InitializeComponent();
            //ExpFetch();
        }
        public void getId(int id)
        {
            this.id = id;
        }
        public void GetUserDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT name, contact_no, address,email FROM `user` WHERE id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        a.Text = reader.GetString("name");
                        b.Text = reader.GetString("email");
                        c.Text = reader.GetString("contact_no");
                        d.Text = reader.GetString("address");
                        reader.Close();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
        //private void ExpFetch() {
        //    for (int i = 0; i < 5; i++)
        //    {
        //        applicant_exp_control exp = new applicant_exp_control();
        //        flowLayoutPanel1.Controls.Add(exp);
        //    }
            
        //}

        private void ProfileLoad(object sender, EventArgs e)
        {
            GetUserDetails();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            string name = a.Text;
            string email = b.Text;
            string contact_no = c.Text;
            string addres = d.Text;

            string sql = "UPDATE `user` SET name = @name, email = @email, contact_no= @contact_no, address = @address WHERE id = @id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a MySqlCommand object
                    MySqlCommand command = new MySqlCommand(sql, connection);

                    // Add parameters
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@contact_no", contact_no);
                    command.Parameters.AddWithValue("@address", addres);
                    command.Parameters.AddWithValue("@id", id);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetUserDetails();
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    MessageBox.Show("Error updating user information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
