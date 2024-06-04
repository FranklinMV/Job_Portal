using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace JobPortal
{
    public partial class Employer_Profile : Form
    {
        private int id;
        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public Employer_Profile()
        {
            InitializeComponent();
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public void GetUserDetails(int id)
        {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT name, email, contact_no, address FROM user WHERE id = @Id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            a.Text = reader["name"].ToString();
                            b.Text = reader["email"].ToString();
                            c.Text = reader["contact_no"].ToString();
                            d.Text = reader["address"].ToString();
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void ProfileLoad(object sender, EventArgs e)
        {
            GetUserDetails(id);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
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
                        GetUserDetails(id);
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
    }
}
