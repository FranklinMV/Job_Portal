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
using System.Security.Cryptography;


namespace JobPortal
{
    public partial class LoginForm : Form
    {


        public LoginForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationChoice choice = new RegistrationChoice();

            choice.FormClosed += (s, args) => this.Close();

            choice.Show();

            this.Hide();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {


            string email = a.Text;
            string inputPassword = b.Text;
            //string email = "watson@gmail.com";
            //string inputPassword = "password";

            string inputPasswordHash = GetMD5Hash(inputPassword);

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT password,user_type,id FROM `user` WHERE email = @email";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@email", email);

                    // Execute the query and retrieve the result set
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read()) // If there are rows returned
                    {
                        string storedPasswordHash = reader.GetString(0);
                        int user_type = reader.GetInt32(1);
                        int id = reader.GetInt32(2);

                        if (inputPasswordHash == storedPasswordHash)
                        {
                            if (user_type == 1) {
                                Dashboard dash = new Dashboard();
                                dash.FormClosed += (s, args) => this.Close();
                                dash.GetApplicantId(id);
                                dash.Show();
                                this.Hide();
                            } else if (user_type == 2) {
                                Employer_Dashboard dash = new Employer_Dashboard();
                                dash.FormClosed += (s, args) => this.Close();
                                dash.GetCompany(id);
                                dash.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else // No rows returned (email not found)
                    {
                        MessageBox.Show("Email not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
        public static string GetMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); 
                }
                return sb.ToString();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
