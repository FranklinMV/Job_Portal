using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Security.Cryptography;
namespace JobPortal
{
    public partial class Applicant_Registration : Form
    {
        private MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        private int user;
        public Applicant_Registration()
        {
            InitializeComponent();
          
        }
        public void user_type(int user_type) {
            this.user = user_type;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            RegistrationChoice choice = new RegistrationChoice();

            choice.FormClosed += (s, args) => this.Close();

            choice.Show();

            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm choice = new LoginForm();

            choice.FormClosed += (s, args) => this.Close();

            choice.Show();

            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(a.Text) ||
                string.IsNullOrWhiteSpace(c.Text) ||
                string.IsNullOrWhiteSpace(d.Text) ||
                string.IsNullOrWhiteSpace(e_pass.Text) ||
                string.IsNullOrWhiteSpace(f.Text) ||
                string.IsNullOrWhiteSpace(address.Text)
                )
            {
                MessageBox.Show("Error: All fields are required.", "Fields Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Regex.IsMatch(d.Text, @"^\d{11}$"))
            {
                MessageBox.Show("Error: Invalid Contact number must contain exactly 11 numeric characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!IsValidEmail(c.Text))
            {
                MessageBox.Show("Error: Invalid Email Address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!(e_pass.Text == f.Text)) {
                MessageBox.Show("Error: Password does not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();

                string checkEmailQuery = "SELECT COUNT(*) FROM `user` WHERE `email` = @check_email";
                MySqlCommand checkEmailCommand = new MySqlCommand(checkEmailQuery, connection);
                checkEmailCommand.Parameters.AddWithValue("@check_email", c.Text);

                int emailExists = Convert.ToInt32(checkEmailCommand.ExecuteScalar());

                if (emailExists > 0)
                {
                    MessageBox.Show("Error: The email is already registered.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string insert = "INSERT INTO `user`(`name`, `email`, `contact_no`, `address`, `user_type`, `password`) VALUES (@fullname,@email,@contact_no,@address,@user_type,@password)";
                    MySqlCommand insertCommand = new MySqlCommand(insert, connection);
                    insertCommand.Parameters.AddWithValue("@fullname", a.Text.ToUpper());
                    insertCommand.Parameters.AddWithValue("@email", c.Text.ToUpper());
                    insertCommand.Parameters.AddWithValue("@contact_no", d.Text);
                    insertCommand.Parameters.AddWithValue("@user_type", user == 1 ? 1 : 2);
                    insertCommand.Parameters.AddWithValue("@address", address.Text.ToUpper());
                    insertCommand.Parameters.AddWithValue("@password", GetMD5Hash(f.Text));

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoginForm choice = new LoginForm();

                        choice.FormClosed += (s, args) => this.Close();

                        choice.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No rows inserted.", "Insertion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
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

        private void RegistrationLoad(object sender, EventArgs e)
        {
            if (user == 2)
            {

                this.Text = "Company Registration";
                name.Text = "Company Name";
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            RegistrationChoice choice = new RegistrationChoice();

            choice.FormClosed += (s, args) => this.Close();

            choice.Show();

            this.Hide();
        }
    }
}
